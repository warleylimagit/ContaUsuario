using ContaUsuario.Mvc.Dados.Db;
using ContaUsuario.Mvc.Repositorio.Entity.Interface;
using ContaUsuario.Mvc.Repositorio.Entity.RepositorioEntity;
using ContaUsuario.Mvc.Web.AutoMapper;
using ContaUsuario.Mvc.Web.Filter;
using ContaUsuario.Mvc.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace ContaUsuario.Mvc.Web.Controllers
{
	[Autoriza]
	public class UsuarioController : Controller
    {
		private IRepositorio<TB_USUARIO, int> _repositorio = new UsuarioRepositorio();
		private bool retorno = false;

		// GET: Usuario
		public ActionResult Index()
        {
			List<TB_USUARIO> _usuarioList = _repositorio.Selecionar();
			List<UsuarioViewModel> _usuarios = AutoMapperManager.Instancia.Mapper.Map<List<TB_USUARIO>, List<UsuarioViewModel>>(_usuarioList);
			
			return View(_usuarios);
        }

		public ActionResult Cadastro()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Cadastro(RegistraViewModel _viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (ValidaCadastro(0, _viewModel.Cpf, _viewModel.Email))
					{
						return View();
					}

					var _usu = _repositorio.Selecionar().Any(u => u.CPF == _viewModel.Cpf);
					if(_usu)
					{
						ViewBag.Alerta = "Já existe um usuário cadastrado com este CPF!";
						return View();
					}
					
					TB_USUARIO _usuario = AutoMapperManager.Instancia.Mapper.Map<RegistraViewModel, TB_USUARIO>(_viewModel);

					await _repositorio.Inserir(_usuario);
					return RedirectToAction("Index");
				}

				return View(_viewModel);
			}
			catch (Exception)
			{
				ViewBag.MensagemErro = "Falha ao cadastrar o Usuário!";
				return RedirectToAction("Erro", "Home");
			}
		}

		public ActionResult Editar(int? id)
		{
			if (!id.HasValue)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			TB_USUARIO _usuario = _repositorio.SelecionarPorId(id.Value);
			if (_usuario == null)
				return HttpNotFound();

			return View(AutoMapperManager.Instancia.Mapper.Map<TB_USUARIO, UsuarioViewModel>(_usuario));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Editar(UsuarioViewModel _viewModel)
		{
			try
			{
				if(ModelState.IsValid)
				{
					if (ValidaCadastro(_viewModel.Id, _viewModel.Cpf, _viewModel.Email))
					{
						return View();
					}

					TB_USUARIO _usuario = AutoMapperManager.Instancia.Mapper.Map<UsuarioViewModel, TB_USUARIO>(_viewModel);
					TB_USUARIO _usuarioBanco = _repositorio.SelecionarPorId(_usuario.ID);

					_usuarioBanco.CPF = _usuario.CPF;
					_usuarioBanco.EMAIL = _usuario.EMAIL;
					_usuarioBanco.NOME = _usuario.NOME;

					await _repositorio.Alterar(_usuarioBanco);
					return RedirectToAction("Index");
				}

				return View(_viewModel);
			}
			catch (DbEntityValidationException e)
			{
				return null;
			}
			catch (Exception)
			{
				ViewBag.MensagemErro = "Falha ao editar o Usuário!";
				return RedirectToAction("Erro", "Home");
			}
		}

		public ActionResult Deletar(int? id)
		{
			if (!id.HasValue)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			TB_USUARIO _usuario = _repositorio.SelecionarPorId(id.Value);
			if (_usuario == null)
				return HttpNotFound();

			return View(AutoMapperManager.Instancia.Mapper.Map<TB_USUARIO, UsuarioViewModel>(_usuario));
		}

		[HttpPost, ActionName("Deletar")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Deletar(int id)
		{
			try
			{
				await _repositorio.ExcluirPorId(id);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ViewBag.MensagemErro = "Falha ao deletar o Usuário!";
				return RedirectToAction("Erro", "Home");
			}
		}

		private bool ValidaCadastro(int id, string cpf, string email)
		{			
			if(!string.IsNullOrEmpty(cpf))
			{
				var _usu = id == 0 ? _repositorio.Selecionar().Any(u => u.CPF == cpf) : _repositorio.Selecionar().Any(u => u.CPF == cpf && u.ID != id);
				if (_usu)
				{
					ViewBag.Alerta = "Já existe um usuário cadastrado com este CPF!";
					retorno = true;
				}
				else
					retorno = false;
			}

			var _usu1 = id == 0 ? _repositorio.Selecionar().Any(u => u.EMAIL == email) : _repositorio.Selecionar().Any(u => u.EMAIL == email && u.ID != id);
			if (_usu1 && (!retorno)) //Se tiver um CPF igual, valida o email depois
			{
				ViewBag.Alerta = "Já existe um usuário cadastrado com este Email!";
				retorno = true;
			}
			else if(!_usu1 && !retorno)
				retorno = false;

			return retorno;
		}
    }
}