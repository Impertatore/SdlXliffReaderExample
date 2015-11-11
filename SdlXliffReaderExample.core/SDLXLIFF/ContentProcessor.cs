using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace SdlXliffReaderExample.Core.SDLXLIFF
{
    public class ContentProcessor : IBilingualContentProcessor
    {

      
        internal List<SegmentExampleClass> SegmentListExample { get; set; }
        
        #region  |  Content Generator  |
        private ContentGenerator _contentGeneratorProcessor;

        internal ContentGenerator ContentGeneratorProcessor
        {
            get
            {
                if (_contentGeneratorProcessor == null)
                {
                    _contentGeneratorProcessor = new ContentGenerator();
                }
                return _contentGeneratorProcessor;
            }
        }
        #endregion

        #region  |  IBilingualContentProcessor Members  |


        public ContentProcessor()
        {
            
           
        }


        public IBilingualContentHandler Output
        {
            get;
            set;
        }

        #endregion

        #region  |  IBilingualContentHandler Members  |




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
         
            //not needed for this implementation
        }

        public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {

            //Example
            foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
            {

                ContentGeneratorProcessor.GetPlainText(segmentPair.Source, true);
                string sourceText = ContentGeneratorProcessor.PlainText.ToString();

                ContentGeneratorProcessor.GetPlainText(segmentPair.Target, true);
                string targetText = ContentGeneratorProcessor.PlainText.ToString();


                SegmentListExample.Add(new SegmentExampleClass(segmentPair.Properties.Id.Id, sourceText, targetText));

            }

        }

        
        public void SetFileProperties(IFileProperties fileInfo)
        {
            // Not required for this implementation.
        }

        #endregion

       
    }  
}
