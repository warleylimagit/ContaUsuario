using System.ComponentModel.DataAnnotations;

namespace ContaUsuario.Mvc.Web.ViewModel
{
	public class ReseteViewModel
	{
		[Required(ErrorMessage = "Favor informar a senha antiga!")]
		[Display(Name = "Senha Antiga")]
		[DataType(DataType.Password)]
		public string SenhaAntiga { get; set; }

		[Required(ErrorMessage = "Favor informar a nova senha!")]
		[Display(Name = "Nova Senha")]
		[DataType(DataType.Password)]
		[MaxLength(128, ErrorMessage = "A senha pode conter no máximo 128 caracteres!")]
		public string NovaSenha { get; set; }

		[Required(ErrorMessage = "Favor confirmar a senha!")]
		[Display(Name = "Confirma Senha")]
		[DataType(DataType.Password)]
		[Compare("NovaSenha", ErrorMessage = "Não é igual a Nova Senha!")]
		public string ConfirmaSenha { get; set; }
	}
}