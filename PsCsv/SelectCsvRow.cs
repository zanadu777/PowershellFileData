using System;
using System.Collections.Generic;
using System.Management.Automation;
using FileHelpers;

namespace PsCsv
{
    [Cmdlet(VerbsCommon.Select, "CsvRow")]
    public class SelectCsvRow : PSCmdlet
    {
        [Parameter]
        public string SourcePath { get; set; }
        [Parameter]
        public string DestinationPath { get; set; }
        [Parameter]
        public string Field { get; set; }

        [Parameter]
        public string[] Values { get; set; }


        protected override void ProcessRecord()
        {
            var filter = new CsVFilter(SourcePath, DestinationPath);
            filter.FilterFieldByValues(Field, Values);
        }

    }
}
