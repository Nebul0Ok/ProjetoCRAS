using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbasteceCRAS.MVVM.Models
{
    public class Remessa
    {
        public DateTime DataRecebimento { get; set; }
        public int Quantidade {  get; set; }
        public DateTime DataValidade { get; set; }


        public Remessa()
        {
            
        }
    }
}
