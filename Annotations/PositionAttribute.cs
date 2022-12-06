namespace CriptografiaDotNetCore.Annotations
{
    public class PositionAttribute : Attribute
    {
        public int valor;
        public PositionAttribute(int v)
        {
            this.valor = v;
        }
    }
}