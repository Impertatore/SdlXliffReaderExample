using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SdlXliffReader.Core
{
    public class ProcessorOptions
    {
        public SourceToTargetHandler SourceToTargetCopier { get; set; }
    }

    public class SourceToTargetHandler
    {
        public bool CopySourceToTaret { get; set; }
        public bool Preserve { get; set; }
    }    
}
