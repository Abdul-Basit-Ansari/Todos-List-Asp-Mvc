using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodosList.Models;

namespace TodosList.Data
{
    public class TodosContext : DbContext
    {
        public TodosContext (DbContextOptions<TodosContext> options)
            : base(options)
        {
        }

        public DbSet<TodosList.Models.Todos> Todos { get; set; } = default!;
    }
}
