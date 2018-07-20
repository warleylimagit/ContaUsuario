namespace ContaUsuario.Mvc.Dados.Db
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class UsuarioModel : DbContext
	{
		public UsuarioModel()
			: base("name=UsuarioEntities")
		{
		}

		public virtual DbSet<TB_USUARIO> TB_USUARIO { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
