using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using WebDriverAPIActions.Enums;

namespace WebDriverAPIActions.WrapperFactory
{
    class BrowserFactory
    {
        private readonly IDictionary<Browser.Name, IWebDriver> drivers = new Dictionary<Browser.Name, IWebDriver>();
        private static BrowserFactory instance;
        private IWebDriver driver;

        private BrowserFactory() { }

        public static BrowserFactory getInstance()
        {
            if (instance == null)
                instance = new BrowserFactory();
            return instance;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public IWebDriver InitBrowser(Browser.Name browser)
        {
            switch (browser)
            {
                case Browser.Name.Firefox:
                    if(Driver == null)
                    {
                        var service = FirefoxDriverService.CreateDefaultService(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["FirefoxDriverPath"]));
                        driver = new FirefoxDriver(service);
                        drivers.Add(Browser.Name.Firefox, Driver);
                        return driver;
                    }
                    break;

                case Browser.Name.Chrome:
                    if(Driver == null)
                    {
                        driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["ChromeDriverPath"]));
                        drivers.Add(Browser.Name.Chrome, Driver);
                        return driver;
                    }
                    break;
            }
            return driver;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in drivers.Keys)
                drivers[key].Quit();
        }
    }
}
