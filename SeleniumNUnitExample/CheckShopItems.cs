﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class CheckShopItems
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
            var shopButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/header/div[2]/div[2]/div/div/section/div[2]/div[1]/div[2]/div/div[2]/nav/ul/li[3]/a/div/span"));
            shopButton.Click();

            System.Threading.Thread.Sleep(1000);

            // Find the 'Pattern Design Sneakers' and click
            var sneakerItem = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/main/div/div/div/div[2]/div/div/div/section/div[2]/div/div/div/div/div[2]/div[2]/div/div/div[3]/section/div/ul[1]/li[2]/div/div/div/div/a/div/div/div[1]/div[1]/p"));
            sneakerItem.Click();

            System.Threading.Thread.Sleep(1000);

            //Select Size
            var sizeBox = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/main/div/div/div/div[2]/div/div/div/section/div[2]/div/div/div/div/article/div[2]/section[2]/div[10]/div[1]/div/div[1]/div/div[2]/div/div/div/div/button/span[1]"));
            sizeBox.Click();

            System.Threading.Thread.Sleep(1000);

            var size8Box = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/main/div/div/div/div[2]/div/div/div/section/div[2]/div/div/div/div/article/div[2]/section[2]/div[10]/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div/div/div/div[1]/div/div/span"));
            size8Box.Click();

            System.Threading.Thread.Sleep(1000);

            //Click 'Add to Cart'
            var cartButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/main/div/div/div/div[2]/div/div/div/section/div[2]/div/div/div/div/article/div[2]/section[2]/div[10]/div[2]/button/span"));
            cartButton.Click();

            System.Threading.Thread.Sleep(2000);
            
            //Find Cart Window
            var cartWindow = driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div/div/div[2]/div/div[2]/div/div/div[1]/div/main/div[1]/div[1]/div"));
            
            // Assert that the window is displayed
            Assert.That(cartWindow.Displayed, "Cart window was not displayed.");
    
            // Optionally, you can check the content of the window
            Assert.That(cartWindow.Text.Contains("Cart"), 
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
