using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace PsLinedFile
{
    [Cmdlet(VerbsCommon.New, "Item")]
    public class n2 : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject("Split-LinedFile");
        }
    }
}
