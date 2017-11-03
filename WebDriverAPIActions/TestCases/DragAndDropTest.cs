using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using WebDriverAPIActions.DriverSettings;
using WebDriverAPIActions.Enums;
using WebDriverAPIActions.PageObjects.DragAndDrop;
using WebDriverAPIActions.TestSettings;
using WebDriverAPIActions.WrapperFactory;

namespace WebDriverAPIActions.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class DragAndDropTest : Hooks
    {
        public DragAndDropTest() : base(Browser.Name.Firefox) { }

        [Test]
        public void DragAndDrop()
        {
            DriverConfiguration.LoadApp(Driver, ConfigurationManager.AppSettings["Html5demosURL"]);
            DragAndDropPage dragAndDropPage = new DragAndDropPage(Driver);
            int cardsAtStart = dragAndDropPage.CountCards();
            dragAndDropPage.MoveCardToBin("one");
            dragAndDropPage.MoveCardToBin("three");
            Assert.AreEqual(cardsAtStart - 2, dragAndDropPage.CountCards(), "Wrong number of cards in bin");
            Assert.True(dragAndDropPage.AreCardsInBin(), "No one or not all cards are in bin");
        }
    }
}
