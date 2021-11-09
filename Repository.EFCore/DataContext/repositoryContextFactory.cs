using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore.DataContext
{
    class repositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            OptionsBuilder.UseSqlServer("Data Source=DESKTOP-GA6NCLU\\SQLEXPRESS;Initial Catalog=RepositoryDemoDB;Integrated Security=true;");

            return new RepositoryContext(OptionsBuilder.Options);
        }
    }
}
