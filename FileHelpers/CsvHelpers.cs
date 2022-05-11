using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers
{
    public static class CsvHelpers
    {
        public static Dictionary<string, int> GetColumns(string header, char delimiter)
        {
            var fields = new Dictionary<string, int>();
            var parts = header.Split(delimiter);
            for (int i = 0; i < parts.Length; i++)
                fields[parts[i].Trim().ToUpper()] = i;

            return fields;
        }

     
    }
}
