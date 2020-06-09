using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Utilities
{
    public static class ShortUrlGenerator
    {
        // List of characters and numbers to be used 
        private static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        private static List<char> characters = new List<char>()
    {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
    'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    'Q', 'R', 'S',  'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_'};
        
        public static string generateShortUrl()
        {
            // decalre url var
            string URL = "";

            //create random obj
            Random rand = new Random();

            //create random 7 digit url
            for (int i = 0; i < 7; i++)
            {
                int random = rand.Next(0, 3);
                if (random == 1)
                {
                    // use a number  
                    random = rand.Next(0, numbers.Count);
                    URL += numbers[random].ToString();
                }
                else
                {
                    // use character
                    random = rand.Next(0, characters.Count);
                    URL += characters[random].ToString();
                }
            }

            return URL;
        }
    }
}