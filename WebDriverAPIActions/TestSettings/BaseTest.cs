using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverAPIActions.Enums;
using WebDriverAPIActions.WrapperFactory;

namespace WebDriverAPIActions.TestSettings
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        BrowserFactory browserFactory = BrowserFactory.getInstance();

        [SetUp]
        public void Init()
        {
            driver = browserFactory.InitBrowser(Browser.Name.Chrome);
        }

        [TearDown]
        public void EndTest()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}
