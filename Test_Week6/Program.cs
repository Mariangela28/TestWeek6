using System;

namespace Test_Week6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                continua = Gestione_assicurazioni.SchermoMenu();
            }
        }
    }
}
