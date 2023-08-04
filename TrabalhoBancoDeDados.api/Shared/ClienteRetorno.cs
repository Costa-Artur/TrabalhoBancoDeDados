using System.Text.Json.Serialization;

namespace Trabalho123.Shared;

public class ClienteRetorno
{
    public string Nome {get;set;}= string.Empty;
    public string Telefone{get;set;} = string.Empty;
    public ClienteRetorno()
    {
    }
}