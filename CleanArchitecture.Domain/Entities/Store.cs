using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        public int BranchNumber { get; set; }
    }
}
