using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Opera
    {
        public int AeronaveId { get; private set; }
        public int OperadorId { get; private set; }

        public string ramoAtividade { get; private set; }
        public string dataValidade { get; private set; }
        public string tipoUso { get; private set; }

        public Opera(int aeronaveId, int operadorId, string ramoAtividade, string dataValidade, string tipoUso)
        {
            AeronaveId = aeronaveId;
            OperadorId = operadorId;
            this.ramoAtividade = ramoAtividade;
            this.dataValidade = dataValidade;
            this.tipoUso = tipoUso;
        }

        public static void Insert(Opera opera)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Opera (AeronaveId, OperadorId, RamoAtividade, DataValidade, TipoUso) VALUES (@AeronaveId, @OperadorId, @RamoAtividade, @DataValidade, @TipoUso)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@AeronaveId", opera.AeronaveId);
                command.Parameters.AddWithValue("@OperadorId", opera.OperadorId);
                command.Parameters.AddWithValue("@RamoAtividade", opera.ramoAtividade);
                command.Parameters.AddWithValue("@DataValidade", opera.dataValidade);
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

        public static void Update(int aeronaveId, int operadorId, Opera opera)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Opera SET RamoAtividade = @RamoAtividade, DataValidade = @DataValidade, TipoUso = @TipoUso WHERE AeronaveId = @AeronaveId AND OperadorId = @OperadorId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@RamoAtividade", opera.ramoAtividade);
                command.Parameters.AddWithValue("@DataValidade", opera.dataValidade);
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
                string query = "DELETE FROM Opera WHERE AeronaveId = @AeronaveId AND OperadorId = @OperadorId";
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
    }
}
