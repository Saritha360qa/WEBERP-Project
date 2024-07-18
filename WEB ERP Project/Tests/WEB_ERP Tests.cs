using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WEB_ERP_Project.Pages;
using WEB_ERP_Project.Reports;
using WEB_ERP_Project.Utilities;
using WEBERP;

namespace WEB_ERP_Project.Tests
{
    [TestFixture]
    public class WEBERPProjecttests : Commondriver
    {
        Login_Page LoginPageobj = new Login_Page();
        Homepage Homepageobj = new Homepage();

        [Test, Order(1), Description("check if user is able to enter valid data in login page")]
        public void LoginpageTest()
        {
            try
            {
                ExtentReporting.CreateTest("LoginpageTest");
                ExtentReporting.LogInfo("Log on to Home page");

                // LoginPage object initialization and definition
                LoginPageobj.LoginActions(driver);

                ExtentReporting.LogPass("LoginpageTest passed successfully.");
            }
            catch (Exception ex)
            {
                ExtentReporting.LogFail($"LoginpageTest failed: {ex.Message}");
                ExtentReporting.LogFail(ex.StackTrace);
                throw; // Rethrow the exception to ensure the test is marked as failed in the test runner
            }
            finally
            {
                ExtentReporting.EndReporting(); // Ensure the report is flushed
            }
        }
        [Test, Order(2), Description("check if user is able to enter valid data in hotel search page")]
        public void SalesPageTest()
        {
            string ExpectedFilepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\ExpectedFile.txt";
            bool CompareFiles(string filePath1, string filePath2)
            {
                // Read all bytes from both files
                byte[] file1Bytes = File.ReadAllBytes(filePath1);
                byte[] file2Bytes = File.ReadAllBytes(filePath2);

                // Compare the byte arrays
                return file1Bytes.Length == file2Bytes.Length && file1Bytes.SequenceEqual(file2Bytes);
            }
            try
            {
                ExtentReporting.CreateTest("SalespageTest");
                ExtentReporting.LogInfo("Log on to Home page");
                
                //HomePage object initialization and definition
                LoginPageobj.LoginActions(driver);
                string ResultFilePath = Homepageobj.HomepageActions(driver).ToString();
                bool areFilesEqual = CompareFiles(ResultFilePath, ExpectedFilepath);
                if (areFilesEqual ) {
                    ExtentReporting.LogPass("SalespageTest passed successfully.");
                }
                else
                {
                    ExtentReporting.LogFail("File are not matching - Menu list not matched.");
                }
                
            }
            catch (Exception ex)
            {
                ExtentReporting.LogFail($"SalespageTest failed: {ex.Message}");
                ExtentReporting.LogFail(ex.StackTrace);
                throw; // Rethrow the exception to ensure the test is marked as failed in the test runner
            }
            finally
            {
                ExtentReporting.EndReporting(); // Ensure the report is flushed
            }
        }
    }
}
 


