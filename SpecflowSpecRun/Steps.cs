using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowSpecRun
{
    [Binding]
    public class Steps
    {
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
            //throw new Exception(Thread.CurrentThread.ManagedThreadId.ToString());

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
        [BeforeScenario]
        public void Set()
        {
            Guid guid = Guid.NewGuid();
            scenarioContext.Set(guid);
            //throw new Exception(Thread.CurrentThread.ManagedThreadId.ToString());
        }

        [AfterScenario]
        public void Get()
        {
            Console.WriteLine(scenarioContext.Get<Guid>());
            //throw new Exception(Thread.CurrentThread.ManagedThreadId.ToString());
        }

        [Given(@"Test")]
        public void GivenTestIsPassed()
        {
            //Thread.Sleep(1000);
            //throw new Exception(Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
