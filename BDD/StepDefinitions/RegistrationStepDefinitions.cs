using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    
    public class RegistrationStepDefinitions
    {
        IWebDriver driver;

        public readonly string testEmailAddress = "changethis7@gmail.com";
        public readonly string testPassword = "12345";
        public readonly string testFirstName = "John";
        public readonly string testLastName = "Smith";
        public readonly string testBirthdayDay = "1";
        public readonly string testBirthdayMonth = "1";
        public readonly string testBirthdayYear = "2022";
        public readonly string testAddress = "1 Hollywood Boulevard";
        public readonly string testCity = "Asd";
        public readonly string testState = "2";
        public readonly string testPostcode = "12345";
        public readonly string testCountry = "21";
        public readonly string testMobile = "091234567";

        [Given(@"I navigate to the front page")]
        public void GivenINavigateToTheFrontPage()
        {
            driver = new ChromeDriver("C:\\Users\\baikp\\source\\repos\\TestProject1\\TestProject1\\drivers");
            driver.Url = "http://automationpractice.com/index.php";
        }

        [Given(@"I click on Sign in")]
        public void GivenIClickOnSignIn()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")).Click();
        }

        [Given(@"I enter a valid email address format to create an account")]
        public void GivenIEnterAValidEmailAddressFormatToCreateAnAccount()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement enterEmail = driver.FindElement(By.Name("email_create"));
            enterEmail.SendKeys(testEmailAddress); //why does the variable give an CS0120 error when I place the info in a separate class?
            IWebElement clickCreate = driver.FindElement(By.Name("SubmitCreate"));
            clickCreate.Click();
        }

        [Given(@"I enter correctly formatted details in all of the required fields")]
        public void GivenIEnterCorrectlyFormattedDetailsInAllOfTheRequiredFields()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id=\"id_gender1\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"customer_firstname\"]")).SendKeys(testFirstName);
            driver.FindElement(By.XPath("//*[@id=\"customer_lastname\"]")).SendKeys(testLastName);
            driver.FindElement(By.XPath("//*[@id=\"passwd\"]")).SendKeys(testPassword);
            driver.FindElement(By.XPath("//*[@id=\"days\"]")).Click();
            SelectElement dropDownDay = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"days\"]")));
            dropDownDay.SelectByValue(testBirthdayDay);
            driver.FindElement(By.XPath("//*[@id=\"months\"]")).Click();
            SelectElement dropDownMonth = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"months\"]")));
            dropDownMonth.SelectByValue(testBirthdayMonth);
            driver.FindElement(By.XPath("//*[@id=\"years\"]")).Click();
            SelectElement dropDownYear = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"years\"]")));
            dropDownYear.SelectByValue(testBirthdayYear);
            driver.FindElement(By.XPath("//*[@id=\"address1\"]")).SendKeys(testAddress);
            driver.FindElement(By.XPath("//*[@id=\"city\"]")).SendKeys(testCity);
            driver.FindElement(By.XPath("//*[@id=\"id_state\"]")).Click();
            SelectElement dropDownState = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"id_state\"]")));
            dropDownState.SelectByValue(testState);
            driver.FindElement(By.XPath("//*[@id=\"postcode\"]")).SendKeys(testPostcode);
            driver.FindElement(By.XPath("//*[@id=\"id_country\"]")).Click();
            SelectElement dropDownCountry = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"id_country\"]")));
            dropDownCountry.SelectByValue(testCountry);
            driver.FindElement(By.XPath("//*[@id=\"phone_mobile\"]")).SendKeys(testMobile);
        }

        [When(@"click Register")]
        public void WhenClickRegister()
        {
            driver.FindElement(By.XPath("//*[@id=\"submitAccount\"]")).Click();
        }

        [Then(@"I should successfuly create a new account")]
        public void ThenIShouldSuccessfulyCreateANewAccount()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement confirmMessage = driver.FindElement(By.XPath("//*[@id=\"center_column\"]"));
            Assert.That(confirmMessage.Text, Does.Contain("Welcome to your account."));

            driver.Quit();
        }
    }
}
