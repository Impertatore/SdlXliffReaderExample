using System;
using System.Collections.Generic;
using System.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using SdlXliffReader.Core.Model;
using SdlXliffReader.Core.Tokenization;

namespace SdlXliffReader.Core.Reader
{
    public class ParagraphProcessor : IBilingualContentProcessor
    {
        private Tokenizer _tokenizer { get; set; }

        public Tokenizer Tokenizer
        {
            get
            {
                if (_tokenizer != null)
                {
                    return _tokenizer;
                }

                if (SourceLanguage == null || TargetLanguage == null)
                {
                    throw new Exception(
                        $"Unable to parse the file; {(SourceLanguage == null ? "Source" : "Target")} langauge cannot be null!");
                }

                _tokenizer = new Tokenizer(SourceLanguage, TargetLanguage);
                _tokenizer.CreateTranslationMemory();

                return _tokenizer;
            }
        }

        internal List<SegmentInfo> Segments { get; set; }

        internal CultureInfo SourceLanguage { get; private set; }

        internal CultureInfo TargetLanguage { get; private set; }

        public IBilingualContentHandler Output
        {
            get;
            set;
        }

        public void Complete()
        {
            //not needed for this implementation
        }

        public void FileComplete()
        {
            // Not required for this implementation.
        }

        public void Initialize(IDocumentProperties documentInfo)
        {
            SourceLanguage = documentInfo.SourceLanguage?.CultureInfo;
            TargetLanguage = documentInfo.TargetLanguage?.CultureInfo;
        }

        public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            foreach (var segmentPair in paragraphUnit.SegmentPairs)
            {
                var result = Tokenizer.TokenizeSegment(segmentPair);

                if (result == null)
                {
                    continue;
                }

                Segments.Add(new SegmentInfo
                {
                    ParagraphId = paragraphUnit.Properties.ParagraphUnitId.Id,
                    SegmentId = segmentPair.Properties.Id.Id,
                    SegmentPair = segmentPair,
                    TokenizedSegment = result
                });
            }
        }

        public void SetFileProperties(IFileProperties fileInfo)
        {
            // Not required for this implementation.
        }
    }
}
