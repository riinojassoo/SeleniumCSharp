using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckContactsForm
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver();
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Set an implicit wait time
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void SearchTest()
        {
            // Navigate to Google's homepage
            driver!.Navigate().GoToUrl("https://riinojassoo.wixsite.com/shoes");

            // Click the contct button by path
            var contactButton = driver.FindElement(By.XPath("/html/body/div/div/div[4]/div/header/div[2]/div[2]/div/div/section/div[2]/div[1]/div[2]/div/div[2]/nav/ul/li[2]/a/div/span"));
            contactButton.Click();

            System.Threading.Thread.Sleep(1000);

            // Find the first name input box by its Id
            var firstNameBox = driver.FindElement(By.Id("input_comp-m1p3eb6e"));
            // Enter the first name
            firstNameBox.SendKeys("First");

            var lastNameBox = driver.FindElement(By.Id("input_comp-m1p3eb6r"));
            lastNameBox.SendKeys("Last");

            var emailBox = driver.FindElement(By.Id("input_comp-m1p3eb6z"));
            emailBox.SendKeys("practice@practice.com");

            var messageBox = driver.FindElement(By.Id("textarea_comp-m1p3eb76"));
            messageBox.SendKeys("Testing");

            var sendButton = driver.FindElement(By.XPath("/html/body/div/div/div[4]/div/main/div/div/div/div[2]/div/div/div/section[3]/div[2]/div/div/div[2]/div/div[1]/div/div/form/div/div/div[5]/button/span"));
            sendButton.Click();

            System.Threading.Thread.Sleep(2000);
            
            //Find CAPTCHA Window
            var verificationWindow = driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div[2]/div/div/h2"));
            
            // Assert that the window is displayed
            Assert.That(verificationWindow.Displayed, "reCAPTCHA window was not displayed.");
    
            // Optionally, you can check the content of the window
            Assert.That(verificationWindow.Text.Contains("Verification"), 
                "The expected message was not displayed.");


        }
        [TearDown]
        public void Teardown()
        {
             // Close the browser and dispose of the driver
             driver?.Quit();
        }
    }
}
