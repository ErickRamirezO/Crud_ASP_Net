using TechTalk.SpecFlow;
using WebApplication1.Data;
using WebApplication1.Models;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public class IngresoStepDefinitions
    {
        // definir la clase que se necesita para la prueba en este caso está en el dataccesslayer
        public readonly ClienteSqlDataAccessLayer _clienteSqlDataAccessLayer = new ClienteSqlDataAccessLayer();

        [Given(@"Llenar los campos de la BDD")]
        public void GivenLlenarLosCamposDeLaBDD(Table table)
        {
            var dataTable = table.Rows.Count();
            dataTable.Should().BeGreaterThanOrEqualTo(1);
        }

        [When(@"El registro se ingresa en la BDD")]
        public void WhenElRegistroSeIngresaEnLaBDD(Table table)
        {
            var cliente = table.CreateInstance<ClienteSql>.ToList();
            ClienteSql clienteSql = new ClienteSql();
            foreach (var item in cliente)
            {
                clienteSql.Cedula = item.Cedula;
                clienteSql.Apellidos = item.Apellidos;
                clienteSql.Nombres = item.Nombres;
                clienteSql.FechaNacimiento = item.FechaNacimiento;
                clienteSql.Mail = item.Mail;
                clienteSql.Telefono = item.Telefono;
                clienteSql.Estado = item.Estado;
                clienteSql.Saldo = item.Saldo;
            }
            _clienteSqlDataAccessLayer.AddCliente(clienteSql);
        }

        [Then(@"El resultado se ingresa en la BDD")]
        public void ThenElResultadoSeIngresaEnLaBDD(Table table)
        {
            int resultado = table.Rows.Count();
            resultado.Should().BeGreaterThanOrEqualTo(1);
            // como obtener de la base de datos y saber a manera de prueba si se ingresó correctamente
            var registrosIngresados = _clienteSqlDataAccessLayer.GetClientes(); // Obtener los registros de la base de datos
            registrosIngresados.Should().Contain(clienteSql); // Verificar si el cliente se ingresó correctamente
        }
    }
}