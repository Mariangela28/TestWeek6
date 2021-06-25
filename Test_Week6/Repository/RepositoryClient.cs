using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Context;
using Test_Week6.Models;

namespace Test_Week6.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        

        public Client Create(Client item)
        {
            using (var ctx = new InsuranceContext())
            {
                if (item != null)
                {
                    try
                    {
                        
                        ctx.Clients.Add(item);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            return item;
        }

        public ICollection<Client> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
