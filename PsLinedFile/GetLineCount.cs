using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using FileHelpers;

namespace PsLinedFile
{
    [Cmdlet(VerbsCommon.Get, "LineCount")]
    public class GetLineCount : PSCmdlet
    {

        [Parameter] public string[] File { get; set; }

        protected override void ProcessRecord()
        {

            foreach (var file in File )
            {
                Stopwatch swatch = Stopwatch.StartNew();

                var lineCount = TextFileHelpers.GetLineCount(file);


                WriteObject(lineCount);
                WriteVerbose($"Counted in {swatch.Elapsed.TotalSeconds} seconds");
            }
        }
    }
}
