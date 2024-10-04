using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckSearchBar
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
            var searchBox = driver.FindElement(By.Id("input_search-box-input-comp-m1up6vws"));

            // Enter the search term
            searchBox.SendKeys("sneaker");

            // Submit the search form
            searchBox.Submit();

            // Wait for the results page to load and display the results
            // It's better to use explicit waits in real tests
            System.Threading.Thread.Sleep(2000);

            // Verify that the page title contains the search term
            Assert.That(driver.Title.Contains("sneaker"), "The page title does not contain the search term.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}
