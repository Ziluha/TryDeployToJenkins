using OpenQA.Selenium;
using System.Configuration;
using NUnit.Framework;
using WebDriverAPIActions.WrapperFactory;
using WebDriverAPIActions.PageObjects.DragAndDrop;
using WebDriverAPIActions.DriverSettings;
using WebDriverAPIActions.Enums;

namespace WebDriverAPIActions.TestCases
{
    class DragAndDropTest
    {
        IWebDriver driver;
        BrowserFactory browserFactory = BrowserFactory.getInstance();

        [SetUp]
        public void Init()
        {
            driver = browserFactory.InitBrowser(Browser.Name.Firefox);
            DriverConfiguration.LoadApp(driver, ConfigurationManager.AppSettings["Html5demosURL"]);
        }
        
        [Test]
        public void DragAndDrop()
        {
            DragAndDropPage dragAndDropPage = new DragAndDropPage(driver);
            int cardsAtStart = dragAndDropPage.CountCards();
            dragAndDropPage.MoveCardToBin("one");
            dragAndDropPage.MoveCardToBin("three");
            Assert.AreEqual(cardsAtStart - 2, dragAndDropPage.CountCards(), "Wrong number of cards in bin");
            Assert.True(dragAndDropPage.AreCardsInBin(), "No one or not all cards are in bin");
        }

        [TearDown]
        public void EndTest()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}
