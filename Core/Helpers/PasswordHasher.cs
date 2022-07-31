using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class PasswordHasher
    {
        public static string Encrypt(string password)
        {

            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public static string Decrypt(string hashedPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(hashedPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;

        }

        //SHA256
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte b in GetHash(password))
        //    sb.Append(b.ToString("X3"));
        //    return sb.ToString();
        //}
        //    public static byte[] GetHash(string password)
        //{
        //    using (HashAlgorithm algoritm = SHA256.Create())
        //    return algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));
        //}

        //SHA1

        //{
        //    var shaSHA1 = System.Security.Cryptography.SHA1.Create();
        //    var inputEncodingBytes = Encoding.ASCII.GetBytes(password);
        //    var hashString = shaSHA1.ComputeHash(inputEncodingBytes);

        //    var stringBuilder = new StringBuilder();
        //    for (var x = 0; x < hashString.Length; x++)
        //    {
        //        stringBuilder.Append(hashString[x].ToString("X2"));
        //    }
        //    return stringBuilder.ToString();
        //}



    }
}
