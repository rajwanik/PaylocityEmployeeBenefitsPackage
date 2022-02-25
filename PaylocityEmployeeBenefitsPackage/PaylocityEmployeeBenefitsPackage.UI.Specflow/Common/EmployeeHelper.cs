using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
