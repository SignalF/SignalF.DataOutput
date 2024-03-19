#region

#endregion

using SignalF.Controller.DataOutput;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;
using SignalF.Configuration;

namespace SignalF.DataOutput.Console;

public class DataOutputSenderConsole : DataOutputSender, IDataOutputSenderConsole
{
    private DataOutputSenderConsoleOptions? _options;
    public DataOutputSenderConsole(ISignalHub signalHub) : base(signalHub)
    {
    }

    public override void SendValues(Signal[] values)
    {
        Queue.Enqueue(values);
    }

    protected override void DoConfigure(IDataOutputSenderConfiguration configuration)
    {
        _options = configuration.Configuration.Get<DataOutputSenderConsoleOptions>();
    }

    protected override Task ProcessValuesAsync(Signal[] signals)
    {

        if (signals.All(value => value.SignalIndex == -1))
        {
            // No values to send.
            return Task.CompletedTask;
        }

        foreach (var signal in signals)
        {
            // Values start with signal index "0". An signal index of "-1" is the timestamp.
            if (signal.SignalIndex == -1)
            {
                if (_options?.ShowTimestamp == true)
                {
                    System.Console.WriteLine($"Timestamp: {signal.Timestamp:O}");
                }
            }
            else
            {
                System.Console.WriteLine($"Index {signal.SignalIndex:00} Value: {signal.Value}");
            }
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
