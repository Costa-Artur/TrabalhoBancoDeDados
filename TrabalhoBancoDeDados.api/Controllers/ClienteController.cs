using Microsoft.AspNetCore.Mvc;
using TrabalhoBancoDeDados.Contexts;

namespace TrabalhoBancoDeDados.api.Controllers;

[ApiController]
[Route("/api")]
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _context;

    public ClienteController(ClienteContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    
}