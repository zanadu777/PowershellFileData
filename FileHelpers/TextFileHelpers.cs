using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers
{
    public static class TextFileHelpers
    {
        public static long GetLineCount(string path)
        {
            using var reader = File.OpenText(path);
            var lineCount = GetLineCount(reader);
            return lineCount;
        }

        public static long GetLineCount(StreamReader reader)
        {

            var lineCount = 0;
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }
            return lineCount;

        }


        public static string[] GetFirstLines(string path, int numberOfLines)
        {
            using var reader = File.OpenText(path);
            var lines = GetFirstLines(reader, numberOfLines);
            return lines;
        }

        public static string[] GetFirstLines(StreamReader reader, int numberOfLines)
        {
            List<string> lines = new List<string>();

            string current;
            while ((current = reader.ReadLine()) != null)
            {
                lines.Add(current);
                if (lines.Count > numberOfLines)
                    break;
            }
            
            return lines.ToArray();
        }


        public static string[] GetLastLines(string path, int numberOfLines)
        {
            using var reader = File.OpenText(path);
            var lines = GetLastLines(reader, numberOfLines);
            return lines;
        }

        public static string[] GetLastLines(StreamReader reader, int numberOfLines)
        {
            var lines = new Queue<string>();

                string current;
                while ((current = reader.ReadLine()) != null)
                {
                    lines.Enqueue(current);
                    if (lines.Count > numberOfLines)
                        lines.Dequeue();
                }
                
            return lines.ToArray();
        }

        public static string GetFirstLine(string path )
        {
            using var reader = File.OpenText(path);
            var line = GetFirstLine(reader);
            return line;

        }

        public static string GetFirstLine(StreamReader reader)
        {
            var line = reader.ReadLine();
            return line ?? string.Empty;
        }



        public static string GetLastLine(string path)
        {
            using  var reader = File.OpenText(path);
            var last = GetLastLine(reader);
            return last;
        }


        public static string GetLastLine(StreamReader reader)
        {
            var last = string.Empty;
          
            string current;
            while ((current = reader.ReadLine()) != null)
                last = current;

            return last;
        }

    }
}
