using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.View
{
    public class MainPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//*[@data-language = 'uk']")]
        private IWebElement ukLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-language = 'ru']")]
        private IWebElement ruLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href = '/mobile/']")]
        private IWebElement mobile { get; set; }

        private IWebDriver driver;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string getTitle() => driver.Title;

        public MainPage setUkLanguage()
        {
            ukLanguage.Click();
            return this;
        }

        public MainPage setRuLanguage()
        {
            ruLanguage.Click();
            return this;
        }

        public MobilePage selectMobile()
        {
            mobile.Click();
            return new MobilePage(driver);
        }
    }
}
