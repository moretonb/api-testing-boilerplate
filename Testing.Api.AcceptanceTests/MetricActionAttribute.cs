using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Testing.Api.AcceptanceTests
{
    public class MetricActionAttribute : Attribute, ITestAction
    {
        private readonly Stopwatch _stopwatch;

        public ActionTargets Targets => ActionTargets.Suite;

        public MetricActionAttribute()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void BeforeTest(ITest test)
        {
            _stopwatch.Start();
        }

        public void AfterTest(ITest test)
        {
            _stopwatch.Stop();

            var statName = $"{test.FullName}.{TestContext.CurrentContext.Result.Outcome.Status}".ToLower();

            StatsdSingleton.Publisher.Timing(_stopwatch.Elapsed, statName);
        }
    }
}