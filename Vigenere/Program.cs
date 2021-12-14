using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Vigenere
{
    class Program
    {
        static Dictionary<int, char> vigenere = new Dictionary<int, char>()
        {
            {0, 'a'},
            {1, 'b'},
            {2, 'c'},
            {3, 'd'},
            {4, 'e'},
            {5, 'f'},
            {6, 'g'},
            {7, 'h'},
            {8, 'i'},
            { 9, 'j'},
            {10, 'k'},
            {11, 'l'},
            {12, 'm'},
            {13, 'n'},
            {14, 'o'},
            {15, 'p'},
            {16, 'q'},
            {17, 'r'},
            {18, 's'},
            {19, 't'},
            {20, 'u'},
            {21, 'v'},
            {22, 'w'},
            {23, 'x'},
            {24, 'y'},
            {25, 'z'}
        };

        static Dictionary<char, int> vigenere_reverse = new Dictionary<char, int>()
        {
            {'a',  0 },
            {'b',  1 },
            {'c',  2 },
            {'d',  3 },
            {'e',  4 },
            {'f',  5 },
            {'g',  6 },
            {'h',  7 },
            {'i',  8 },
            { 'j', 9 },
            { 'k', 10},
            { 'l', 11},
            { 'm', 12},
            { 'n', 13},
            { 'o', 14},
            { 'p', 15},
            { 'q', 16},
            { 'r', 17},
            { 's', 18},
            { 't', 19},
            { 'u', 20},
            { 'v', 21},
            { 'w', 22},
            { 'x', 23},
            { 'y', 24},
            { 'z', 25}
        };
        static void Main(string[] args)
        {

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
            string encrypt_mess = Vigenere_encrypt(message, key);

            Console.WriteLine("Your encrypted message is:");
            Console.WriteLine(encrypt_mess);
            Console.WriteLine("Your decrypted message is:");
            Console.WriteLine(Vigenere_decrypt(encrypt_mess, key));
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

        static string Vigenere_encrypt(string message, string key)
        {

            string result = "";

            for (int i = 0; i < message.Length; i++)
            {
                int encrypt_key = vigenere_reverse[message[i]] + vigenere_reverse[key[i]];
                if (encrypt_key > 25)
                {
                    encrypt_key -= 26;
                }
                result += vigenere[encrypt_key];
            }
            return result;
        }


        static string Vigenere_decrypt(string message, string key)
        {

            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                
                int decrypt_number = (vigenere_reverse[message[i]] - vigenere_reverse[key[i]]) + 26;
                if (decrypt_number > 25)
                {
                    decrypt_number -= 26;
                }
                result += vigenere[decrypt_number];

            }
            return result;
        }
    }
}
