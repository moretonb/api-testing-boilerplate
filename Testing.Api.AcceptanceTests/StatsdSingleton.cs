using System;
using JustEat.StatsD;

namespace Testing.Api.AcceptanceTests
{
    public sealed class StatsdSingleton
    {
        private static readonly Lazy<StatsdSingleton> Lazy =
            new Lazy<StatsdSingleton>(() => new StatsdSingleton());

        private static StatsdSingleton Instance => Lazy.Value;

        private readonly StatsDPublisher _publisher;
        public static StatsDPublisher Publisher => Instance._publisher;

        private StatsdSingleton()
        {
            var statsDConfig = new StatsDConfiguration
            {
                Host = Environment.GetEnvironmentVariable("StatsdHost") ?? "localhost"
            };

            _publisher = new StatsDPublisher(statsDConfig);
        }
    }
}