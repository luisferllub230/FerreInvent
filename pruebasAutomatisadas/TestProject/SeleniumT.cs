using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;

namespace TestProject
{
    public class SeleniumT
    {

        IWebDriver driver;
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        [SetUp]
        public void Setup()
        {

            //driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void BrowserTest()
        {
            var sum = 55;
            Assert.Equals(sum, 55);
        }


        [TearDown]
        public void TearDowm() 
        {
            //driver.Quit();
        }
    }
}