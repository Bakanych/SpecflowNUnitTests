using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SpecflowNUnitTests
{
    [Binding]
    public class Steps
    {
        static ThreadLocal<long> threadId = new ThreadLocal<long>(
            () => { return Thread.CurrentThread.ManagedThreadId; });

        FeatureContext featureContext;
        ScenarioContext scenarioContext;
        public Steps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void OneTimeSetup(FeatureContext context)
        {
            context.Set(threadId.Value);
        }
        [BeforeScenario]
        public void Set()
        {
            AssertThread(featureContext);
        }

        [AfterScenario]
        public void Get()
        {
            AssertThread(featureContext);
        }

        [AfterFeature]
        public static void OneTimeTearDown(FeatureContext context)
        {
            AssertThread(context);

        }

        [Given(@"Test")]
        public void GivenTestIsPassed()
        {
            AssertThread(featureContext);
        }

        private static void AssertThread(FeatureContext context)
        {
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId, context.Get<long>());
        }
    }
}
