using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Voucher
    {
        public Guid Id { get; set; }

        public float Percent { get; set; }
        public int Quantity { get; set; }

        //abs
    }
}