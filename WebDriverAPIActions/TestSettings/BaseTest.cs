using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverAPIActions.WrapperFactory;

namespace WebDriverAPIActions.TestSettings
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        BrowserFactory browserFactory = BrowserFactory.getInstance();

        [TearDown]
        public void EndTest()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}
