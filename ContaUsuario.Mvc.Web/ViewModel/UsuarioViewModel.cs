using System.ComponentModel.DataAnnotations;

namespace ContaUsuario.Mvc.Web.ViewModel
{
	public class UsuarioViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[MaxLength(128, ErrorMessage = "O máximo de caracteres permitidos são 128 caracteres!")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no seguinte formato: ###.###.###-##")]
		[Display(Name = "CPF")]
		[StringLength(14)]
		public string Cpf { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}