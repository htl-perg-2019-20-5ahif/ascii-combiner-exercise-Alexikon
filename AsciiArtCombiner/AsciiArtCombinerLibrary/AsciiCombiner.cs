using System;
using System.Collections.Generic;

namespace AsciiArtCombinerLibrary
{
    public class AsciiCombiner
    {
        public string[] CombineAscii(string[] text1, string[] text2)
        {
            var chAr1 = new char[text1.Length][];
            var chAr2 = new char[text2.Length][];
            var combinedAscii = new string[text1.Length];

            for(var i = 0; i < text1.Length; i++)
            {
                chAr1[i] = text1[i].ToCharArray();
                chAr2[i] = text2[i].ToCharArray();

                for (int j = 0; j < text1[i].Length; j++)
                {
                    if(chAr2[i][j] != ' ')
                    {
                        chAr1[i][j] = chAr2[i][j];
                    }
                }

                combinedAscii[i] = new string(chAr1[i]);
            }

            return combinedAscii;
        }
    }
}
