// using WebApplication1.Models;
// using Npgsql;
// using System;
// using System.Collections.Generic;
// using System.Data;

// namespace WebApplication1.Data
// {
//     public class ClientPostgresDataAccessLayer
//     {
//         // Realizar la conexión a la base de datos, connection string
//         string connectionString = "Host=localhost;Port=5432;Database=productos;Username=postgres;Password=root";

//         // Método para extraer la lista de clientes
//         public IEnumerable<ClientePostgres> GetAllClientes()
//         {
//             List<ClientePostgres> lst = new List<ClientePostgres>();

//             using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//             {
//                 // Se debe tener una transacción en PostgreSQL
//                 NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Clientes", con);
//                 cmd.CommandType = CommandType.Text;

//                 con.Open();
//                 NpgsqlDataReader reader = cmd.ExecuteReader();

//                 while (reader.Read())
//                 {
//                     ClientePostgres client = new ClientePostgres
//                     {
//                         Codigo = Convert.ToInt32(reader["Codigo"]),
//                         Cedula = reader["Cedula"].ToString(),
//                         Apellidos = reader["Apellidos"].ToString(),
//                         Nombres = reader["Nombres"].ToString(),
//                         FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
//                         Mail = reader["Mail"].ToString(),
//                         Telefono = reader["Telefono"].ToString(),
//                         Estado = Convert.ToBoolean(reader["Estado"])
//                     };

//                     lst.Add(client);
//                 }
//                 con.Close();
//             }
//             return lst;
//         }

//         // Método para imprimir los datos en la consola
//         public void PrintAllClientes()
//         {
//             IEnumerable<ClientePostgres> clientes = GetAllClientes();
//             foreach (ClientePostgres client in clientes)
//             {
//                 Console.WriteLine("Codigo: " + client.Codigo);
//                 Console.WriteLine("Cedula: " + client.Cedula);
//                 Console.WriteLine("Apellidos: " + client.Apellidos);
//                 Console.WriteLine("Nombres: " + client.Nombres);
//                 Console.WriteLine("FechaNacimiento: " + client.FechaNacimiento);
//                 Console.WriteLine("Mail: " + client.Mail);
//                 Console.WriteLine("Telefono: " + client.Telefono);
//                 Console.WriteLine("Estado: " + client.Estado);
//                 Console.WriteLine("----------------------------");
//             }
//         }
//     }
// }