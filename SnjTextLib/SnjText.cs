using SnjTextLib.Abstract;
using SnjTextLib.Base;
using SnjTextLib.Classes;
using SnjTextLib.Processors;

namespace SnjTextLib
{
    public static class SnjText
    {
        static SnjText()
        {
            Config = new ProcessorConfig();
            Factory = new ProcessorFactory(Config);
        }

        public static ITextProcessor TextProcessor(IProcessorConfig config = null)
            => Factory.CreateProcessor<TextProcessor>(config ?? Config);

        public static ITextProcessor FileProcessor(IProcessorConfig config = null)
            => Factory.CreateProcessor<FileProcessor>(config ?? Config);

        public static IProcessorConfig Config { get; private set; }
        internal static IProcessorFactory Factory { get; private set; }
    }
}
