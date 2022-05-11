using System;
using System.Collections.Generic;
using System.Management.Automation;
using FileHelpers;

namespace PsCsv
{
    [Cmdlet(VerbsCommunications.Read, "CsvColumn")]
    public class ReadCsvColumn : PSCmdlet
    {
        [Parameter]
        public string File { get; set; }

        [Parameter(Mandatory = true)]
        public string Column { get; set; }


        [Parameter] public char Delimiter { get; set; } = ',';

        protected override void ProcessRecord()
        {
            var firstLine = TextFileHelpers.GetFirstLine(File);
            var columns = CsvHelpers.GetColumns(firstLine, Delimiter);


        }
    }
}
