using Microsoft.EntityFrameworkCore;
using TrabalhoBancoDeDados.Entities;

namespace TrabalhoBancoDeDados.Contexts;

public class ClienteContext : DbContext{
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Cidade> Cidades {get; set;}

    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cliente = modelBuilder.Entity<Cliente>();

        var cidade = modelBuilder.Entity<Cidade>();
        
        cidade
            .HasMany(ci => ci.Clientes)
            .WithOne(cl => cl.Cidade)
            .HasForeignKey(cl => cl.CidadeId);

        cidade.Property(ci => ci.Nome)
            .IsRequired()
            .HasMaxLength(60);

        cidade.Property(ci => ci.Uf)
            .IsRequired()
            .HasMaxLength(2);

        cliente.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(60);
        cliente.Property(c => c.Endereco)
            .IsRequired()
            .HasMaxLength(100);
        cliente.Property(c => c.Telefone)
            .IsRequired()
            .HasMaxLength(18);
        cliente.Property(c => c.CidadeId)
            .IsRequired();

        cidade.HasData
        (
            new {
                Id = 1,
                Nome = "Itajai",
                Uf = "SC"
            },
            new {
                Id = 2,
                Nome = "Balneário Camboriu",
                Uf = "SC"
            }, 
            new {
                Id = 3,
                Nome = "Penha",
                Uf = "SC"
            },
            new {
                Id = 4,
                Nome = "Balneário Camboriu",
                Uf = "RS"
            }
        );


        cliente.HasData
        (
            new {
                Id = 21,
                Nome = "Vinícius Carmo",
                Telefone = "913618797913618797",
		        Endereco = "Rua Elizabeth Montibeller dos Santos, Cordeiros",
                CidadeId = 1
            },
               new {
                Id = 22,
                Nome = "Vinícius Carmo",
                Telefone = "913618797913618797",
		        Endereco = "Rua Elizabeth Montibeller dos Santos, Cordeiros",
                CidadeId = 4
            },
            new {
                Id = 20,
                Nome = "Vinícius Carmo",
                Telefone = "913618797913618797",
		Endereco = "Rua Elizabeth Montibeller dos Santos, Cordeiros",
                CidadeId = 1
            },

        new {
                Id = 5,
                Nome = "Miguel Campos",
                Telefone = "966924839966924839",
		        Endereco = "Rua Osni José Jacinto, São Vicente",
                CidadeId = 1
            },

        new {
                Id = 6,
                Nome = "Leonardo Marques",
                Telefone = "922898441922898441",
		        Endereco = "Rua Hercílio Luz, Centro",
                CidadeId = 1
            },

        new {
                Id = 7,
                Nome = "Mirela Rodrigues",
                Telefone = "975617754975617754",
		        Endereco = "Rua Fábio Cesário Pereira, São Judas",
                CidadeId = 1
            },
        new {
                Id = 8,
                Nome = "Elisandra Vasconcelos",
                Telefone = "908015364908015364",
		        Endereco = "Avenida Osvaldo Reis, Fazendinha",
                CidadeId = 1
            },

        new {
                Id = 9,
                Nome = "Marina Medina",
                Telefone = "989277760989277760",
		        Endereco = "Rua Cilina Vechi Merizio, Limoeiro",
                CidadeId = 1
            },

        new {
                Id = 10,
                Nome = "Tereza Ramos",
                Telefone = "917230087917230087",
		        Endereco = "Rua Nelson Augusto da Silva Schiefler, Barra do Rio",
                CidadeId = 1
            },

        new {
                Id = 11,
                Nome = "Suzana Bosco",
                Telefone = "967190866967190866",
		        Endereco = "Rua Januário Pedro Ferreira, Barra",
                CidadeId = 2
            },

        new {
                Id = 12,
                Nome = "Letícia Figueiredo",
                Telefone = "927389821927389821",
		    Endereco = "Avenida Atlântica 640, Centro",
                CidadeId = 2
            },

        new {
                Id = 13,
                Nome = "Fabiano Rezende",
                Telefone = "917230087917230087",
		    Endereco = "Rua Jordânia, Nações",
                CidadeId = 2
            },

        new {
                Id = 14,
                Nome = "Renan Cardoso",
                Telefone = "987380006987380006",
		    Endereco = "Rua das Paineiras, Progresso",
                CidadeId = 3
            },

        new {
                Id = 15,
                Nome = "Luiz Matos",
                Telefone = "941919104941919104",
		    Endereco = "Rua Celso Boos, Progresso",
                CidadeId = 3
            },

        new {
                Id = 16,
                Nome = "Clara Corrêa",
                Telefone = "970872835970872835",
		    Endereco = "Rua Alfredo Boehringer, Badenfurt",
                CidadeId = 3
            },
        new {
                Id = 17,
                Nome = "Clara Almeida",
                Telefone = "970872835970872835",
		        Endereco = "Rua Alfredo Boehringer, Badenfurt",
                CidadeId = 1
            },
        new {
                Id = 18,
                Nome = "Clara Tres",
                Telefone = "970872835970872835",
		        Endereco = "Rua Alfredo Boehringer, Badenfurt",
                CidadeId = 1
            },
        new {
                Id = 19,
                Nome = "Clara Quatro",
                Telefone = "970872835970872835",
		        Endereco = "Rua Alfredo Boehringer, Badenfurt",
                CidadeId = 1
            }

        );

        base.OnModelCreating(modelBuilder);
    }
}