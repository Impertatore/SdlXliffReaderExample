using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlXliffReaderExample.Core.SDLXLIFF
{
    /// <summary>
    /// Simple class to manage the segmentPair content
    /// </summary>
    public  class SegmentExampleClass
    {
        
        public string segmentId { get; set; }
        public string sourceText { get; set; }
        public string targetText { get; set; }
     
        public SegmentExampleClass()
        {
            segmentId = string.Empty;
            sourceText = string.Empty;
            targetText = string.Empty;
         
        }
        public SegmentExampleClass(string _segmentId, string _sourceText, string _targetText)
        {
            segmentId = _segmentId;
            sourceText = _sourceText;
            targetText = _targetText;
    
        }
    }
}
