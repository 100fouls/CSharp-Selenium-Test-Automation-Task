using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions
    {
        IWebDriver driver;

        public readonly string workingEmailAddress = "workingtestexample@gmail.com";
        public readonly string workingPassword = "12345";

        [When(@"I enter an existing email address and password")]
        public void WhenIEnterAnExistingEmailAddressAndPassword()
        {
            IWebElement enterEmail2 = driver.FindElement(By.Id("email"));
            enterEmail2.SendKeys(workingEmailAddress);

            IWebElement enterPassword2 = driver.FindElement(By.Id("passwd"));
            enterPassword2.SendKeys(workingPassword);

            IWebElement submitLogin = driver.FindElement(By.Id("SubmitLogin"));
            submitLogin.Click();
        }

        [Then(@"I should successfully reach the accounts page")]
        public void ThenIShouldSuccessfullyReachTheAccountsPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement confirmMessage = driver.FindElement(By.XPath("//*[@id=\"center_column\"]"));
            Assert.That(confirmMessage.Text, Does.Contain("Welcome to your account."));
        }
    }
}
