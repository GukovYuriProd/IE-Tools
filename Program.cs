using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Buffers.Binary;
using System;
static class Program
{
    static void Main(string[] Args)
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Введите строку для хэширования MD5: ");
            string? defaultValue = Console.ReadLine();
            Console.WriteLine(Hasher(defaultValue));
            System.Threading.Thread.Sleep(5);
        }
    }

    private static string Hasher(string InitString)
    {
        byte[] binary_buffer = System.Text.Encoding.UTF8.GetBytes(InitString);
        long size = InitString.Length;

        using (HashAlgorithm HashCreator = MD5.Create())
        {
            HashCreator.TransformFinalBlock(binary_buffer, 0, binary_buffer.Length);
            return HashToString(HashCreator.Hash);
        }
    }

    private static string HashToString(byte[] hashBytes)
    {
        StringBuilder hash = new StringBuilder(32);
        foreach (byte b in hashBytes) hash.Append(b.ToString("X2").ToLower());
        return hash.ToString();
    }
}