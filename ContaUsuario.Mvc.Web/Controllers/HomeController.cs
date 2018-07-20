using ContaUsuario.Mvc.Dados.Db;
using ContaUsuario.Mvc.Repositorio.Entity.Interface;
using ContaUsuario.Mvc.Repositorio.Entity.RepositorioEntity;
using ContaUsuario.Mvc.Web.Filter;
using ContaUsuario.Mvc.Web.ViewModel;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ContaUsuario.Mvc.Web.Controllers
{
	public class HomeController : Controller
	{
		private IRepositorio<TB_USUARIO, int> _repositorio = new UsuarioRepositorio();
		
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel _viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var _usuario = _repositorio.Selecionar().Where(u => u.EMAIL == _viewModel.Email && u.SENHA == _viewModel.Senha)
									.FirstOrDefault();
																			  
					if (_usuario == null)
					{
						ViewBag.Alerta = "Email ou Senha incorreto!";
						return View();
					}

					AutorizaAttribute.Autenticado = true;
					AutorizaAttribute.SessionId = _usuario.ID;
					return RedirectToAction("Index", "Usuario");
				}

				return View(_viewModel);
			}
			catch (Exception ex)
			{
				return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
			}
		}

		public ActionResult Erro()
		{
			return View();
		}

		public ActionResult Logout()
		{
			AutorizaAttribute.Autenticado = false;

			return RedirectToAction("Login");
		}

		[Autoriza]
		public ActionResult Resete()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Autoriza]
		public ActionResult Resete(ReseteViewModel _viewModel)
		{
			try
			{
				var _usuario = _repositorio.Selecionar()
								.Where(u => u.SENHA == _viewModel.SenhaAntiga && u.ID == AutorizaAttribute.SessionId).FirstOrDefault();

				if (_usuario == null)
				{
					ViewBag.Alerta = "A senha antiga não está correta!";
					return View();
				}

				_usuario.SENHA = _viewModel.NovaSenha;
				_usuario.CONFIRMA_SENHA = _viewModel.ConfirmaSenha;

				_repositorio.Alterar(_usuario);
				return RedirectToAction("Index", "Usuario");
			}
			catch (Exception)
			{
				ViewBag.MensagemErro = "Falha ao cadastrar o Usuário!";
				return RedirectToAction("Erro", "Home");
			}
		}
	}
}