/*
 * Program: Assign4Test
 * Programmar : Mohammad Khomeiri
 * Date Created: April 8 2016
 *  
 */

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace testingAssign4Test
{
    [TestFixture]
    public class TestingAssign4
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:63342";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAddCarTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/PROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("Here")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtSellerName")).Clear();
            driver.FindElement(By.Id("txtSellerName")).SendKeys("Mohammad");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("222Doon");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Kitchener");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("444-888-6547");
            driver.FindElement(By.Id("txtEmailAddress")).Clear();
            driver.FindElement(By.Id("txtEmailAddress")).SendKeys("mmm@jj.l");
            driver.FindElement(By.Id("txtCarMake")).Clear();
            driver.FindElement(By.Id("txtCarMake")).SendKeys("toyota");
            driver.FindElement(By.Id("txtCarModel")).Clear();
            driver.FindElement(By.Id("txtCarModel")).SendKeys("camery");
            driver.FindElement(By.Id("txtCarYear")).Clear();
            driver.FindElement(By.Id("txtCarYear")).SendKeys("1993");
            driver.FindElement(By.Id("btnAddCar")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Mohammad", driver.FindElement(By.Id("lblSellerName")).Text);
        }

        [Test]
        public void TheLinkToJDTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/PROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("Here")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtSellerName")).Clear();
            driver.FindElement(By.Id("txtSellerName")).SendKeys("Micheal");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("76 fred");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("waterloo");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("471-958-3245");
            driver.FindElement(By.Id("txtEmailAddress")).Clear();
            driver.FindElement(By.Id("txtEmailAddress")).SendKeys("kgflon@hotmail.com");
            driver.FindElement(By.Id("txtCarMake")).Clear();
            driver.FindElement(By.Id("txtCarMake")).SendKeys("toyota");
            driver.FindElement(By.Id("txtCarModel")).Clear();
            driver.FindElement(By.Id("txtCarModel")).SendKeys("corolla");
            driver.FindElement(By.Id("txtCarYear")).Clear();
            driver.FindElement(By.Id("txtCarYear")).SendKeys("2013");
            driver.FindElement(By.Id("btnAddCar")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("displayLink")).Click();
        }

        [Test]
        public void TheSearchByMakeTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/PROG2070Assign4/index.html");
            driver.FindElement(By.XPath("(//a[contains(text(),'Here')])[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtSearchByMake")).Clear();
            driver.FindElement(By.Id("txtSearchByMake")).SendKeys("ford");
            driver.FindElement(By.Id("btnSearchByMake")).Click();
        }

        [Test]
        public void ThePhoneNumberBreakTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/PROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("Here")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtSellerName")).Clear();
            driver.FindElement(By.Id("txtSellerName")).SendKeys("lsdfkj");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("4343ld");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("llkjj");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("kldgfdskl");
            driver.FindElement(By.Id("txtEmailAddress")).Clear();
            driver.FindElement(By.Id("txtEmailAddress")).SendKeys("mm@fsd.kk");
            driver.FindElement(By.Id("txtCarMake")).Clear();
            driver.FindElement(By.Id("txtCarMake")).SendKeys("tredfbv");
            driver.FindElement(By.Id("txtCarModel")).Clear();
            driver.FindElement(By.Id("txtCarModel")).SendKeys("fgdfgkl");
            driver.FindElement(By.Id("txtCarYear")).Clear();
            driver.FindElement(By.Id("txtCarYear")).SendKeys("1994");
            driver.FindElement(By.Id("btnAddCar")).Click();
        }

        [Test]
        public void TheErrorValidationTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/PROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("Here")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAddCar")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
