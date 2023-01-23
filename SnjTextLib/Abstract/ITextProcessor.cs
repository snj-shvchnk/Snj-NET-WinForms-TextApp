namespace SnjTextLib.Abstract
{
    public interface ITextProcessor
    {
        IDictionary<string, int> Process(string text);
    }
}