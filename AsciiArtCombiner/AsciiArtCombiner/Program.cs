using AsciiArtCombinerLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsciiArtCombiner
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if (args.Length <= 2)
            {
                writeError("No file specified");
                return 1;
            }
            else if (args.Length <= 3)
            {
                writeError("Only one file specified");
                return 1;
            }

            string[] text1;
            try
            {
                text1 = await System.IO.File.ReadAllLinesAsync(args[2]);
            }
            catch
            {
                writeError(args[2] + " is invalid");
                return 1;
            }

            for(int i = 3; i < args.Length; i++)
            {
                string[] text2;
                try
                {
                    text2 = await System.IO.File.ReadAllLinesAsync(args[i]);
                }
                catch
                {
                    writeError(args[i] + " is invalid");
                    return 1;
                }

                if(!checkText(text1, text2))
                {
                    writeError("Files do not have equal sizes");
                    return 1;
                }

                text1 = new AsciiCombiner().CombineAscii(text1, text2);
            }

            for(int i = 0; i < text1.Length; i++)
            {
                Console.WriteLine(text1[i]);
            }

            return 0;
        }

        public static bool checkText(string[] text1, string[] text2)
        {
            if(text1.Length != text2.Length)
            {
                return false;
            }

            var len = text1.Length;
            for(int i = 0; i < text1.Length; i++)
            {
                if(text1[i].Length != text2[i].Length || text1.Length != len)
                {
                    return false;
                }
            }

            return true;
        }

        public static void writeError(string error)
        {
            Console.WriteLine("Error: " + error);
        }
    }
}
