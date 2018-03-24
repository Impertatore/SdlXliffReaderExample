using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.LanguagePlatform.Core;

namespace SdlXliffReader.Core.Model
{
    /// <summary>
    /// Simple class to manage the segmentPair content
    /// </summary>
    public class SegmentInfo
    {
        public string SegmentId { get; set; }

        public string ParagraphId { get; set; }

        public ISegmentPair SegmentPair { get; set; }

        public Segment SourceSegment { get; set; }

        public Segment TargetSegment { get; set; }

        public WordCounts SourceWordCounts { get; set; }
    }
}
