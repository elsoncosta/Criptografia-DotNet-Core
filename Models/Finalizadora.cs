using System.ComponentModel;
namespace CriptografiaDotNetCore.Models
{
    public class Finalizadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }        
        public Empresa Empresa { get; set; }
    }
}