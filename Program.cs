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
    }
}
