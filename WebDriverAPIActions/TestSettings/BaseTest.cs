using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverAPIActions.Enums;
using WebDriverAPIActions.WrapperFactory;

namespace WebDriverAPIActions.TestSettings
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        private Browser.Name browserName;
        private BrowserFactory browserFactory = BrowserFactory.getInstance();

        public BaseTest(Browser.Name _browserName)
        {
            browserName = _browserName;
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
