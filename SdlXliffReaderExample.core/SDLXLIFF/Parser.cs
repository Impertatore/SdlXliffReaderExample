using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
using System.IO;
using Sdl.FileTypeSupport.Framework.Core.Utilities.IntegrationApi;

namespace SdlXliffReaderExample.Core.SDLXLIFF
{
    internal class Parser
    {

        internal delegate void ChangedEventHandler(int Maximum, int Current, int Percent, string Message);
        internal event ChangedEventHandler Progress;


        private readonly IFileTypeManager _fileTypeManager;
        internal Parser(IFileTypeManager fileTypeManager)
        {
            _fileTypeManager = fileTypeManager;
        }


        internal List<SegmentExampleClass> openReadSdlXliffExample(string filePath)
        {

            IMultiFileConverter converter = _fileTypeManager.GetConverterToDefaultBilingual(filePath, filePath + "_.sdlxliff", null);

            SDLXLIFF.ContentProcessor contentProcessor = new SDLXLIFF.ContentProcessor();
            contentProcessor.SegmentListExample = new List<SegmentExampleClass>();

            //converter.AddBilingualProcessor(new SourceToTargetCopier(ExistingContentHandling.Preserve));
            converter.AddBilingualProcessor(contentProcessor);
            try
            {
                converter.Progress += new EventHandler<BatchProgressEventArgs>(converter_Progress);
                
                
                converter.Parse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                converter.Progress -= new EventHandler<BatchProgressEventArgs>(converter_Progress);
            }

            return contentProcessor.SegmentListExample;
        }


        private void converter_Progress(object sender, BatchProgressEventArgs e)
        {
            if (Progress != null)
            {
                Progress(100, e.FilePercentComplete, e.FilePercentComplete, Path.GetFileName(e.FilePath));
            }
        }
    }
}
