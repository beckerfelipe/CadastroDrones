using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Operacao
    {
        public int AeronaveId { get; private set; }
        public int OperadorId { get; private set; }

        public string ramoAtividade { get; private set; }
        public DateOnly dataValidade { get; private set; }
        public string tipoUso { get; private set; }

        public Operacao(int aeronaveId, int operadorId, string ramoAtividade, DateOnly dataValidade, string tipoUso)
        {
            AeronaveId = aeronaveId;
            OperadorId = operadorId;
            this.ramoAtividade = ramoAtividade;
            this.dataValidade = dataValidade;
            this.tipoUso = tipoUso;
        }

        public static void Insert(Operacao opera)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Operacao (Aeronave_Id, Operador_Id, Ramo_Atividade, Data_Validade, Tipo_Uso) VALUES (@AeronaveId, @OperadorId, @RamoAtividade, @DataValidade, @TipoUso)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@AeronaveId", opera.AeronaveId);
                command.Parameters.AddWithValue("@OperadorId", opera.OperadorId);
                command.Parameters.AddWithValue("@RamoAtividade", opera.ramoAtividade);
                command.Parameters.AddWithValue("@DataValidade", opera.dataValidade.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@TipoUso", opera.tipoUso);

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

        public static void Update(int aeronaveId, int operadorId, Operacao opera)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Operacao SET Ramo_Atividade = @RamoAtividade, Data_Validade = @DataValidade, Tipo_Uso = @TipoUso WHERE Aeronave_Id = @AeronaveId AND Operador_Id = @OperadorId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@RamoAtividade", opera.ramoAtividade);
                command.Parameters.AddWithValue("@DataValidade", opera.dataValidade.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@TipoUso", opera.tipoUso);
                command.Parameters.AddWithValue("@AeronaveId", aeronaveId);
                command.Parameters.AddWithValue("@OperadorId", operadorId);

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

        public static void Delete(int aeronaveId, int operadorId)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Operacao WHERE Aeronave_Id = @AeronaveId AND Operador_Id = @OperadorId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@AeronaveId", aeronaveId);
                command.Parameters.AddWithValue("@OperadorId", operadorId);

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
                string query = "SELECT * FROM Operacao";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {//TODO: corrigir o formato da data
                    Console.WriteLine(reader["Aeronave_Id"] + " - " + reader["Operador_Id"] + " - " + reader["Ramo_Atividade"] + " - " +reader["Data_Validade"] + " - " + reader["Tipo_Uso"]);
                }
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
