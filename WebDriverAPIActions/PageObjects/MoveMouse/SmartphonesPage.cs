using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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

        [FindsBy(How = How.Id, Using = "ListViewInner")]
        private IList<IWebElement> ResultList { get; set; }

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
            CathegorySelect.Click();
            IWebElement option = CathegorySelect.FindElement(By.XPath(String.Format(optionName, optionPart)));
            option.Click();
        }

        public void SetSearchText(string text)
        {
            SearchField.SendKeys(text);
        }

        public void SubmitSearch()
        {
            SearchSubmitButton.Click();
        }

        public bool AreResultsFounded()
        {
            if (ResultList.Count == 0)
                return false;
            return true;
        }
    }
}
