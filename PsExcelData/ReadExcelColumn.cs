using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ClosedXML.Excel;

namespace PsExcelData
{
    [Cmdlet(VerbsCommunications.Read, "ExcelColumn")]
    public class ExcelColumn : PSCmdlet
    {

        [Parameter]
        public string File { get; set; }


        [Parameter]
        public int Worksheet { get; set; } = 1;

        [Parameter(Mandatory = true)]
        public string Column { get; set; }

        [Parameter]
        public SwitchParameter Unique { get; set; }

        protected override void ProcessRecord()
        {
            var workbook = new XLWorkbook(File);
            var ws = workbook.Worksheet(Worksheet);

            var columnNames = ColumnNames(ws);

            if (!columnNames.Contains(Column))
            {
                WriteObject($"Column {Column} is not present in the worksheet");
                return;
            }

            var colIndex = columnNames.IndexOf(Column)+1;
            var columnValues = new List<string>();
            for (int iRow = 1; iRow <= ws.Rows().Count(); iRow++)
            {
                var value = ws.Cell(iRow, colIndex).Value;
                columnValues.Add(value.ToString());
            }

            if (Unique.IsPresent)
            {
                WriteObject(columnValues.Distinct());
            }
            else
            {
                WriteObject(columnValues);
            }
            
        }


        private List<string> ColumnNames(IXLWorksheet ws)
        {
            var names = new List<string>();
            for (int iCol = 1; iCol <= ws.Columns().Count(); iCol++)
            {
                var value = ws.Cell(1, iCol).Value;
                names.Add(value.ToString());
            }
            return names;
        }
    }
}
