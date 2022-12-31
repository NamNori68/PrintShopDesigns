using Microsoft.EntityFrameworkCore;

namespace PrintShopDesigns.Data
{
	public class AppContext : DbContext
	{
		public AppContext() { }
		public AppContext(DbContextOptions<AppContext> options) : base(options) {}
	}
}
