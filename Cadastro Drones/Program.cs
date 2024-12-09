using System.Reflection.Metadata;

namespace Cadastro_Drones
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            DatabaseConnection.Start();
            Menu.MostrarMenu();
        }
    }
}
