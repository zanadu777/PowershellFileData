using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers
{
    public static class TextFileHelpers
    {
        public static long GetLineCount(string path)
        {
            var lineCount = 0;
            using (var reader = System.IO.File.OpenText(path))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }


        public static string[] GetFirstLines(string path, int numberOfLines)
        {
            List<string> lines = new List<string>();
            using (var reader = System.IO.File.OpenText(path))
            {
                string current;
                while ((current = reader.ReadLine()) != null)
                {
                    lines.Add(current);
                    if (lines.Count > numberOfLines)
                        break;
                }
            }

            return lines.ToArray();
        }

        public static string[] GetLastLines(string path, int numberOfLines)
        {
            var lines = new Queue<string>();
            using (var reader = System.IO.File.OpenText(path))
            {
                string current;
                while ((current = reader.ReadLine()) != null)
                {
                    lines.Enqueue(current);
                    if (lines.Count > numberOfLines)
                        lines.Dequeue();
                }
            }

            return lines.ToArray();
        }


        public static string GetFirstLine(string path )
        {
           
            using (var reader = System.IO.File.OpenText(path))
            {
                var line = reader.ReadLine();

                return line ?? string.Empty;
            }
            
        }

        public static string GetLastLine(string path)
        {
            var last = string.Empty;
            using (var reader = System.IO.File.OpenText(path))
            {
                string current;
                while ((current = reader.ReadLine()) != null)
                    last = current ;
            }
            return last;
        }

    }
}
