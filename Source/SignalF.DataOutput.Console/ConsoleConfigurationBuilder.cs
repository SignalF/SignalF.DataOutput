using SignalF.Configuration.DataOutput;
using SignalF.Datamodel.DataOutput;

namespace SignalF.DataOutput.Console;

public interface IConsoleDataOutputSenderConfigurationBuilder
    : IConsoleDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>
{
}

public interface IConsoleDataOutputSenderConfigurationBuilder<in TOptions>
    : IConsoleDataOutputSenderConfigurationBuilder<IConsoleDataOutputSenderConfigurationBuilder<TOptions>, IDataOutputSenderConfiguration, TOptions>
    where TOptions : ConsoleDataOutputSenderOptions
{
}

public interface IConsoleDataOutputSenderConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IConsoleDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : ConsoleDataOutputSenderOptions
{
}

public class ConsoleDataOutputSenderConfigurationBuilder
    : ConsoleDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>, IConsoleDataOutputSenderConfigurationBuilder
{
    protected override IConsoleDataOutputSenderConfigurationBuilder This => this;
}

public class ConsoleDataOutputSenderConfigurationBuilder<TOptions>
    : ConsoleDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderConfigurationBuilder<TOptions>, IConsoleDataOutputSenderConfigurationBuilder<TOptions>,
          IDataOutputSenderConfiguration,
          TOptions>, IConsoleDataOutputSenderConfigurationBuilder<TOptions>
    where TOptions : ConsoleDataOutputSenderOptions
{
    protected override IConsoleDataOutputSenderConfigurationBuilder<TOptions> This => this;
}

public abstract class ConsoleDataOutputSenderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DataOutputSenderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
      , IConsoleDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IConsoleDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ConsoleDataOutputSenderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : ConsoleDataOutputSenderOptions
{
}
