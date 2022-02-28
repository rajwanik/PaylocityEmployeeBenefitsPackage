using OpenQA.Selenium;

namespace PaylocityEmployeeBenefitsPackage.UI.Specflow.Common
{
    public static class EmployeeHelper
    {
        public static void ClickButton(By by)
        {
            var element = WebDriverContext.Current.WaitForElementToBeVisible(by);
            element.Click();
        }
    }
}
