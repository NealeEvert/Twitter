using System;
using TechTalk.SpecFlow;

namespace Twitter.Console.Test.SpecFlow
{
    [Binding]
    public class TwitterPrinterSteps
    {
        [Given(@"I have a list of users and tweets")]
        public void GivenIHaveAListOfUsersAndTweets()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the tweets are in a specific order")]
        public void GivenTheTweetsAreInASpecificOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I print the twitter feed")]
        public void WhenIPrintTheTwitterFeed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the tweets are in the correct order")]
        public void ThenTheTweetsAreInTheCorrectOrder()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
