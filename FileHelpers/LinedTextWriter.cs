using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers
{
    public class LinedTextWriter:IDisposable
    {
        private TextWriter writer;
        private long maxlines;
        private int totalLines;
        private List<string> footer;
        public LinedTextWriter(string path,long maxlines, IEnumerable<string> header , IEnumerable<string> footer )
        {
            writer = new StreamWriter(path);
            this.maxlines = maxlines;
            if (footer != null)
            {
                this.footer =  footer.ToList();
                this.totalLines = this.footer.Count;
            }

            if (header != null)
            {
                foreach (var h in header)
                {
                    writer.WriteLine(h);
                    totalLines++;
                }

            }
        }

        public bool CanWrite => totalLines < maxlines;

        public long WriteLine(string line)
        {
            if (totalLines < maxlines)
            {
                writer.WriteLine(line);
                totalLines++;
                return totalLines;
            }
            return -1;

        }

        public void Close()
        { if (footer != null)
            {
                foreach (var f in footer)
                {
                    writer.WriteLine(f);
                }
            }
            Dispose();
        }

        public void Dispose()
        {
            writer?.Dispose();
        }
    }
}
 