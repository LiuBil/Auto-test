using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.View
{
    public class SearchPage : Page
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement searchField { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement searchButton { get; set; }

        private IWebDriver driver;

        public SearchPage(IWebDriver driver) 
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SearchPage setSearchField(string value)
        {
            searchField.Clear();
            searchField.SendKeys(value);
            return this;
        }

        public ResultPage clickSearch()
        {
            searchField.Submit();
            return new ResultPage(driver);
        }
    }
}
