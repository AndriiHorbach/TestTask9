using OpenQA.Selenium;
using System.Threading;

namespace TestTask.Infrastructure.Common
{
    internal class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> DriverPool;

        static DriverManager()
        {
            DriverPool = new ThreadLocal<IWebDriver>();
        }

        public static IWebDriver Driver
        {
            get => DriverPool.Value;
            set => DriverPool.Value = value;
        }
    }
}
