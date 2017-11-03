using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverAPIActions.WrapperFactory;
using OpenQA.Selenium;
using WebDriverAPIActions.Enums;

namespace WebDriverAPIActions.TestSettings
{
    public class Hooks : BaseTest
    {
        private Browser.Name browserName;
        private BrowserFactory browserFactory;

        public Hooks(Browser.Name _browserName)
        {
            browserName = _browserName;
            browserFactory = BrowserFactory.getInstance();
        }

        public void ChooseDriverInstance(Browser.Name _browserName)
        {
            if (_browserName == Browser.Name.Chrome)
                Driver = browserFactory.InitBrowser(Browser.Name.Chrome);
            else if (_browserName == Browser.Name.Firefox)
                Driver = browserFactory.InitBrowser(Browser.Name.Firefox);
        }

        [SetUp]
        public void Init()
        {
            ChooseDriverInstance(browserName);
        }

        [TearDown]
        public void EndTest()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}
