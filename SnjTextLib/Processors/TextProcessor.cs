using SnjTextLib.Abstract;
using SnjTextLib.Base;

namespace SnjTextLib.Processors
{
    internal class TextProcessor : TextProcessorBase, ITextProcessor
    {
        public TextProcessor(
            IProcessorConfig config, 
            ITextSpliter spliter, 
            IWordCalculator calculator
        ) : base(config, spliter, calculator){ }

        public override IDictionary<string, int> Process(string text)
        {
            var splitedByWords = Spliter.Split(text);
            var wordsStatistic = Calculator.Calculate(splitedByWords);
            return wordsStatistic;
        }
    }
}
