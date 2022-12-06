using CriptografiaDotNetCore.Annotations;

namespace CriptografiaDotNetCore.Helpers
{
    public class Permissao
    {

        [Position(0)]
        public bool Permissao1 { get; set; }
        [Position(1)]
        public bool Permissao2 { get; set; }
        [Position(2)]
        public bool Permissao3 { get; set; }
        [Position(3)]
        public bool Permissao4 { get; set; }
    }
}