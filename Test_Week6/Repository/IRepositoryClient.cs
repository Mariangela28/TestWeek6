using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Models;

namespace Test_Week6.Repository
{
    public interface IRepositoryClient : IRepositoryCarPolicy<Client>
    {
        void AggiungiClienti(int clientCF, CarPolicy polizzaDaAggiungere);
        void AggiungiPolizza(int clientCF, CarPolicy polizzaDaAggiungere);
    }
}
