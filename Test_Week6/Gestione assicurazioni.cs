using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Models;
using Test_Week6.Repository;

namespace Test_Week6
{
    public class Gestione_assicurazioni
    {
        static IRepositoryClient repoClient = new RepositoryClient();
        static IRepositoryCarPolicy repoCarPolicy = new RepositoryCarPolicy();

        internal static bool SchermoMenu()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Aggiungi clienti");
            Console.WriteLine("2. Aggiungi una polizza");
            Console.WriteLine("3. Visualizza dati");
            Console.WriteLine("0. Per uscire");
            int scelta = VerificaInput(3);
            return GestireScelta(scelta);
        }

        private static int VerificaInput(int v)
        {
            Console.Write("Scelta ->");
            bool verifica = Int32.TryParse(Console.ReadLine(), out int scelta);
            while (scelta > v || scelta < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        private static bool GestireScelta(int scelta)
        {
            
                bool continua = true;
                switch (scelta)
                {
                    case 1:
                        AggiungiClienti();
                        break;
                    case 2:
                        AggiungiPolizze();
                        break;
                    case 3:
                        Stampa();
                        break;
                    default:
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                }
                return continua;
            }

        private static void Stampa()
        {
            throw new NotImplementedException();
        }

        private static void AggiungiPolizze()
        {
            CarPolicy polizzaDaAggiungere;
            Console.WriteLine("Che tipo di polizza vuoi inserire?");
            int tipoPolizza = VerificaInput(2);
            Console.WriteLine("Inserisci il numero");
            int number = Console.Read();
            Console.WriteLine("Inserisci la data della stipula");
            bool verificaData = DateTime.TryParse(Console.ReadLine(), out DateTime dateStipulates);
            
            Console.WriteLine("inserire importo assicurato");
            bool verifica = float.TryParse(Console.ReadLine(), out float insuredAmmount);
            Console.WriteLine("Inserire la rata mensile");
            bool controllo = float.TryParse(Console.ReadLine(), out float monthlyInstallment);
            //verifica true 
            if (tipoPolizza == 2)
            {
                Console.WriteLine("Inserisci la targa");
                string plate = Console.ReadLine();
                Console.WriteLine("Inserire la cilindrata");
                int piston = Console.Read();
                
                
                polizzaDaAggiungere = new RCauto()
                {
                    Number = number,
                    DateStipulates = dateStipulates,
                    InsuredAmmount = insuredAmmount,
                    MonthlyInstallment = monthlyInstallment,
                    Plate = plate,
                    Piston = piston
                };
            }
            else if (tipoPolizza == 3)
            {
                Console.WriteLine("Inserisci la percentuale coperta");
                int percentageCovered = Console.Read();
                polizzaDaAggiungere = new Robbery()
                {
                    Number = number,
                    DateStipulates = dateStipulates,
                    InsuredAmmount = insuredAmmount,
                    MonthlyInstallment = monthlyInstallment,
                    PercentageCovered = percentageCovered
                };
            }
            else if(tipoPolizza == 4)
            {
                Console.WriteLine("Inserire età dell'assicurato");
                int yearsInsured = Console.Read();
                polizzaDaAggiungere = new Life()
                {
                    Number = number,
                    DateStipulates = dateStipulates,
                    InsuredAmmount = insuredAmmount,
                    MonthlyInstallment = monthlyInstallment,
                    YearsInsured = yearsInsured
                };
            }
            var carPolicies = repoCarPolicy.GetAll();
            if (carPolicies.Count == 0)
            {
                Console.WriteLine("Non ci sono clienti");
                return;
            }
            else
            {
                StampaClienti(clients);
                var numMax = clients.Max(r => r.clientCF);
                int clientCF = VerificaInput(numMax);
                repoClient.AggiungiPolizza(clientCF, polizzaDaAggiungere);
            }
        }

        

        private static void StampaClienti(ICollection<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        private static void AggiungiClienti()
        {
            Console.WriteLine("Inserire codice fiscale");
            string cf = Console.ReadLine();
            Console.WriteLine("Inserire il nome");
            string firstName = Console.ReadLine();
            Console.WriteLine("Inserire il cognome");
            string lastName = Console.ReadLine();
            Console.WriteLine("Inserire l'indirizzo");
            string address = Console.ReadLine();

            var clienteCreato = repoClient.Create(new Client()
            {
                CF = cf,
                FirstName = firstName,
                LastName = lastName,
                Address = address


            }); 

            if (clienteCreato != null)
            {
                Console.WriteLine(clienteCreato);
            }
            else
            {
                Console.WriteLine("Operazione non riuscita");
            }
        }
    }

        
    }

