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

        public static void ListarTodasOperacoesDetalhadas()
        {
            DatabaseConnection.Connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Todas_Operacoes", DatabaseConnection.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine(new string('-', 45));
            Console.WriteLine("|{0, -10}|{1, -10}|{2, -10}|{3, -10}|{4, -10}|{5, -10}|{6, -10}|{7, -10}|{8, -10}|{9, -10}|", "Operador_Id", "Aeronave_Id", "Ramo", "Uso", "Data", "Operador", "Aeronave", "Série", "Modelo", "Fabricante");
            Console.WriteLine(new string('-', 45));

            while (reader.Read())
            {
                Console.WriteLine("|{0, -10}|{1, -10}|{2, -10}|{3, -10}|{4, -10}|{5, -10}|{6, -10}|{7, -10}|{8, -10}|{9, -10}|",
                    reader["Operador_Id"], reader["Aeronave_Id"], reader["ramo_atividade"], reader["tipo_uso"], Convert.ToDateTime(reader["data_validade"]).ToString("dd-MM-yyyy"),
                    reader["nome_operador"], reader["codigo_aeronave"], reader["numero_serie"], reader["nome_modelo"], reader["nome_fabricante"]);
            }

            Console.WriteLine(new string('-', 45));
            DatabaseConnection.Connection.Close();
        }

        public static void ListarHistorico()
        {
            try
            {
                DatabaseConnection.Connection.Open();

                string query = "SELECT * FROM HISTORICO_OPERACOES";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine(new string('-', 85));
                Console.WriteLine("{0,42}", "HISTÓRICO DE OPERAÇÕES");
                Console.WriteLine(new string('-', 85));
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15} {4,-15}", "Aeronave_Id", "Operador_Id", "Ramo_Atividade", "Data_Validade", "Tipo_Uso");
                Console.WriteLine(new string('-', 85));

                while (reader.Read())
                {
                    DateTime dataValidade = Convert.ToDateTime(reader["data_validade"]);
                    string dataValidadeFormatada = dataValidade.ToString("dd-MM-yyyy");

                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15} {4,-15}",
                        reader["Aeronave_Id"],
                        reader["Operador_Id"],
                        reader["ramo_atividade"],
                        dataValidadeFormatada,
                        reader["tipo_uso"]);
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



        public static void List()   
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "SELECT * FROM Operacao";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine(new string('-', 85));
                Console.WriteLine("{0,42}", "OPERAÇÃO");
                Console.WriteLine(new string('-', 85));
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15} {4,-15}","Aeronave_Id", "Operador_Id", "Ramo_Atividade", "Data_Validade", "Tipo_Uso");
                Console.WriteLine(new string('-', 85));

                while (reader.Read())
                {
                    DateTime dataValidade = Convert.ToDateTime(reader["Data_Validade"]);
                    string dataFormatada = dataValidade.ToString("yyyy-MM-dd");

                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15} {4,-15}",
                        reader["Aeronave_Id"],
                        reader["Operador_Id"],
                        reader["Ramo_Atividade"],
                        dataFormatada,
                        reader["Tipo_Uso"]);
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
