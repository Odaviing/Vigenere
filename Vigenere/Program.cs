using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, char> vigenere = new Dictionary<int, char>();
            vigenere.Add(0, 'a');
            vigenere.Add(1, 'b');
            vigenere.Add(2, 'c');
            vigenere.Add(3, 'd');
            vigenere.Add(4, 'e');
            vigenere.Add(5, 'f');
            vigenere.Add(6, 'g');
            vigenere.Add(7, 'h');
            vigenere.Add(8, 'i');
            vigenere.Add(9, 'j');
            vigenere.Add(10, 'k');
            vigenere.Add(11, 'l');
            vigenere.Add(12, 'm');
            vigenere.Add(13, 'n');
            vigenere.Add(14, 'o');
            vigenere.Add(15, 'p');
            vigenere.Add(16, 'q');
            vigenere.Add(17, 'r');
            vigenere.Add(18, 's');
            vigenere.Add(19, 't');
            vigenere.Add(20, 'u');
            vigenere.Add(21, 'v');
            vigenere.Add(22, 'w');
            vigenere.Add(23, 'x');
            vigenere.Add(24, 'y');
            vigenere.Add(25, 'z');
            Console.WriteLine("Enter your message");
            string message = MessCheck(Console.ReadLine());
            Console.WriteLine("Enter your key");
            string key = MessCheck(Console.ReadLine());
            int count = 0;
            if (key.Length < message.Length)
            {
                for (int i = key.Length; i < message.Length; i++)
                {

                    key += key[count];
                    count++;
                    if (count == key.Length)
                    {
                        count = 0;
                    }
                }
            }
            if (key.Length > message.Length)
            {
                key = key.Substring(0, message.Length);
            }
            string encrypt_mess = Vigenere_encrypt(message, key, vigenere);
            
            Console.WriteLine("Your encrypted message is:");
            Console.WriteLine(encrypt_mess);
            Console.WriteLine("Your decrypted message is:");
            Console.WriteLine(Vigenere_decrypt(encrypt_mess, key, vigenere));
        }

        static string MessCheck(string mess)
        {
            int mistake_counter;
            do
            {
                mistake_counter = 0;
                foreach (char ch in mess)
                {
                    if (!Char.IsLetter(ch))
                    {
                        mistake_counter++;
                    }
                }
                if (mistake_counter > 0)
                {
                    Console.WriteLine("This text should contain only letters, enter again");
                    mess = Console.ReadLine();
                }
            } while (mistake_counter > 0);
            return mess.ToLower();
            
        }

        static string Vigenere_encrypt(string message, string key, Dictionary<int, char> vigenere)
        {
            
            string result = "";
            
            for (int i = 0; i < message.Length; i++)
            {
                int encrypt_key = 0;
                foreach (KeyValuePair<int, char> keyValue in vigenere)
                {
                    if (message[i] == keyValue.Value)
                    {
                        encrypt_key += keyValue.Key;
                    }
                    if (key[i] == keyValue.Value)
                    {
                        encrypt_key += keyValue.Key;
                    }
                }
                if (encrypt_key > 25)
                {
                    encrypt_key -= 26;
                }
                result += vigenere[encrypt_key];
            }
            return result;
        }


        static string Vigenere_decrypt(string message, string key, Dictionary<int, char> vigenere)
        {
            
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                int message_number = 0;
                int key_number = 0;
                foreach(KeyValuePair<int, char> keyValue in vigenere)
                {
                    if (message[i] == keyValue.Value)
                    {
                       message_number = keyValue.Key;
                    }
                    if (key[i] == keyValue.Value)
                    {
                        key_number = keyValue.Key;
                    }

                }
                int decrypt_number = (message_number - key_number) + 26;
                if(decrypt_number > 25)
                {
                    decrypt_number -= 26;
                }
                result += vigenere[decrypt_number];
                
            }
            return result;
        }
    }
}
