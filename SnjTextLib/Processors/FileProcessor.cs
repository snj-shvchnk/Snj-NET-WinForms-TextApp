using SnjTextLib.Abstract;
using SnjTextLib.Base;

namespace SnjTextLib.Processors
{
    internal class FileProcessor : FileReaderBase, ITextProcessor
    {
        public FileProcessor(
            IProcessorConfig config, 
            ITextSpliter spliter, 
            IWordCalculator calculator
        ) : base(config, spliter, calculator) { }

        public override IDictionary<string, int> Process(string filename)
        {
            IDictionary<string, int> result;
            using (StreamReader reader = new(filename))
            {
                result =
                    Calculator.Calculate(
                        ReadWord(reader)
                    );
            }
            return result;
        }
    }
}
