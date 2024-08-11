using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Ruta al ChromeDriver
            string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");

            // Inicializa el WebDriver de Chrome con la ruta del driver
            driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera implícito
        }

        [TestCleanup]
        public void Teardown()
        {
            // Cierra el navegador después de cada prueba
            driver.Quit();
        }

        [TestMethod]
        public void TestCreateCliente()
        {
            // Navega a la página de crear cliente
            driver.Navigate().GoToUrl("http://localhost:5043/ClienteSql/Create");

            // Interactúa con la página para crear un cliente
            driver.FindElement(By.Id("Cedula")).SendKeys("1234567890");
            driver.FindElement(By.Id("Nombres")).SendKeys("Juan");
            driver.FindElement(By.Id("Apellidos")).SendKeys("Pérez");
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("01/01/1990");
            driver.FindElement(By.Id("Mail")).SendKeys("juan.perez@example.com");
            driver.FindElement(By.Id("Telefono")).SendKeys("0123456789");
            driver.FindElement(By.Id("Estado")).SendKeys("Activo"); // Cambia según el tipo de input

            // Envía el formulario
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

        }
    }
}
