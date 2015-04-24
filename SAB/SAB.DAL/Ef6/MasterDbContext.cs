using System.Data.Entity;
using SAB.Entities;
using SAB.Framework.DbRepository.Ef6;
using SAB.Framework.DbRepository.Ef6.DbInitializer;

namespace SAB.DAL.Ef6
{
	public class MasterOrgDbContext : DataContext
	{

		static MasterOrgDbContext()
		{
			Database.SetInitializer<MasterOrgDbContext>(new CreateDbIfNotExists<MasterOrgDbContext>());
		}

		public MasterOrgDbContext() : this("MasterDb") { }

		public MasterOrgDbContext(string theNameOrConnectionString) : base(theNameOrConnectionString) { }

		public DbSet<Page> Pages { get; set; }
		public DbSet<Template> Templates { get; set; }
	}
}
