using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlXliffReaderExample.Core.SDLXLIFF
{
    //create something like this type of class to encapsulate everything from the processor 
    //Note: try not to leave simple variables lying around in your code; it is clearer and easier to maintain when everything is structured
    //Patrick Hartnett 18/01/2012
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
