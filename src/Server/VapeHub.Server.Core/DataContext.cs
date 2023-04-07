using Microsoft.EntityFrameworkCore;

namespace VapeHub.Server.Core
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) 
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Seed();
			base.OnModelCreating(builder);
		}
	}
}