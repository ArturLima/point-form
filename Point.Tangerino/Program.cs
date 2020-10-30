using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Point.Tangerino
{
    class Program
    {
        static void Main(string[] args)
        {
            var EMPLOYER_CODE = "YOUR CODE";
            var PASSWORD = "YOUR PASSWORD";

            var options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache");
            options.AddArguments("--disable-gpu");

            var driver = new ChromeDriver(@"CHROME BIN", options);

            Console.WriteLine("opening tangerino");
            driver.Navigate().GoToUrl("https://app.tangerino.com.br/Tangerino/?wicket:bookmarkablePage=wicket-2:com.frw.tangerino.web.pages.web.cadastro.LoginFuncionarioPage&wicket:interface=wicket-2:8::INewBrowserWindowListener::");

            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(EMPLOYER_CODE);
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//input[@placeholder='PIN']")).SendKeys(PASSWORD);
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Console.WriteLine("logged in tangerino");
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(0);

            driver.FindElement(By.XPath("//input[@placeholder='PIN']")).SendKeys(PASSWORD);
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button[@id='registraPonto']")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("point successfully registered");

            driver.Quit();
        }
    }
}
