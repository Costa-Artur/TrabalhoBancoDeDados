using System.Text.Json;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TrabalhoBancoDeDados.Contexts;
using Trabalho123.Shared;

namespace TrabalhoBancoDeDados.api.Controllers;

[ApiController]
[Route("/api")]
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _context;
    private readonly IDatabase _redis;
    public readonly IPublishEndpoint publishEndpoint;

    public ClienteController(ClienteContext context, IConnectionMultiplexer muxer, IPublishEndpoint publishEndpoint)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _redis = muxer.GetDatabase();
        this.publishEndpoint = publishEndpoint;
    }

    [HttpGet("/{uf}")]
    public async Task<ActionResult<int>> GetQuantidadeClientesPorUF(string uf)
    {
        // Obtém a quantidade do Redis.
        var keyName = $"quantidade_{uf}";
        var json = await _redis.StringGetAsync(keyName);

        // Define a origem dos dados no header da resposta
        HttpContext.Response.Headers.Add("Data-Source", string.IsNullOrEmpty(json) ? "Database" : "Cache");

        int quantidadeClientes;

        if (string.IsNullOrEmpty(json))
        {
            Console.WriteLine("Nao Existe");

            var cidadesFromDatabase = _context.Cidades.Include(ci => ci.Clientes).Where(ci => ci.Uf == uf).ToList();

            if (cidadesFromDatabase == null) return NotFound();

            Console.WriteLine(cidadesFromDatabase.Count);

            quantidadeClientes = 0;

            foreach (var cidades in cidadesFromDatabase)
            {
                quantidadeClientes += cidades.Clientes.Count;
            }

            json = JsonSerializer.Serialize(quantidadeClientes);
            var setTask = _redis.StringSetAsync(keyName, json);
            var expireTask = _redis.KeyExpireAsync(keyName, TimeSpan.FromSeconds(120));
            await Task.WhenAll(setTask, expireTask);
        }

        quantidadeClientes = JsonSerializer.Deserialize<int>(json);
        
        
        if(quantidadeClientes > 10)
        {
            var cidadesFromDatabase = _context.Cidades.Include(ci => ci.Clientes).Where(ci => ci.Uf == uf).ToList();
            List<ClienteRetorno> ListaClientesRetorno = new ();

            foreach (var ci in cidadesFromDatabase)
            {
                ListaClientesRetorno.AddRange(ci.Clientes.Select(cl => new ClienteRetorno
                {
                    Nome = cl.Nome,
                    Telefone = cl.Telefone
                }));
            }

            await publishEndpoint.Publish<INotificationCreated>(
                    new {
                        Clientes = ListaClientesRetorno
                    }
                );
        }


        return Ok(quantidadeClientes);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetCidade(int id)
    {
        // Obtém a cidade do Redis.
        string json;
        var keyName = $"cidade_{id}";
        json = await _redis.StringGetAsync(keyName);

        // Define a origem dos dados no header da resposta
        HttpContext.Response.Headers.Add("Data-Source", string.IsNullOrEmpty(json) ? "Database" : "Cache");

        // Se a cidade não estiver no Redis, obtém do banco de dados.
        if (string.IsNullOrEmpty(json))
        {
            Console.WriteLine("Nao Existe");
            // Obter a cidade do banco de dados, incluindo seus clientes associados
            var cidadeComClientes = _context.Cidades.Include(c => c.Clientes).FirstOrDefault(c => c.Id == id);

            if (cidadeComClientes == null)
            {
                return NotFound();
            }

            var clientes = cidadeComClientes.Clientes.Select(c => c.Nome);

            json = JsonSerializer.Serialize(clientes);
            var setTask = _redis.StringSetAsync(keyName, json);
            var expireTask = _redis.KeyExpireAsync(keyName, TimeSpan.FromSeconds(120));
            await Task.WhenAll(setTask, expireTask);
        }

        // Deserializa os nomes dos clientes do JSON.
        var nomesClientes = JsonSerializer.Deserialize<IEnumerable<string>>(json);
        return Ok(nomesClientes);
    }
    
}