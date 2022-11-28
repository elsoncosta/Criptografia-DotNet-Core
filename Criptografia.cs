using System;
using System.Security.Cryptography;
using System.Text;

namespace CriptografiaDotNetCore
{
    /// <summary>
    /// Classe de segurança do sistema
    /// </summary>
    public static class CriptografiaHelper
    {

        /// <summary>
        /// Criptografa string
        /// </summary>
        /// <param name="Texto">Texto a ser criptgrafado</param>
        /// <returns>Valor criptografado</returns>
        public static string Criptografa(this string Texto)
        {
            Byte[] b = ASCIIEncoding.UTF8.GetBytes(Texto);
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// Descriptografa string
        /// </summary>
        /// <param name="Texto">Valor criptografado</param>
        /// <returns>Valor descriptografado</returns>
        public static string Descriptografa(this string Texto)
        {
            try
            {
                if (Texto == string.Empty || Texto == null)
                {
                    return "";
                }
                else
                {
                    Byte[] b = Convert.FromBase64String(Texto);
                    return Encoding.UTF8.GetString(b);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma string criptografada usando o formato Hash
        /// </summary>
        /// <param name="text">Texto que será criptografado</param>
        public static string Cript_Hash(this string text)
        {
            UnicodeEncoding Ue = new UnicodeEncoding();
            byte[] ByteSourceText = Ue.GetBytes(text);
            using (MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider())
            {
                byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
                return Convert.ToBase64String(ByteHash);
            }
        }


        public static string Encrypt(string raw)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                ICryptoTransform e = GetCryptoTransform(csp, true);
                var inputBuffer = Encoding.UTF8.GetBytes(raw);
                var output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                var encrypted = Convert.ToBase64String(output);
                return encrypted;
            }
        }

        public static string Decrypt(string descript)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                var d = GetCryptoTransform(csp, false);
                byte[] output = Convert.FromBase64String(descript);
                var decryptedOutput = d.TransformFinalBlock(output, 0, output.Length);
                var decypted = Encoding.UTF8.GetString(decryptedOutput);
                return decypted;
            }
        }

        private static ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting)
        {
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;
            const string passWord = "#UMACHAVESECRETA#";
            const string salt = "#OUTRACHAVESECRETA#";
            const string iv = "e675f725e675f725";//SE EU NAO TIVER ENGANADO AQUI ÉUM HASH QUALQUER

            var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(passWord), Encoding.UTF8.GetBytes(salt), 65536);
            var key = spec.GetBytes(16);
            csp.IV = Encoding.UTF8.GetBytes("e675f725e675f725");
            csp.Key = key;
            if (encrypting)
            {
                return csp.CreateEncryptor();
            }
            return csp.CreateDecryptor();
        }
    }
}