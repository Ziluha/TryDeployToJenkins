﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System;
using WebDriverAPIActions.JQueryHelper;

namespace WebDriverAPIActions.PageObjects.DragAndDrop
{
    class DragAndDropPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "bin")]
        private IWebElement Bin { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@draggable='true']")]
        private IList<IWebElement> CardsList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='bin']/p")]
        private IList<IWebElement> CardsInBin { get; set; }

        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public int CountCards()
        {
            return CardsList.Count;
        }

        public void MoveCardToBin(string cardId)
        {
            JQueryHelper.JQueryHelper.DragAndDrop(driver, cardId, "bin");
        }

        public bool AreCardsInBin()
        {
            if (CardsInBin.Count == 0)
                return false;
            return true;
        }
    }
}