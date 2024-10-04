using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckContacts
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

            // Find the search box using its name attribute
            var contactButton = driver.FindElement(By.XPath("/html/body/div/div/div[4]/div/header/div[2]/div[2]/div/div/section/div[2]/div[1]/div[2]/div/div[2]/nav/ul/li[2]/a/div/span"));
            contactButton.Click();

            System.Threading.Thread.Sleep(1000);

            Assert.That(driver.Url.Contains("contact"), "Did not navigate to 'Contact' page.");

        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}
