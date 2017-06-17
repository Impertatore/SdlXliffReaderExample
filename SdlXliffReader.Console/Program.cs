using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sdl.LanguagePlatform.Core.Tokenization;
using SdlXliffReader.Core;
using SdlXliffReader.Core.SDLXLIFF;

namespace SdlXliffReader.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // provide the file path of the sdlxliff file
            args = new[]
            {
                @"C:\Users\Patrick\Documents\Studio 2017\Projects\Project 1\de-DE\SecondSample.docx.sdlxliff"
            };

            ReadFile(args[0]);

            Console.ReadKey(false);
        }

        private static void ReadFile(string filePath)
        {
            var processor = new Processor();

            try
            {
                processor.ProgressEvent += ProcessorProgressEvent;

                var options = new ProcessorOptions
                {
                    SourceToTargetCopier = new SourceToTargetHandler
                    {
                        CopySourceToTaret = false,
                        Preserve = true
                    }
                };

                var segmentInfos = processor.ReadFile(filePath, options);

                if (segmentInfos == null)
                    return;

                foreach (var segmentInfo in segmentInfos)
                {
                    Console.WriteLine("Paragraph {0}: ", segmentInfo.ParagraphId);
                    Console.WriteLine("Segment {0}: ", segmentInfo.SegmentId);

                    Console.WriteLine();
                    Console.WriteLine("Source Segment");
                    Console.WriteLine("Text: {0}", segmentInfo.SourceSegment.ToPlain());
                    WriteTokens(segmentInfo.SourceSegment.Tokens);

                    Console.WriteLine();
                    Console.WriteLine("Target Segment");
                    Console.WriteLine("Text: {0}", segmentInfo.TargetSegment.ToPlain());
                    WriteTokens(segmentInfo.TargetSegment.Tokens);

                    Console.WriteLine();
                    Console.WriteLine("-".PadRight(40, '-'));
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                processor.ProgressEvent -= ProcessorProgressEvent;
            }
        }

        private static void WriteTokens(List<Token> tokens)
        {
            Console.WriteLine("Tokens: {0}", tokens.Count);

            foreach (var token in tokens)
            {
                if (string.IsNullOrEmpty(token.Text) || token.Type == TokenType.Whitespace)
                {
                    Console.WriteLine("    Type: {0}", token.Type);
                }
                else
                {
                    Console.WriteLine("    Type: {0}, Text: {1}", token.Type, token.Text);
                }
            }
        }

        private static void ProcessorProgressEvent(object sender, Core.EventArgs.ProgressEventArgs e)
        {
            // do something
        }


    }
}
