using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaUsuario.Mvc.Repositorio.Entity.Interface
{
	public interface IRepositorio<TEntidade, TChave> where TEntidade : class
	{
		List<TEntidade> Selecionar();
		TEntidade SelecionarPorId(TChave id);
		Task Inserir(TEntidade entidade);
		Task Alterar(TEntidade entidade);
		Task Excluir(TEntidade entidade);
		Task ExcluirPorId(TChave id);
	}
}
