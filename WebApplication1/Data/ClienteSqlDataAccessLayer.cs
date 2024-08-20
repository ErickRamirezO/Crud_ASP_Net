using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ClienteSqlDataAccessLayer : IClienteDataAccessLayer
    {
        private readonly string connectionString = "Data Source=DESKTOP-6E8QHVK\\ERICK; Initial Catalog=dbproductos; user ID=erick; Password=erick";

        // Obtener todos los clientes
        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        Saldo = Convert.ToDecimal(reader["Saldo"]) // Agregado el campo Saldo
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        Saldo = Convert.ToDecimal(reader["Saldo"]) // Agregado el campo Saldo
                    };
                }
                con.Close();
            }
            return cliente;
        }

        // Agregar un nuevo cliente
        public void AddCliente(ClienteSql cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Saldo", cliente.Saldo); // Agregado el campo Saldo

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Actualizar un cliente existente
        public void UpdateCliente(ClienteSql cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Saldo", cliente.Saldo); // Agregado el campo Saldo

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Eliminar un cliente por ID
        public void DeleteCliente(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
