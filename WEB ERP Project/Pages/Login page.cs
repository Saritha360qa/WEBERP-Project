
using NUnit.Framework;
using OpenQA.Selenium;
using WEB_ERP_Project.Utilities;

namespace WEBERP
{
    public class Login_Page
    {
        public void LoginActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            // Lunch WEB_ERP page
            driver.Navigate().GoToUrl("http://etestingplatform.com/webERP/");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"login_box\"]/form/div/input[2]", 10);

            // Identify the username textbox and enter valid username
            IWebElement UsernameTextbox = driver.FindElement(By.XPath("//*[@id=\"login_box\"]/form/div/input[2]"));
            UsernameTextbox.SendKeys("Admin");

            // Identify the password textbox and enter valid password
            IWebElement PasswordTextbox = driver.FindElement(By.XPath("//*[@id=\"login_box\"]/form/div/input[3]"));
            PasswordTextbox.SendKeys("weberp");
            Thread.Sleep(1000);

            //Identify the loginbutton and click on it
            IWebElement Loginbutton = driver.FindElement(By.XPath("//*[@id=\"login_box\"]/form/div/input[4]"));
            Loginbutton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/header/div[7]", 20);
            IWebElement Newcode = driver.FindElement(By.XPath("/html/body/header/div[7]"));

            Assert.That(Newcode.Text == "Main Menu", "Cannot find text 'Main Menu'");
        }
    }
}