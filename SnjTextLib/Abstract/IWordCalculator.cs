namespace SnjTextLib.Abstract
{
    interface IWordCalculator
    {
        IDictionary<string, int> Calculate(IEnumerable<string> values);
    }
}
