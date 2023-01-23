using SnjTextLib.Classes;

namespace SnjTextLib.Abstract
{
    interface IProcessorFactory
    {
        IProcessorConfig DefaultConfig { get; }
        ITextProcessor? CreateProcessor<T>(IProcessorConfig config)
            where T : class, ITextProcessor;
    }
}
