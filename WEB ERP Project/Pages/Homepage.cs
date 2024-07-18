using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WEB_ERP_Project.Utilities;

namespace WEB_ERP_Project.Pages
{
    public class Homepage
    {
        public string HomepageActions(IWebDriver driver)
        {
            int count = 1;
            // Define the path to the text file
            String OutputFileName = "Output" + Stopwatch.GetTimestamp().ToString() + ".txt";
            //string filePath = "C:\\Users\\ramka\\OneDrive\\Documents\\WEB ERP Project\\WEB ERP Project\\WEB ERP Project\\results\\"+ OutputFileName;
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\"+ OutputFileName;
            for (int i = 0; i < count; i++)
            {
                IWebElement menuContainer = driver.FindElement(By.CssSelector("body > nav > ul"));
                IList<IWebElement> buttons = menuContainer.FindElements(By.TagName("a"));
                count = buttons.Count;

                // Print the text of each button to the console
                string buttonText = buttons[i].Text;
                
                File.AppendAllText(filePath, buttonText);

                // Click each button
                buttons[i].Click();

                Thread.Sleep(2000);

                IWebElement menuContainer2 = driver.FindElement(By.CssSelector("body > section"));
                IList<IWebElement> paragraphs = menuContainer2.FindElements(By.TagName("a"));
                
                for (int j = 0; j < paragraphs.Count; j++)
                {
                    string paragraphText = paragraphs[j].Text;
                   
                    // Write the value to the text file
                    File.AppendAllText(filePath, paragraphText);
                }
            }
           
            return filePath;
        }
    }
}

            