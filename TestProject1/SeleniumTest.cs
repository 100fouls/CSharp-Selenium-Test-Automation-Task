using System;
using Microsoft.VisualBasic;
using System.Security.Principal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        //Registration information
        private readonly string testEmailAddress = "changethis1@gmail.com";
        private readonly string testPassword = "12345";
        private readonly string testFirstName = "John";
        private readonly string testLastName = "Smith";
        private readonly string testBirthdayDay = "1";
        private readonly string testBirthdayMonth = "1";
        private readonly string testBirthdayYear = "2022";
        private readonly string testAddress = "1 Hollywood Boulevard";
        private readonly string testCity = "Asd";
        private readonly string testState = "2";
        private readonly string testPostcode = "12345";
        private readonly string testCountry = "21";
        private readonly string testMobile = "091234567";
        private readonly string workingEmailAddress = "workingtestexample@gmail.com";
        private readonly string workingPassword = "12345";




        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\baikp\\source\\repos\\TestProject1\\TestProject1\\drivers");
        }

        [Test]
        public void Registration()
        {
            //navigate to page
            driver.Url = "http://automationpractice.com/index.php";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement signUpClick = driver.FindElement(By.ClassName("login"));
            signUpClick.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement enterEmail = driver.FindElement(By.Name("email_create"));
            enterEmail.SendKeys(testEmailAddress);
            IWebElement clickCreate = driver.FindElement(By.Name("SubmitCreate"));
            clickCreate.Click();


            //Registration information
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement gender = driver.FindElement(By.Id("id_gender1"));
            gender.Click();
            IWebElement firstName = driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(testFirstName);
            IWebElement lastName = driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys(testLastName);
            IWebElement password = driver.FindElement(By.Id("passwd"));
            password.SendKeys(testPassword);
            IWebElement dateBirthDay = driver.FindElement(By.Id("days"));
            dateBirthDay.Click();
            SelectElement dropDownDay = new SelectElement(driver.FindElement(By.Id("days")));
            dropDownDay.SelectByValue(testBirthdayDay);
            IWebElement dateBirthMonth = driver.FindElement(By.Id("months"));
            dateBirthMonth.Click();
            SelectElement dropDownMonth = new SelectElement(driver.FindElement(By.Id("months")));
            dropDownMonth.SelectByValue(testBirthdayMonth);
            IWebElement dateBirthYear = driver.FindElement(By.Id("years"));
            dateBirthYear.Click();
            SelectElement dropDownYear = new SelectElement(driver.FindElement(By.Id("years")));
            dropDownYear.SelectByValue(testBirthdayYear);
            IWebElement newsletter = driver.FindElement(By.Id("newsletter"));
            newsletter.Click();
            IWebElement address = driver.FindElement(By.Id("address1"));
            address.SendKeys(testAddress);
            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys(testCity);
            IWebElement state = driver.FindElement(By.Id("id_state"));
            state.Click();
            SelectElement dropDownState = new SelectElement(driver.FindElement(By.Id("id_state")));
            dropDownState.SelectByValue(testState);
            IWebElement postcode = driver.FindElement(By.Id("postcode"));
            postcode.SendKeys(testPostcode);
            SelectElement dropDownCountry = new SelectElement(driver.FindElement(By.Id("id_country")));
            dropDownCountry.SelectByValue(testCountry);
            IWebElement phoneMobile = driver.FindElement(By.Id("phone_mobile"));
            phoneMobile.SendKeys(testMobile);
            IWebElement sumbitAccount = driver.FindElement(By.Id("submitAccount"));
            sumbitAccount.Click();

            // using xpath for day of birth should be //label[contains(text(),'Date of Birth')]/..//select[@id='days']

            //Assertion
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement confirmMessage = driver.FindElement(By.ClassName("info-account"));
            Assert.That(confirmMessage.Text, Does.Contain("Welcome to your account."));

            string expectedURL = "http://automationpractice.com/index.php?controller=my-account";
            string actualURL = driver.Url;
            Assert.That(expectedURL, Is.EqualTo(actualURL));

            //log out
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement logOut = driver.FindElement(By.ClassName("logout"));
            logOut.Click();
        }
        [Test]
            public void SignIn()
        {
            driver.Url = "http://automationpractice.com/index.php"; 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); 
            IWebElement SignIn = driver.FindElement(By.ClassName("login"));
            SignIn.Click();
            
            IWebElement enterEmail2 = driver.FindElement(By.Id("email"));
            enterEmail2.SendKeys(workingEmailAddress);

            IWebElement enterPassword2 = driver.FindElement(By.Id("passwd"));
            enterPassword2.SendKeys(workingPassword);

            IWebElement submitLogin = driver.FindElement(By.Id("SubmitLogin"));
            submitLogin.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement confirmMessage = driver.FindElement(By.ClassName("info-account"));
            Assert.That(confirmMessage.Text, Does.Contain("Welcome to your account."));

        }
        [Test]
            public void FailedSignIn()
        {
            driver.Url = "http://automationpractice.com/index.php"; 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); 
            IWebElement SignIn = driver.FindElement(By.ClassName("login"));
            SignIn.Click();

            IWebElement enterEmail2 = driver.FindElement(By.Id("email"));
            enterEmail2.SendKeys(testEmailAddress);

            IWebElement enterPassword2 = driver.FindElement(By.Id("passwd"));
            enterPassword2.SendKeys(testPassword + "a");

            IWebElement submitLogin = driver.FindElement(By.Id("SubmitLogin"));
            submitLogin.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement confirmMessage = driver.FindElement(By.ClassName("alert"));
            Assert.That(confirmMessage.Text, Does.Contain("Authentication failed."));

        }
        [TearDown]
            public void Quit()
        {
            driver.Quit();
        }
 
    }
}