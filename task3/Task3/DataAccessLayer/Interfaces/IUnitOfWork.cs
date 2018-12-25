using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.DataAccessLayer.Interfaces
{
    public class OrderContext : DbContext
    {     
        public DbSet<Order> Orders { get; set; }
    }
}
