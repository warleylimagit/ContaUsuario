using ContaUsuario.Mvc.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContaUsuario.Mvc.Dados.Entity.TypeConfiguration
{
	public class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
	{
		public UsuarioTypeConfiguration()
		{
			ConfigurarNomeTabela();
			ConfigurarCamposTabela();
			ConfigurarChavePrimaria();
		}

		private void ConfigurarChavePrimaria()
		{
			HasKey(pk => pk.Id);
		}

		private void ConfigurarCamposTabela()
		{
			Property(p => p.Id)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
				.HasColumnName("ID");

			Property(p => p.Cpf)
				.IsRequired()
				.HasColumnName("CPF")
				.HasMaxLength(16);

			Property(p => p.Email)
				.IsRequired()
				.HasColumnName("EMAIL")
				.HasMaxLength(128);

			Property(p => p.Nome)
				.IsRequired()
				.HasColumnName("NOME")
				.HasMaxLength(128);

			Property(p => p.Senha)
				.IsRequired()
				.HasColumnName("SENHA")
				.HasMaxLength(128);

			Property(p => p.ConfirmaSenha)
				.IsRequired()
				.HasColumnName("CONFIRMA_SENHA")
				.HasMaxLength(128);
		}

		private void ConfigurarNomeTabela()
		{
			ToTable("TB_USUARIOS");
		}
	}
}
