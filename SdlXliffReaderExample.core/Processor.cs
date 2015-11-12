using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.FileTypeSupport.Framework.Core.Utilities.IntegrationApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using SdlXliffReaderExample.Core.SDLXLIFF;

namespace SdlXliffReaderExample.Core
{
    public class Processor
    {
        private readonly IFileTypeManager _fileTypeManager;
        public Processor():this(DefaultFileTypeManager.CreateInstance(true))
        {
            
        }

        public Processor(IFileTypeManager fileTypeManager)
        {
            _fileTypeManager = fileTypeManager;
        }

        public delegate void ChangedEventHandler(int Maximum, int Current, int Percent, string Message);
        public event ChangedEventHandler Progress;

        #region  |  read SDLXLIFF file  |


        public List<SegmentExampleClass> readSdlXliffFile(string sdlXliffFilePath)
        {
            try
            {
                Parser SdlXliffParser = new Parser(_fileTypeManager);
                try
                {
                    //do stuff here (settings etc...)
                    return SdlXliffParser.openReadSdlXliffExample(sdlXliffFilePath);                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    SdlXliffParser.Progress -= new Parser.ChangedEventHandler(parser_Progress);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion

        #region  |  progress callbacks  |

  
        private void parser_Progress(int Maximum, int Current, int Percent, string Message)
        {
            if (Progress != null)
                Progress(Maximum, Current, Percent, Message);
        }

        #endregion
    }
}
