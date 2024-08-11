using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ClientePostgresDataAccessLayer : IClienteDataAccessLayer
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=productos;Username=postgres;Password=root";

        public void AddCliente(ClienteSql cliente)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Cedula, Nombres, Apellidos, FechaNacimiento, Mail, Telefono, Estado) VALUES (@Cedula, @Nombres, @Apellidos, @FechaNacimiento, @Mail, @Telefono, @Estado)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteCliente(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM Clientes WHERE Codigo=@Codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();

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

        public ClienteSql GetClienteById(int id)
        {
            ClienteSql cliente = null;

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Codigo=@Codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();

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

        public void UpdateCliente(ClienteSql cliente)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Clientes SET Cedula=@Cedula, Nombres=@Nombres, Apellidos=@Apellidos, FechaNacimiento=@FechaNacimiento, Mail=@Mail, Telefono=@Telefono, Estado=@Estado WHERE Codigo=@Codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
