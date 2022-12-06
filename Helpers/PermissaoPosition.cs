using System.Reflection;
using System.Text;
using CriptografiaDotNetCore.Annotations;

namespace CriptografiaDotNetCore.Helpers
{
    public static class PermissaoPosition
    {
       public static string Position(this bool valor, string text, int possition)
       {
           string v = valor ? "1" : "0";
           return text.Insert(possition, v);
       }

       public static string PositionBuild<T>(T entity) where T : new ()
       {
            string retorno = string.Empty;
            PropertyInfo[] propertys = entity.GetType().GetProperties();
            foreach (PropertyInfo r in propertys)
            {
                PositionAttribute position = Attribute.GetCustomAttribute(r, typeof(PositionAttribute)) as PositionAttribute;
                if (position == null)
                {
                    continue;
                }            
                retorno = Position(Convert.ToBoolean(r.GetValue(entity, null)), retorno, position.valor);
            }
            return retorno;
       }
    }
}