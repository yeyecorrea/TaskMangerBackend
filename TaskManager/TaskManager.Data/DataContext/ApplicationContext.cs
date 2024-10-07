using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Data.DataContext
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Tasked> taskeds { get; set; }
        public DbSet<TaskedTag> taskedTags { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<Priority> priorities { get; set; }
        public DbSet<HistoryChange> historyChanges { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<State> states { get; set; }
    }
}
