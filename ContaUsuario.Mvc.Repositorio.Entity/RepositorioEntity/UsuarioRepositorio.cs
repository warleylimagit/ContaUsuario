using ContaUsuario.Mvc.Dados.Db;
using ContaUsuario.Mvc.Repositorio.Entity.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ContaUsuario.Mvc.Repositorio.Entity.RepositorioEntity
{
	public class UsuarioRepositorio : IRepositorio<TB_USUARIO, int>
	{
		private readonly DbContext _context;

		public UsuarioRepositorio()
		{
			_context = new UsuarioModel();
		}

		public async Task Alterar(TB_USUARIO entidade)
		{
			_context.Set<TB_USUARIO>().Attach(entidade);
			_context.Entry(entidade).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Excluir(TB_USUARIO entidade)
		{
			_context.Set<TB_USUARIO>().Attach(entidade);
			_context.Entry(entidade).State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}

		public async Task ExcluirPorId(int id)
		{
			TB_USUARIO _usuario = SelecionarPorId(id);
			await Excluir(_usuario);
		}

		public async Task Inserir(TB_USUARIO entidade)
		{
			_context.Set<TB_USUARIO>().Add(entidade);
			await _context.SaveChangesAsync();
		}

		public List<TB_USUARIO> Selecionar()
		{
			return _context.Set<TB_USUARIO>().ToList();
		}

		public TB_USUARIO SelecionarPorId(int id)
		{
			return _context.Set<TB_USUARIO>().Find(id);
		}
	}
}
