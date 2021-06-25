using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Context;
using Test_Week6.Models;

namespace Test_Week6.Repository
{
    public class RepositoryCarPolicy : IRepositoryCarPolicy
    {
        public CarPolicy Create(CarPolicy item)
        {
            using (var ctx = new InsuranceContext())
            {
                if (item != null)
                {
                    try
                    {
                        
                        ctx.CarPolicies.Add(item);
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

        public ICollection<CarPolicy> GetAll()
        {
            using (var ctx = new InsuranceContext())
            {
                return ctx.CarPolicies.ToList();
            }
        }
    }
}
