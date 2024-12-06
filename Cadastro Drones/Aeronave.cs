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
        public int Id { get; private set; }
        public string Codigo_Aeronave { get; private set; }
        public string Numero_Serie { get; private set; }

        public int IdModelo { get; private set; }
        public int IdFabricante { get; private set; }

        public Aeronave(int id, string codigo_Aeronave, string numero_Serie, int idModelo, int idFabricante)
        {
            Id = id;
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
                string query = "INSERT INTO Aeronave (Codigo_Aeronave, Numero_Serie, IdModelo, IdFabricante) VALUES (@Codigo_Aeronave, @Numero_Serie, @IdModelo, @IdFabricante)";
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
                string query = "UPDATE Aeronave SET Codigo_Aeronave = @Codigo_Aeronave, Numero_Serie = @Numero_Serie, IdModelo = @IdModelo, IdFabricante = @IdFabricante WHERE Id = @aeronaveId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Codigo_Aeronave", aeronave.Codigo_Aeronave);
                command.Parameters.AddWithValue("@Numero_Serie", aeronave.Numero_Serie);
                command.Parameters.AddWithValue("@IdModelo", aeronave.IdModelo);
                command.Parameters.AddWithValue("@IdFabricante", aeronave.IdFabricante);
                command.Parameters.AddWithValue("@Id", aeronaveId);

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

        public static void Delete(int aeronaveId)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Aeronave WHERE Id = @aeronaveId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", aeronaveId);

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
    }
}