using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckWrongPassword
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
            // Navigate to Moodle's login page
            driver!.Navigate().GoToUrl("https://moodle.edu.ee/login/index.php");

            // Find the username input box by its Id
            var usernameBox = driver.FindElement(By.Id("username"));
            // Enter the username
            usernameBox.SendKeys("user");

            // Find the password input box by its Id
            var passwordBox = driver.FindElement(By.Id("password"));
            // Enter the password into the password field
            passwordBox.SendKeys("1234ABCD");
            
            // Find the login button
            var loginButton = driver.FindElement(By.Id("loginbtn"));
            // Click the login button
            loginButton.Click();

            // Wait for the error message to appear
            var errorMessage = driver.FindElement(By.ClassName("alert-danger")); // Replace with actual class or id of the error message

            // Assert that the error message is displayed
            Assert.That(errorMessage.Displayed, "Login error message was not displayed.");
    
            // Optionally, you can check the content of the error message
            Assert.That(errorMessage.Text.Contains("Vale kasutajanimi või parool. Palun proovi uuesti!"), 
                "The expected error message was not displayed.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}
