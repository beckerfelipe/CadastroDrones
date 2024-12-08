using System.Reflection.Metadata;

namespace Cadastro_Drones
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            DatabaseConnection.Start();
            Operador.List();
            Aeronave.List();
            Fabricante.List();
            Modelo.List();
            Operacao.List();
            Fabricante.Delete(1);
            Operacao.List();
        }
    }
}
