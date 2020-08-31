using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using LastChance.pages;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Interfaces;
using TestContext = NUnit.Framework.TestContext;
using LastChance.Utils;

namespace LastChance.tests
{
    [TestClass]
    public class practicetest
    {
        ExtentHtmlReporter htmlReporter ;
        ExtentReports extent;
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\Extentreports.html";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            //extent.AttachReporter(htmlReporter);
            
            
        }
        [Test]
        public void EnvVariable()
        {
            extent.AddSystemInfo("Operating System", "Windows 10");
            extent.AddSystemInfo("HostName", "MyPC");
            extent.AddSystemInfo("Browser", "Google Chrome");
        }

        [Test]
        public void TestMethod()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://letskodeit.teachable.com/");
            PracticePage LP = new PracticePage(driver);
            LP.practicebutton();
            Thread.Sleep(3000);
            LP.practicing();
        }

        [TearDown]
        public void GetResult()
        { 
            
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            
            //ScreenCapture screen = new ScreenCapture();
            string ScreenshotPath = ScreenCapture.Capture(driver, "ScreenShot"+status );
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Passed)
            {
                var test = extent.CreateTest("TestMethod", "This Test Case gets Passed");
                test.Log(Status.Pass, stackTrace + errorMessage);
                test.Log(Status.Info, "Step 1: Test Case starts.");
                test.AddScreenCaptureFromPath(ScreenshotPath);
                extent.AttachReporter(htmlReporter);
            }

            else if (status == TestStatus.Failed)
            {
                var test = extent.CreateTest("TestMethod", "This Test Case gets Failed");
                test.Log(Status.Info, "Step 1: Test Case starts.");
                test.Log(Status.Fail, stackTrace + errorMessage);
                //test.Log(Status.Fail, "Step 2: Test Case Failed.");
                test.AddScreenCaptureFromPath(ScreenshotPath);
                extent.AttachReporter(htmlReporter);

            }
            else if (status == TestStatus.Skipped)
            {
                var test = extent.CreateTest("TestMethod", "This Test Case gets Skipped");
                test.Log(Status.Info, "Step 1: Test Case starts.");
                test.Log(Status.Skip, stackTrace + errorMessage);
                //test.Log(Status.Skip, "Step 2: Test Case Skipped.");
                test.AddScreenCaptureFromPath(ScreenshotPath);
                extent.AttachReporter(htmlReporter);
            }
            else if (status == TestStatus.Warning)
            {
                var test = extent.CreateTest("TestMethod", "This Test Case gets Warning");
                test.Log(Status.Info, "Step 1: Test Case starts.");
                test.Log(Status.Warning, stackTrace + errorMessage);
                //test.Log(Status.Warning, "Step 2: Test Case warning.");
                test.AddScreenCaptureFromPath(ScreenshotPath);
                extent.AttachReporter(htmlReporter);
            }
            extent.Flush();
            driver.Close();         
        }
    }
}
