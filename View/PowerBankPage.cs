using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.View
{
    public class PowerBankPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='price-slider-box']//input[3]")]
        private IWebElement priceFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='OK']")]
        private IWebElement ok { get; set; }
        

        private IWebDriver driver;

        public PowerBankPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string getTitle() => driver.Title;

        public PowerBankPage setPriceFilter(int value)
        {
            priceFilter.Clear();
            priceFilter.SendKeys(value);
            return this;
        }

        public PowerBankPage confirmPriceFilter()
        {
            ok.Click();
            return this;
        }
    }
}
