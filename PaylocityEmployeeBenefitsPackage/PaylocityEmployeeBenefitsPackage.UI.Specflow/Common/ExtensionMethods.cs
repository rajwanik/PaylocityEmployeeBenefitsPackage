using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PaylocityEmployeeBenefitsPackage.UI.Specflow.Common
{
    public static class ExtensionMethods
    {
        private static readonly TimeSpan DefaultWaitTimeout = TimeSpan.FromSeconds(20);

        public static IWebElement WaitForElementToBeVisible(this IWebDriver webDriver, string elementId)
        {
            return webDriver.WaitForElementToBeVisible(By.Id(elementId));
        }

        public static IWebElement WaitForElementToBeVisible(this IWebDriver webDriver, By by)
        {
            var wait = new WebDriverWait(WebDriverContext.Current, DefaultWaitTimeout);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public static void SetText(this IWebDriver webDriver, string id, string text, bool clear = true)
        {
            var element = webDriver.WaitForElementToBeVisible(id);
            if (clear && element.TagName != "select")
            {
                element.Clear();
            }
            element.SendKeys(text);
        }
    }
}
