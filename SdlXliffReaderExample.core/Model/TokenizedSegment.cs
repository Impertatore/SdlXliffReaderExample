using Sdl.LanguagePlatform.Core;

namespace SdlXliffReader.Core.Model
{
    public class TokenizedSegment
    {
        public WordCounts SourceWordCounts { get; set; }

        public Segment SourceSegment { get; set; }

        public Segment TargetSegment { get; set; }
    }
}
