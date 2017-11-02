using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using WebDriverAPIActions.DriverSettings;
using WebDriverAPIActions.Enums;
using WebDriverAPIActions.PageObjects.MoveMouse;
using WebDriverAPIActions.TestSettings;
using WebDriverAPIActions.WrapperFactory;

namespace WebDriverAPIActions.TestCases
{
    [TestFixture]
    public class MoveMouseTest : BaseTest
    {
        BrowserFactory browserFactory = BrowserFactory.getInstance();

        [SetUp]
        public void Init()
        {
            driver = browserFactory.InitBrowser(Browser.Name.Chrome);
            DriverConfiguration.LoadApp(driver, ConfigurationManager.AppSettings["EbayURL"]);
        }

        [Test]
        public void MouseMove()
        {
            HomePage homePage = new HomePage(driver);
            homePage.HoverCat("Электроника");
            homePage.OpenSubCat("Мобильные телефоны");
            
            SmartphonesPage smartphonesPage = new SmartphonesPage(driver);
            smartphonesPage.SelectSearchOption("Музыка");
            smartphonesPage.SetSearchText("Скрипка");
            smartphonesPage.SubmitSearch();
            Assert.True(smartphonesPage.AreResultsFounded(), "Result list is empty");
        }
    }
}
