using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_ERP_Project.Reports;

namespace WEB_ERP_Project.Utilities
{
    public class Commondriver
    {
        public IWebDriver driver;

        [SetUp]
        public void LoginSteps()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            driver = new ChromeDriver();

        }
        [TearDown]
        public void Closetestrun()
        {
            driver.Quit();
            ExtentReporting.EndReporting();
        }
    }
}

