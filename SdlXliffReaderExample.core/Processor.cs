using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlXliffReaderExample.Core.SDLXLIFF;

namespace SdlXliffReaderExample.Core
{
    public class Processor
    {

        public delegate void ChangedEventHandler(int Maximum, int Current, int Percent, string Message);
        public event ChangedEventHandler Progress;

        #region  |  read SDLXLIFF file  |


        public List<SegmentExampleClass> readSdlXliffFile(string sdlXliffFilePath)
        {
            try
            {
                Parser SdlXliffParser = new Parser();
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
