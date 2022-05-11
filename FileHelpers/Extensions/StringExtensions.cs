using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers.Extensions
{
    public static  class StringExtensions
    {
        public static  string Part(this string text, char deliminator, int pos)
        {
            var currentPos = 0;
            var posStart = 0;
            var posEnd = 0;
            var isPartFound = false;

            for (int i = 0;    i < text.Length;  i++)
            {
                if (text[i] == deliminator)
                    currentPos++;

                if (!isPartFound)
                {
                    if (currentPos == pos)
                    {
                        posStart = i;
                        isPartFound = true;
                    }
                }
                else
                    if (currentPos == pos + 1)
                    {
                        posEnd = i;
                        break;
                    }
            }

            return text.Substring(posStart + 1, posEnd - posStart -1).Trim();
        }
    }
}
