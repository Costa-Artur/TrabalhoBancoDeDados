namespace TrabalhoBancoDeDados.Entities;

public class Cidade{
   public int Id {get;set;}
   public string Nome {get; set;} = string.Empty;
   public string Uf {get; set;} = string.Empty;
   public ICollection<Cliente> Clientes {get; set;} = new List<Cliente>();
}