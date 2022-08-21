using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SignInFailureStepDefinitions
    {
        IWebDriver driver;

        public readonly string workingEmailAddress = "workingtestexample@gmail.com";
        public readonly string workingPassword = "12345";

        [When(@"I enter a valid email address and invalid password")]
        public void WhenIEnterAValidEmailAddressAndInvalidPassword()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys(workingEmailAddress);
            driver.FindElement(By.XPath("//*[@id=\"passwd\"]")).SendKeys(workingPassword + "a");
            driver.FindElement(By.XPath("//*[@id=\"SubmitLogin\"]")).Click();
        }

        [Then(@"I should recieve an error message")]
        public void ThenIShouldRecieveAnErrorMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement failureMessage = driver.FindElement(By.XPath("//*[@id=\"alert\"]"));
            Assert.That(failureMessage.Text, Does.Contain("Authentication failed."));
        }
    }
}
