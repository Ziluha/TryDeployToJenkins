using NUnit.Framework;
using System.Configuration;
using WebDriverAPIActions.DriverSettings;
using WebDriverAPIActions.Enums;
using WebDriverAPIActions.PageObjects.MoveMouse;
using WebDriverAPIActions.TestSettings;

namespace WebDriverAPIActions.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class MoveMouseTest : BaseTest
    {
        public MoveMouseTest() : base(Browser.Name.Chrome) { }
        [Test]
        public void MouseMove()
        {
            DriverConfiguration.LoadApp(Driver, ConfigurationManager.AppSettings["EbayURL"]);
            HomePage homePage = new HomePage(Driver);
            homePage.HoverCat("Электроника");
            homePage.OpenSubCat("Мобильные телефоны");

            SmartphonesPage smartphonesPage = new SmartphonesPage(Driver);
            smartphonesPage.SelectSearchOption("Музыка");
            smartphonesPage.SetSearchText("Скрипка");
            smartphonesPage.SubmitSearch();
            Assert.True(smartphonesPage.AreResultsFounded(), "Result list is empty");
        }
    }
}
