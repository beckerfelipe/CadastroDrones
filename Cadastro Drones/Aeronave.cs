using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Aeronave
    {
        public string Codigo_Aeronave { get; private set; }
        public string Numero_Serie { get; private set; }

        public int IdModelo { get; private set; }
        public int IdFabricante { get; private set; }

        public Aeronave(string codigo_Aeronave, string numero_Serie, int idModelo, int idFabricante)
        {
            Codigo_Aeronave = codigo_Aeronave;
            Numero_Serie = numero_Serie;
            IdModelo = idModelo;
            IdFabricante = idFabricante;
        }

        public static void Insert(Aeronave aeronave)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Aeronave (Codigo_Aeronave, Numero_Serie, modelo_id, fabricante_id) VALUES (@Codigo_Aeronave, @Numero_Serie, @IdModelo, @IdFabricante)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Codigo_Aeronave", aeronave.Codigo_Aeronave);
                command.Parameters.AddWithValue("@Numero_Serie", aeronave.Numero_Serie);
                command.Parameters.AddWithValue("@IdModelo", aeronave.IdModelo);
                command.Parameters.AddWithValue("@IdFabricante", aeronave.IdFabricante);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void Update(int aeronaveId, Aeronave aeronave)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Aeronave SET Codigo_Aeronave = @Codigo_Aeronave, Numero_Serie = @Numero_Serie, Modelo_id = @IdModelo, Fabricante_id = @IdFabricante WHERE aeronave_id = @aeronaveId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Codigo_Aeronave", aeronave.Codigo_Aeronave);
                command.Parameters.AddWithValue("@Numero_Serie", aeronave.Numero_Serie);
                command.Parameters.AddWithValue("@IdModelo", aeronave.IdModelo);
                command.Parameters.AddWithValue("@IdFabricante", aeronave.IdFabricante);
                command.Parameters.AddWithValue("@aeronaveId", aeronaveId);

                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void Delete(int Id)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Aeronave WHERE aeronave_id = @aeronaveId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", Id);

                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void List()
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "SELECT * FROM Aeronave";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine(new string('-', 75));
                Console.WriteLine("{0,37}", "AERONAVE");
                Console.WriteLine(new string('-', 75));
                Console.WriteLine("{0,-12} {1,-18} {2,-18} {3,-10} {4,-15}", "Aeronave_Id", "Codigo_Aeronave", "Numero_Serie", "Modelo_Id", "Fabricante_Id");
                Console.WriteLine(new string('-', 75));

                while (reader.Read())
                {
                    Console.WriteLine("{0,-12} {1,-18} {2,-18} {3,-10} {4,-15}",
                        reader["Aeronave_Id"],
                        reader["Codigo_Aeronave"],
                        reader["Numero_Serie"],
                        reader["modelo_id"],
                        reader["fabricante_id"]);
                }
                Console.WriteLine("");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }
    }
}