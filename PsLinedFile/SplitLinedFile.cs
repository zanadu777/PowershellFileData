using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using FileHelpers;

namespace PsLinedFile
{
    [Cmdlet(VerbsCommon.Split, "LinedFile")]
    public class SplitLinedFile : PSCmdlet
    {


        [Parameter]
        public string File { get; set; }

        [Parameter] public int Header { get; set; } = 1;

        [Parameter] public int Footer { get; set; } = 0;

        [Parameter(Mandatory = true)]
        public string Output { get; set; }

        protected override void ProcessRecord()
        {
            if (!Directory.Exists(Output))
                Directory.CreateDirectory(Output);

            if (!System.IO.File.Exists(File))
            {
                WriteObject($"{File} does not exist");
                return;
            }

            List<string> headerLines = new List<string>();
            if (Header == 1)
                headerLines.Add(FileHelpers.TextFileHelpers.GetFirstLine(File));
            else if (Header > 1)
                headerLines.AddRange(FileHelpers.TextFileHelpers.GetFirstLines(File,Header));


            List<string> footerLines = new List<string>();
            if (Footer == 1)
                footerLines.Add(FileHelpers.TextFileHelpers.GetLastLine(File));
            else if (Header > 1)
                footerLines.AddRange(FileHelpers.TextFileHelpers.GetLastLines(File, Footer));


            long currentLine = 0;
            var currentOutputFile = 0;
            LinedTextWriter writer = null;
            using (var reader = System.IO.File.OpenText(File))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    currentLine ++;
                    if (currentLine <= Header)
                        continue;

                    if (writer == null)
                    {
                        var currentFile = $"{Path.GetFileNameWithoutExtension(File)}_{currentOutputFile}{Path.GetExtension(File)}" ;
                        var outPath = System.IO.Path.Combine(Output, currentFile);
                        writer = new LinedTextWriter(outPath, 100000, headerLines, footerLines);
                    }

                    if (writer.CanWrite)
                        writer.WriteLine(line);

                    if (!writer.CanWrite)
                    {
                        writer.Close();
                        writer = null;
                        currentOutputFile++;
                    }
                }

                if (writer != null) 
                    writer.Close();
            }
 
        }
    }
}
