using SignalF.Configuration.DataOutput;

namespace SignalF.DataOutput.Console;

public class ConsoleDataOutputSenderOptions : DataOutputSenderOptions
{
    public bool ShowTimestamp { get; set; }
}