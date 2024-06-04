using System;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AESExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializing the AES
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.GenerateKey();
            aes.GenerateIV();

            // Change the paths below to the correct file paths on your machine
            // You need to create the files and insert the keys as per the instructions in the README
            string path = "C:\\Users\\Victor\\source\\repos\\Projeto de Iniciação Científica - AES\\Projeto de Iniciação Científica - AES\\bin\\Debug\\net6.0\\teste.txt";
            string pathkey = "C:\\Users\\Victor\\source\\repos\\Projeto de Iniciação Científica - AES\\Projeto de Iniciação Científica - AES\\bin\\Debug\\net6.0\\key.txt";
            string pathiv = "C:\\Users\\Victor\\source\\repos\\Projeto de Iniciação Científica - AES\\Projeto de Iniciação Científica - AES\\bin\\Debug\\net6.0\\iv.txt";

            string plaintext = File.ReadAllText(path);
            string key = File.ReadAllText(pathkey);
            string iv = File.ReadAllText(pathiv);
            byte[] ciphertext;

            byte[] key1 = Encoding.UTF8.GetBytes(key);
            byte[] iv1 = Encoding.UTF8.GetBytes(iv);

            key1 = key1.ToArray();
            iv1 = iv1.ToArray();

            //Encrypt
            //ciphertext = Cripto(plaintext, key1, iv1);
            //StreamWriter sw = new StreamWriter(path);
            //sw.WriteLine(Convert.ToBase64String(ciphertext));
            //sw.Close();

            //Decrypt
            string decryptedText = Decript(plaintext, key1, iv1);
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(decryptedText);
            sw.Close();



        }
        //Encrypt Function
        static byte[] Cripto(string plaintext, byte[] key1, byte[] iv1)
        {
            byte[] ciphertext;
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(key1, iv1))
            {
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                ciphertext = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);

            }
            return ciphertext;


        }
        //Decrypt Function
        static string Decript(string plaintext, byte[] key1, byte[] iv1)
        {
            string decryptedText;
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;


            using (ICryptoTransform decryptor = aes.CreateDecryptor(key1, iv1))
            {
                byte[] plaintextBytes = Convert.FromBase64String(plaintext);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
                decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            }
            return decryptedText;
        }


    }
}
