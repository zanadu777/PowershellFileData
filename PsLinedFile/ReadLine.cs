using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.Remoting.Messaging;

namespace PsLinedFile
{
    [Cmdlet( VerbsCommunications.Read, "Line")]
    public class ReadLine : PSCmdlet
    {



        [Parameter] public string[] File { get; set; }

        [Parameter] public int HeaderLines { get; set; } = 1;

        [Parameter] public int FooterLines { get; set; } = 0;


        protected override void ProcessRecord()
        {   WriteVerbose("Header");
            foreach (var file in File)
            {
                if (HeaderLines == 1)
                {
                    var h = FileHelpers.TextFileHelpers.GetFirstLine(file);
                    WriteObject(h);
                }else if (HeaderLines > 1)
                {
                    var hs = FileHelpers.TextFileHelpers.GetFirstLines(file, HeaderLines);
                    foreach (var h in hs)
                        WriteObject(h);
                }
                WriteVerbose("Footer");
                if (FooterLines == 1)
                {
                    var h = FileHelpers.TextFileHelpers.GetLastLine(file);
                    WriteObject(h);
                }
                else if (FooterLines > 1)
                {
                    var hs = FileHelpers.TextFileHelpers.GetLastLines(file, FooterLines);
                    foreach (var h in hs)
                        WriteObject(h);
                }
            }
        }
    }
}
