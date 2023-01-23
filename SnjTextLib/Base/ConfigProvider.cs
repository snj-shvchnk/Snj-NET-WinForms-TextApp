using SnjTextLib.Abstract;
namespace SnjTextLib.Base
{
    internal class ConfigProvider
    {
        protected internal ConfigProvider(IProcessorConfig? config)
        {
            Config = config ?? new ProcessorConfig();
        }

        protected IProcessorConfig Config { get; private set; }
    }
}
