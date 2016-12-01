using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create string of English alphabet and new Cypher object.
            string English = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string testString = "BABAC";
            Cipher EnglishCipher = new Cipher(English);
            EnglishCipher.offset = -1;
            string encrypted = EnglishCipher.Encrypt(testString);
            Console.WriteLine(encrypted);
            Console.WriteLine(EnglishCipher.Decrypt(encrypted));
            Console.ReadLine();

            
        }
    }

   public class Cipher
    {
        string falphabet;
        private int foffset;
        public int offset
        {
            get
            {
                return foffset;
            }
            set
            {
                foffset = value;
                while (foffset < 0)
                {
                    foffset += falphabet.Length;
                }
            }
        }
        public Cipher(string alphabet)
        {
            falphabet = alphabet;
        }

        /* keep in case offset needs to become truly a method.
       //method to set offset for ciphering 
        public string OffsetBy(int offset)
        {
            string result = string.Empty;
            char[] offsetabet = falphabet.ToCharArray();
            while (offset < 0)
            {
                offset += offsetabet.Length;
            }

            for (int i = 0; i < offsetabet.Length; i++)
            {
                int shiftedIndex = (i + offset) % offsetabet.Length; 
                result += offsetabet[shiftedIndex];
            }  
            return result; 
        } */

         //method to cipher a a string with the given alphabet and current ofset
        public string Encrypt(string message)
        {
            string result = string.Empty;
            char[] messageChars = message.ToCharArray();
            for (int i=0; i < messageChars.Length; i++)
            {
                // Gets index of character[i] in the alphabet field.
                int indexInAlphabet = falphabet.IndexOf(messageChars[i]);

                // Shifts index by offset and gets resulting char
                int shiftedIndex = (indexInAlphabet + offset) % falphabet.Length;
                //append char to new string.
                result += falphabet[shiftedIndex];
            }
            return result;
        }

       
        //method to decipher the string with the given alphabet and current offset.
        public string Decrypt(string encryptedMessage)
        {
            string result = string.Empty;
            char[] messageChars = encryptedMessage.ToCharArray();
            for (int i=0; i < messageChars.Length; i++)
            {
                int shiftedIndexInAlphabet = falphabet.IndexOf(messageChars[i]);
                int trueIndex = (shiftedIndexInAlphabet - offset) % falphabet.Length;
                //handels cases where index returns -.
                if (trueIndex < 0)
                {
                    trueIndex = trueIndex * -1;
                }
                result += falphabet[trueIndex]; 
            }
            return result;
        }
    }
}
