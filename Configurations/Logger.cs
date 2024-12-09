
namespace the_webapi.Configurations
{
    internal class Logger:ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            Console.WriteLine($"BeginScope: {state}");
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            Console.WriteLine($"IsEnabled: {logLevel}");
            return true;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"[{logLevel}] {formatter(state, exception)}");
        }
    }
}