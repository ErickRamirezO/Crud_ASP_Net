using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ClienteMySqlDataAccessLayer : IClienteDataAccessLayer
    {
        private readonly string connectionString = "Server=localhost; Port=3306; Database=dbproductos; User ID=root; Password=;";

        // Obtener todos los clientes
        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Clientes;", con); // Consulta SQL directa

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClienteSql cliente = new ClienteSql
                    {
                        Codigo = Convert.ToInt32(reader["Codigo"]),
                        Cedula = reader["Cedula"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                    lst.Add(cliente);
                }
                con.Close();
            }
            return lst;
        }

        // Obtener un cliente por ID
        public ClienteSql GetClienteById(int id)
        {
            ClienteSql cliente = null;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Clientes WHERE Codigo = @Codigo;", con); // Consulta SQL directa
                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cliente = new ClienteSql
                    {
                        Codigo = Convert.ToInt32(reader["Codigo"]),
                        Cedula = reader["Cedula"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                }
                con.Close();
            }
            return cliente;
        }

        // Agregar un nuevo cliente
        public void AddCliente(ClienteSql cliente)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Clientes (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Estado) " +
                    "VALUES (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Estado);", con); // Consulta SQL directa

                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Actualizar un cliente existente
        public void UpdateCliente(ClienteSql cliente)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE Clientes SET Cedula = @Cedula, Apellidos = @Apellidos, Nombres = @Nombres, " +
                    "FechaNacimiento = @FechaNacimiento, Mail = @Mail, Telefono = @Telefono, Estado = @Estado " +
                    "WHERE Codigo = @Codigo;", con); // Consulta SQL directa

                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Eliminar un cliente por ID
        public void DeleteCliente(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Clientes WHERE Codigo = @Codigo;", con); // Consulta SQL directa
                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("No se encontró el cliente para eliminar.");
                }
                con.Close();
            }
        }
    }
}
