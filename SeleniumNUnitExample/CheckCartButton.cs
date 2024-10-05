using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckCartButton
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

            // Click the shop button by path
            var cartButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/header/div[2]/div[2]/div/div/section/div[2]/div[2]/div[2]/div/div[1]/div"));
            cartButton.Click();

            System.Threading.Thread.Sleep(1000);
            
            // Assert that the new opened page name contains cart in it
            Assert.That(driver.Url.Contains("cart"), "Did not navigate to 'Cart' page.");


        }
        [TearDown]
        public void Teardown()
        {
             // Close the browser and dispose of the driver
             driver?.Quit();
        }
    }
}
