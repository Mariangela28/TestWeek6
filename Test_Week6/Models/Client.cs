using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Week6.Models
{
    public class Client
    {
        [Key]
        public String CF { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }

        //per gestire collegamento un oa molti con carpolicy
        public ICollection<CarPolicy> CarPolicies { get; set; } = new List<CarPolicy>();
    }
}
