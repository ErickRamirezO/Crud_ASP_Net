using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace MSTest
{
    [TestClass]
    public class WebTests
    {
        private readonly IWebDriver driver;
        private By googleSearchBox = By.Id("APjFqb");
        private By googleButtonSearch = By.Name("btnK");
        private By googleSearchResult = By.Id("_mly7ZuXpJo-YwbkPreH04A8_33");
        
        public By sendButton = By.Id("send");
        public By submitButton = By.CssSelector("input[type='submit'][value='Crear']");
        public int customerId = 11;

        // variables para determinar cuanto va a tardar la prueba
        private int waitTime = 3000;

        public WebTests()
        {
            // Ruta al ChromeDriver
            // string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");
            driver = new ChromeDriver();
        }

        [TestInitialize]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera implícito
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        // [TestMethod]
        // public void TestPageGoogle()
        // {
        //     driver.Navigate().GoToUrl("https://www.google.com");
        //     Thread.Sleep(waitTime);

        //     driver.FindElement(googleSearchBox).SendKeys("Visual Studio Code");
        //     Thread.Sleep(waitTime);

        //     driver.FindElement(googleButtonSearch).Click();
        //     Thread.Sleep(waitTime);

        //     var searchResult = driver.FindElement(googleSearchResult);
        //     Assert.IsNotNull(searchResult);
        // }

        [TestMethod]
        public void TestCreateCustomer()
        {
            driver.Navigate().GoToUrl("http://localhost:5043/ClienteSql/Create");
            Thread.Sleep(waitTime);

            // Seleccionar "Tungurahua" en el dropdown de provincias
            var provinciaSelect = new SelectElement(driver.FindElement(By.Id("ProvinciaSelect")));
            provinciaSelect.SelectByText("Tungurahua");

            driver.FindElement(By.Id("CedulaInput")).SendKeys("1234554890");
            driver.FindElement(By.Id("Nombres")).SendKeys("Sara Estefania");
            driver.FindElement(By.Id("Apellidos")).SendKeys("Ortiz García");
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("1990-05-01");
            driver.FindElement(By.Id("Mail")).SendKeys("sarae@example.com");
            driver.FindElement(By.Id("Telefono")).SendKeys("0123456789");
            driver.FindElement(By.Id("Estado")).Click(); // Activo
            driver.FindElement(By.Id("SaldoInput")).SendKeys("125");
            Thread.Sleep(waitTime);
            driver.FindElement(submitButton).Click();
            Thread.Sleep(waitTime);

            driver.Navigate().GoToUrl("http://localhost:5043/ClienteSql"); 
            Thread.Sleep(6000);
        }


        [TestMethod]
        public void TestEditCustomer()
        {
            driver.Navigate().GoToUrl($"http://localhost:5043/ClienteSql/Edit/{customerId}"); 
            Thread.Sleep(waitTime);

            driver.FindElement(By.Id("Cedula")).Clear();
            driver.FindElement(By.Id("Cedula")).SendKeys("9876543210");

            Thread.Sleep(waitTime);
            driver.FindElement(sendButton).Click();
        }

        [TestMethod]
        public void TestDeleteCustomer()
        {
            driver.Navigate().GoToUrl($"http://localhost:5043/ClienteSql/Delete/{customerId}"); 
            Thread.Sleep(waitTime);

            driver.FindElement(sendButton).Click();
            Thread.Sleep(waitTime);

            Assert.AreNotEqual(driver.Url, $"http://localhost:5043/ClienteSql/Delete/{customerId}"); 
        }
    }
}
