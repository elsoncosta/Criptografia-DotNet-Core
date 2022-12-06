using System.Linq;
using CriptografiaDotNetCore.Helpers;
using CriptografiaDotNetCore.Models;
using Newtonsoft.Json;

namespace CriptografiaDotNetCore;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var criptografado = CriptografiaNova.Criptografar("Teste cript kkkkkkkkkkkkkkkk", "@TESTE@");
        var scrit = criptografado.DesCriptografar("@TESTE@");
        // var scrit2 = CriptografiaHelper.Decrypt("IXUqakLVJjQHkO9E0l1GNBoJtQYfvrGYe+ndeKo06eQ=");
        Console.WriteLine($"Criptografia: {criptografado}");
        Console.WriteLine($"Descriptografado: {scrit}");
        // Console.WriteLine($"Descriptografado: {scrit2}");

        List<Finalizadora> lists = new()
        {
            new Finalizadora(){Nome = "Finalizadora 1",Descricao = "Descrição 1",Id = 1,
            Empresa = new Empresa(){Id = 1, Nome = "Nome Ltda", NomeFantasia = "Fantasia Ltda"}},
            new Finalizadora(){Nome = "Finalizadora 2",Descricao = "Descrição 2",Id = 2,
            Empresa = new Empresa(){Id = 2, Nome = "Nome Ltda 2", NomeFantasia = "Fantasia Ltda 2"}}
        };

        var retorno =  lists.Where(r=> r.Id == 2)
        .Select(x => x).Select(e => new{e.Empresa})
        .FirstOrDefault();

        Console.WriteLine(JsonConvert.SerializeObject(retorno));

        Console.WriteLine("11".PadLeft(2, '0'));

        string positons = string.Empty;
        var permissao = new Permissao()
        {
            Permissao1 = true,
            Permissao2 = false,
            Permissao3 = true,
            Permissao4 = false
        };
        positons = permissao.Permissao1.Position(positons, 0);
        positons = permissao.Permissao2.Position(positons, 1);
        positons = permissao.Permissao3.Position(positons, 2);
        positons = permissao.Permissao4.Position(positons, 3);

        Console.WriteLine(positons);

        string retornoPositions = PermissaoPosition.PositionBuild<Permissao>(permissao);
        Console.WriteLine(retornoPositions);
    
    }
}
