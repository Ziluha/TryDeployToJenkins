using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using System;

namespace WebDriverAPIActions.JQueryHelper
{
    class JQueryHelper
    {
        private static void LoadJQuery(IWebDriver driver)
        {
            StreamReader sr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["JQueryLoadHelper"]));
            string script = sr.ReadToEnd();
            ((IJavaScriptExecutor)driver).ExecuteAsyncScript(script);
        }

        private static void LoadDragAndDropHelper(IWebDriver driver, string fromId, string toId)
        {
            StreamReader sr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["DragAndDropHelper"]));
            string script = sr.ReadToEnd() + "$('#" + fromId + "').simulateDragDrop({ dropTarget: '#"+toId+"'});";
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static void DragAndDrop(IWebDriver driver, string fromId, string toId )
        {
            LoadJQuery(driver);
            LoadDragAndDropHelper(driver, fromId, toId);
        }
    }
}
