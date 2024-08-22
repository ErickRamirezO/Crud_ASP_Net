using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public class IngresoStepDefinitions
    {
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
            var cliente = table.CreateInstance<ClienteSql>();
            _clienteSqlDataAccessLayer.AddCliente(cliente);
        }


        [Then(@"El resultado se ingresa en la BDD")]
        public void ThenElResultadoSeIngresaEnLaBDD(Table table)
        {
            var clienteEsperado = table.CreateInstance<ClienteSql>();

            var clienteObtenido = _clienteSqlDataAccessLayer.GetAllClientes()
                                .FirstOrDefault(c => c.Cedula == clienteEsperado.Cedula);

            clienteObtenido.Should().NotBeNull("El cliente debería estar en la base de datos");

            // Verificar que los campos del cliente obtenido coincidan con los del cliente esperado
            clienteObtenido.Apellidos.Should().Be(clienteEsperado.Apellidos);
            clienteObtenido.Nombres.Should().Be(clienteEsperado.Nombres);
            clienteObtenido.FechaNacimiento.Should().Be(clienteEsperado.FechaNacimiento);
            clienteObtenido.Mail.Should().Be(clienteEsperado.Mail);
            clienteObtenido.Telefono.Should().Be(clienteEsperado.Telefono);
            clienteObtenido.Saldo.Should().Be(clienteEsperado.Saldo);
            clienteObtenido.Estado.Should().Be(clienteEsperado.Estado);
        }
    }
}