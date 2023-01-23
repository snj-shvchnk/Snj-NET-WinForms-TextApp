using SnjTextLib.Abstract;
using System.Text;

namespace SnjTextLib.Base
{
    internal abstract class FileReaderBase : TextProcessorBase
    {
        internal FileReaderBase(
            IProcessorConfig config,
            ITextSpliter spliter,
            IWordCalculator calculator
        ) : base(config, spliter, calculator) { }

        public IEnumerable<string> ReadWord(StreamReader reader)
        {
            char c;
            int charCode;
            StringBuilder word = new();
            while (reader.Peek() >= 0 || word.Length > 0)
            {
                charCode = reader.Read();
                c = (char)charCode;

                if (charCode == -1 
                    || char.IsWhiteSpace(c) 
                    || Config.WordsSeparator.Equals(c))
                {
                    var wordString = word.ToString();
                    if (Spliter.CheckWord(wordString))
                        yield return wordString;
                    
                    word.Clear();
                }
                else
                    word.Append(c);
            }
        }
    }
}
