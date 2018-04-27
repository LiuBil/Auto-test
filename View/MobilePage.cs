using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.View
{
    public class MobilePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(@data-eventlabel, 'Power Bank')]")]
        private IWebElement powerBank { get; set; }

        private IWebDriver driver;

        public MobilePage(IWebDriver driver) 
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public string getTitle() => driver.Title;

        public PowerBankPage selectPowerBank()
        {
            powerBank.Click();
            return new PowerBankPage(driver);
        }
    }
}
