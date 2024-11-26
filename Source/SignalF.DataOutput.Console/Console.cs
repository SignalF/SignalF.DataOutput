using System.Collections;
using SignalF.Configuration;
using SignalF.Configuration.Integration;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;

namespace SignalF.DataOutput.Console;

[DataOutputSender]
public class Console : DataOutputSender, IConsole
{
    private ConsoleOptions? _options;

    public Console(ISignalHub signalHub) : base(signalHub)
    {
    }

    public override void SendValues(Signal[] values)
    {
        Queue.Enqueue(values);
    }

    protected override void DoConfigure(IDataOutputSenderConfiguration configuration)
    {
        _options = configuration.Configuration.Get<ConsoleOptions>();
    }

    protected override Task ProcessValuesAsync(Signal[] signals)
    {
        if (signals.All(value => value.SignalIndex == -1))
        {
            // No values to send.
            return Task.CompletedTask;
        }

        foreach (var signal in signals)
            // Values start with signal index "0". A signal index of "-1" is the timestamp.
            if (signal.SignalIndex == -1)
            {
                if (_options?.ShowTimestamp == true)
                {
                    var timestamp = new DateTime(signal.Timestamp.GetValueOrDefault());
                    System.Console.WriteLine($"Cycle timestamp: {timestamp:yyyy-MM-dd hh:mm:ss.ffffff}");
                }
            }
            else
            {
                //TODO: Add automatic unit conversion. 
                // Values are kept in SI units. They should be converted to the 
                // configured unit.
                System.Console.WriteLine(
                    $"Signal: {GetSignalNameFromIndex(signal.SignalIndex)}, Value: {signal.Value}");
            }

        return Task.CompletedTask;
    }

    internal struct JsonValue
    {
        public double Timestamp;
        public string ProcedureId; // TODO: Really needed? We could also have something like a device id.
        public readonly List<KeyValuePair<Guid, double>> Values;

        public JsonValue(double timestamp, string procedureId)
        {
            Timestamp = timestamp;
            ProcedureId = procedureId;
            Values = new List<KeyValuePair<Guid, double>>();
        }
    }
}