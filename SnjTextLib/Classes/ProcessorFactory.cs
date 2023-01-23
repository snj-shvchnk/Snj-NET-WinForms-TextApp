using SnjTextLib.Abstract;
using SnjTextLib.Base;
using SnjTextLib.Processors;

namespace SnjTextLib.Classes
{
    internal class ProcessorFactory : ConfigProvider, IProcessorFactory
    {
        public ProcessorFactory(IProcessorConfig config) : base(config) { }
        public IProcessorConfig DefaultConfig => Config;

        public ITextProcessor CreateProcessor<T>(IProcessorConfig config)
            where T : class, ITextProcessor
        {
            var spliter = new TextSpliter(config);
            var calculator = new WordCalculator(config);
            var parametrs = new object []{ config, spliter, calculator };

            return Activator.CreateInstance(typeof(T), parametrs) as ITextProcessor;
        }
    }
}
