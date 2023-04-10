using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpTesting
{
    class IntroSelenium
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

        [Test]
        public void FirstTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();

            // Wait setup: 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.CssSelector("input[name='q']")));

            // Alternatively:
            IWebElement secResult = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(e => e.FindElement(By.CssSelector("input[name='q']")));

            IWebElement searchBar = driver.FindElement(By.CssSelector("input[name='q']")); // Find element <input> with attributes name=q
                                                                                         //[name^=q] - starts with q, [name$=q] - ends with q, [name*=q] - contains q
            searchBar.SendKeys("javatpoint tutorials" + Keys.Enter); // Enters text to applicable element i.e. text boxes, can clear the text box using Clear() method

            //IWebElement searchButton = driver.FindElement(By.CssSelector("input[name^=btnK]"));
            //IWebElement searchButton = driver.FindElement(By.Name("btnK")); // Using inbuilt searcher methods
            //searchButton.Click();

            IWebElement javatpointLink = driver.FindElement(By.CssSelector("a[href*='www.javatpoint.com']")); //%2F&usg=
            javatpointLink.Click();
            
            IWebElement homeButton = driver.FindElement(By.CssSelector("a[href$='www.javatpoint.com'] > img[src*='jtp_logo.png']")); // Use > to find elements nested with parent elements
            // div + p - select first p element placed right after a div element; p ~ ul - Selects every ul element that is preceded by a p element

            Assert.IsNotNull(homeButton); // Assert the presence of the home buttom in the main page of Javatpoint Tutorials
            Assert.AreEqual(homeButton.Enabled, true);
            Assert.AreEqual(homeButton.Displayed, true);
        }
    }
}
