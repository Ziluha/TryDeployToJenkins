using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverAPIActions.PageObjects.MoveMouse
{
    class SmartphonesPage
    {
        private IWebDriver driver;
        private Actions action;
        private WebDriverWait wait;
        private string expectedPageMainTitle = "Смартфоны";
        private string optionName = "//option[contains(text(),'{0}')]";

        [FindsBy(How = How.Id, Using = "mainTitle")]
        private IWebElement SmartpronesPageMainTitle { get; set; }

        [FindsBy(How = How.Id, Using = "gh-cat")]
        private IWebElement CathegorySelect { get; set; }
                
        [FindsBy(How = How.Id, Using = "gh-ac")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "gh-btn")]
        private IWebElement SearchSubmitButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "rcnt")]
        private IWebElement ResultCount { get; set; }

        private string GetPageMainTitle()
        {
            return SmartpronesPageMainTitle.Text;
        }

        public SmartphonesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual(expectedPageMainTitle, GetPageMainTitle(), "This isn't smartphones page");
        }
        
        public void SelectSearchOption(string optionPart)
        {
            action = new Actions(driver);
            action.Click(CathegorySelect).Perform();
            IWebElement option = CathegorySelect.FindElement(By.XPath(String.Format(optionName, optionPart)));
            option.Click();
        }

        public void SetSearchText(string text)
        {
            SearchField.SendKeys(text);
        }

        public void SubmitSearch()
        {
            action = new Actions(driver);
            action.Click(SearchSubmitButton).Perform();
        }

        public bool AreResultsFounded()
        {
            if (ResultCount.Text == "0")
                return false;
            return true;
        }
    }
}
