using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Week6.Models
{
    public class CarPolicy
    {
        [Key]
        public int Number { get; set; }
        public DateTime DateStipulates { get; set; }
        public float InsuredAmmount { get; set; }
        public float MonthlyInstallment { get; set; }

        //per gestire collegamento uno a molti con client
        public String ClientCF { get; set; }
        public Client Client { get; set; }
    }
}
