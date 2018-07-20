using ContaUsuario.Mvc.Dados.Entity.TypeConfiguration;
using ContaUsuario.Mvc.Dominio;
using System.Data.Entity;

namespace ContaUsuario.Mvc.Dados.Entity.Context
{
	public class UsuariosContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
		}
	}
}
