using System.ComponentModel.DataAnnotations;


namespace ContaUsuario.Mvc.Web.ViewModel
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Favor informar o E-mail!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Favor informar a Senha!")]
		[DataType(DataType.Password)]
		public string Senha { get; set; }
	}
}