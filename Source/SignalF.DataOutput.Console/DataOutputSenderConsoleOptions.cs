using SignalF.Controller.Configuration;

namespace SignalF.DataOutput.Console;

public class DataOutputSenderConsoleOptions : SignalFConfigurationOptions
{
    public bool ShowTimestamp { get; set; }
}