using SnjTextLib.Abstract;

namespace SnjTextLib.Base
{
    internal abstract class TextProcessorBase : ConfigProvider
    {
        internal TextProcessorBase(
            IProcessorConfig config,
            ITextSpliter spliter,
            IWordCalculator calculator
        ) : base(config) {
            Spliter = spliter;
            Calculator = calculator;
        }

        internal ITextSpliter Spliter { get; private set; }
        internal IWordCalculator Calculator { get; private set; }
        public abstract IDictionary<string, int> Process(string text);
    }
}
