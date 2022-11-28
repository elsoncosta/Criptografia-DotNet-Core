using System;
using System.Linq;

namespace CriptografiaDotNetCore
{
    public static class CriptografiaNova
    {
        public static string Criptografar(this string valor, string chave)
        {
            string senhaHash = $"{valor}#=@DATATIME:{DateTime.Now}";
            var codificado = EncodeTo64(senhaHash);
            var codificarComChave = string.Concat(chave, "=====", codificado);
            var codificado2X = EncodeTo64(codificarComChave);
            return EncodeTo64(codificado2X);

        }

        public static string DesCriptografar(this string valor, string chave)
        {
            try
            {
                var decodificar = DecodeFrom64(valor);
                var decodificar2XInformacaoCompleta = DecodeFrom64(decodificar);
                String[] separador = { "=====" };
                Int32 count = 2;
                var separadorInformacao = decodificar2XInformacaoCompleta.Split(separador, count, StringSplitOptions.None);
                var senhaRetorno = DecodeFrom64(separadorInformacao[1]);
                return senhaRetorno.Split("#=@DATATIME:").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static private string DecodeFrom64(string encodeData)
        {
            byte[] encodeDataAsByte = System.Convert.FromBase64String(encodeData);
            string returnValue = System.Text.ASCIIEncoding.UTF8.GetString(encodeDataAsByte);
            return returnValue;
        }
        static private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsByte = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsByte);
            return returnValue;
        }
    }
}