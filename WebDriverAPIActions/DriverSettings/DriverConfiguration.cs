﻿using OpenQA.Selenium;
using System;

namespace WebDriverAPIActions.DriverSettings
{
    class DriverConfiguration
    {
        public static void LoadApp(IWebDriver driver, string url)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
