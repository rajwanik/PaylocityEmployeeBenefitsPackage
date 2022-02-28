using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PaylocityEmployeeBenefitsPackage.UI.Specflow
{
    public static class WebDriverContext
    {
        private static IWebDriver _current;

        /// <summary>
        /// The Selenium WebDriver
        /// </summary>
        /// <seealso cref="IWebDriver"/>
        public static IWebDriver Current
        {
            get
            {
                if (_current == null)
                {
                    SetupDriver();
                }
                return _current;
            }

            private set { _current = value; }
        }

        public static void SetupDriver()
        {
            var driver = new ChromeDriver();
            _current = driver;

            _current.Manage().Window.Maximize();

            //Logic to print out the current resolution
            var initialResolution = _current.Manage().Window.Size;
            Console.WriteLine("Screen Resolution: " + initialResolution);
        }
    }
}
