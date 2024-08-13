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
        private readonly IWebDriver driver;
        By googleSearchar = By.Id("APjFqb");
        By googleButtonSearch = By.Name("btnK");
        By resultGoogleSearch = By.Id("_mly7ZuXpJo-YwbkPreH04A8_33");

        // variables para determinar cuanto va a tardar la prueba
        int tiempoEspera = 3000;

        // NUEVO
        public UnitTest1(){
            // Ruta al ChromeDriver
            string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");
            driver = new ChromeDriver(chromeDriverPath);
        }

        public void Dispose(){
            driver.Quit();
            driver.Dispose();
        }

        // [TestMethod]
        // public void TestPageGoogle(){
        //     IWebDriver driver = new ChromeDriver();
        //     // Ventana maximizada del navegador
        //     driver.Manage().Window.Maximize();
        //     driver.Navigate().GoToUrl("https://www.google.com");
        //     Thread.Sleep(tiempoEspera);
        //     // Buscar un elemento
        //     driver.FindElement(googleSearchar).SendKeys("Visual Studio Code");
        //     Thread.Sleep(tiempoEspera);
        //     //pulsamos el boton
        //     driver.FindElement(googleButtonSearch).Click();
        //     Thread.Sleep(tiempoEspera);
        //     // Establecemos el resultado
        //     var resultadoBusqueda = driver.FindElement(resultGoogleSearch);
        //     Assert.IsNotNull(resultadoBusqueda);
        //     driver.Quit();
        // }
        // NUEVO

        // [TestInitialize]
        // public void Setup()
        // {
        //     // Ruta al ChromeDriver
        //     string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");

        //     // Inicializa el WebDriver de Chrome con la ruta del driver
        //     driver = new ChromeDriver(chromeDriverPath);
        //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera implícito
        // }

        // [TestCleanup]
        // public void Teardown()
        // {
        //     // Cierra el navegador después de cada prueba
        //     driver.Quit();
        // }

        [TestMethod]
        public void Create_Get_ReturnCreateView()
        {
            IWebDriver driver = new ChromeDriver();
            // Ventana maximizada del navegador
            driver.Manage().Window.Maximize();
            Thread.Sleep(tiempoEspera);
            // Navega a la página de crear cliente
            driver.Navigate().GoToUrl("http://localhost:5043/ClienteSql/Create");
            Thread.Sleep(tiempoEspera);
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
