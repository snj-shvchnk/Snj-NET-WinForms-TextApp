using SnjTextLib.Abstract;
using System.Collections;
using System.Linq;

namespace SnjTextLib.Base
{
    internal abstract class WordCalculatorBase : ConfigProvider, IWordCalculator
    {
        internal WordCalculatorBase(IProcessorConfig config) : base(config) { }

        public abstract IDictionary<string, int> Calculate(IEnumerable<string> values);

        internal IEqualityComparer<string> EqualityComparer =>
            StringComparer.FromComparison(Config.CompareOptions);
    }
}
