using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoTest.View;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string searchPage = ConfigurationManager.AppSettings["SearchPageUrl"];
        private string mainPageUrl = ConfigurationManager.AppSettings["MainPageUrl"];
        
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void TEST_1()
        {
            driver.Navigate().GoToUrl(this.searchPage);
            SearchPage searchPage = new SearchPage(driver);
            ResultPage resultPage = searchPage.setSearchField(mainPageUrl)
                                              .clickSearch();
            string actualResult = resultPage.getSearchResult();
            Assert.AreEqual(mainPageUrl, actualResult, "Can't find neccessary link");

            MainPage mainPage = resultPage.selectLink(mainPageUrl);
            string expectedTitle = "Hotline - сравнить цены в интернет-магазинах Украины";
            Assert.AreEqual(expectedTitle, mainPage.getTitle(), "Title differs");
        }

        [Test]
        public void TEST_2()
        {
            driver.Navigate().GoToUrl(this.mainPageUrl);
            MainPage mainPage = new MainPage(driver);
            string expectedTitle = "Hotline - сравнить цены в интернет-магазинах Украины";
            Assert.AreEqual(expectedTitle, mainPage.getTitle(), "Title differs");

            mainPage.setUkLanguage();
            string newTitle = "Hotline - порівняти ціни в інтернет-магазинах України";
            Assert.AreEqual(newTitle, mainPage.getTitle(), "Title differs");
        }

        [Test]
        public void TEST_3()
        {
            driver.Navigate().GoToUrl(this.mainPageUrl);
            MainPage mainPage = new MainPage(driver);
            mainPage.setRuLanguage();
            string expectedTitle = "Hotline - сравнить цены в интернет-магазинах Украины";
            Assert.AreEqual(expectedTitle, mainPage.getTitle(), "Title differs");

            MobilePage mobilePage = mainPage.selectMobile();
            string mobileTitle = "Мобильные телефоны, электроника, аксессуары | Hotline";
            Assert.AreEqual(mobileTitle, mobilePage.getTitle(), "Title differs");

            PowerBankPage powerBankPage = mobilePage.selectPowerBank();
            string powerBankTitle = "Портативные зарядные устройства и повербанки (powerbank) | Hotline";
            Assert.AreEqual(powerBankTitle, powerBankPage.getTitle(), "Title differs");

        }

        [Test]
        public void TEST_4()
        {
            driver.Navigate().GoToUrl(this.mainPageUrl);
            MainPage mainPage = new MainPage(driver);
            mainPage.setRuLanguage();
            string expectedTitle = "Hotline - сравнить цены в интернет-магазинах Украины";
            Assert.AreEqual(expectedTitle, mainPage.getTitle(), "Title differs");

            MobilePage mobilePage = mainPage.selectMobile();
            string mobileTitle = "Мобильные телефоны, электроника, аксессуары | Hotline";
            Assert.AreEqual(mobileTitle, mobilePage.getTitle(), "Title differs");

            PowerBankPage powerBankPage = mobilePage.selectPowerBank();
            string powerBankTitle = "Портативные зарядные устройства и повербанки (powerbank) | Hotline";
            Assert.AreEqual(powerBankTitle, powerBankPage.getTitle(), "Title differs");

            int filterMax = 1000;
            powerBankPage.setPriceFilter(filterMax).confirmPriceFilter();
            powerBankPage.confirmVolumeFilter();
            
        }

        [Test]
        public void TEST_5()
        {

        }
    }
}
