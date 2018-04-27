using OpenQA.Selenium;

namespace AutoTest.View
{
    public class Page
    {
        private IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
