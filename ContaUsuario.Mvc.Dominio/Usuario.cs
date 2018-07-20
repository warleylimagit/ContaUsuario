using System;

namespace ContaUsuario.Mvc.Dominio
{
	public class Usuario
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public string Cpf { get; set; }

		public string Email { get; set; }

		public string Senha { get; set; }

		public string ConfirmaSenha { get; set; }
	}
}
