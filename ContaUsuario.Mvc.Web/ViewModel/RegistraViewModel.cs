using System.ComponentModel.DataAnnotations;

namespace ContaUsuario.Mvc.Web.ViewModel
{
	public class RegistraViewModel
	{
		[Required(ErrorMessage = "Campo Obrigatório!")]
		[MaxLength(128, ErrorMessage = "O máximo de caracteres permitidos são 128 caracteres!")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no seguinte formato: ###.###.###-##")]
		[Display(Name = "CPF")]
		public string Cpf { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[DataType(DataType.Password)]
		[MaxLength(128, ErrorMessage = "A senha deve conter no máximo 128 caracteres!")]
		public string Senha { get; set; }

		[Display(Name = "Confirmação de Senha")]
		[DataType(DataType.Password)]
		[Compare("Senha", ErrorMessage = "A Senha e a Confirmação de Senha não estão iguais!")]
		public string ConfirmaSenha { get; set; }
	}
}