using SnjTextLib.Abstract;
using SnjTextLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnjTextLib.Classes
{
    internal class WordCalculator : WordCalculatorBase, IWordCalculator
    {
        internal WordCalculator(IProcessorConfig config) : base(config) { }

        public override IDictionary<string, int> Calculate(IEnumerable<string> words)
        {
            Dictionary<string, int> result = new (EqualityComparer);
            foreach (var item in words)
            {
                int qty;
                if (!result.TryGetValue(item, out qty)) qty = 0;
                result[item] = (qty + 1);
            }

            return result;
        }
    }
}
