using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace WEB_ERP_Project.Utilities
{
    public class Wait
    {
        public static void WaitToBeClickable(IWebDriver Driver, string locatortype, string locatorvalue, int seconds)
        {
            var Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, seconds));

            if (locatortype == "XPath")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorvalue)));
            }
            if (locatortype == "Id")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorvalue)));
            }
            if (locatortype == "Cssselector")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorvalue)));
            }
        }

    }
}
