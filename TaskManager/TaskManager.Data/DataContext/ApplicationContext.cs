using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.DataContext
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}
