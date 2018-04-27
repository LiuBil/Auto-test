using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.View
{
    public class ResultPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='res']//*[cite]")]
        private IWebElement searchResult { get; set; }
        
        private IWebDriver driver;

        public ResultPage(IWebDriver driver) 
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string getSearchResult() => searchResult.Text;
        
        public MainPage selectLink(string value)
        {
            driver.FindElement(By.XPath(String.Format("//a[@href = '{0}']", value))).Click();
            return new MainPage(driver);
        }
    }
}
