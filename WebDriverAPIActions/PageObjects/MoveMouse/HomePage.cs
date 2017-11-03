using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverAPIActions.PageObjects.MoveMouse
{
    class HomePage
    {
        private IWebDriver driver;
        private Actions action;
        private WebDriverWait wait;
        private string navigationSubCat = "//div[@id='navigationFragment']//li[@class='icn']/a[contains(text(), '{0}')]";
        private string navigationCat = "//td[contains(@class,'cat') and contains(.,'{0}')]";

        [FindsBy(How = How.XPath, Using = "//div[@id='navigationFragment']")]
        private IWebElement NavigationFragment { get; set; }
        
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void HoverCat(string catName)
        {
            action = new Actions(this.driver);
            string catXPath = String.Format(navigationCat, catName);
            IWebElement cathegory = NavigationFragment.FindElement(By.XPath(catXPath));
            action.MoveToElement(cathegory).Build().Perform();
        }

        public void OpenSubCat(string subCatName)
        {
            string subCatXPath = String.Format(navigationSubCat, subCatName);
            IWebElement subCat = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(subCatXPath)));
            subCat.Click();
        }
    }
}
