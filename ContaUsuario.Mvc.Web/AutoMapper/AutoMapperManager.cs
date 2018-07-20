using AutoMapper;
using System;
using ContaUsuario.Mvc.Web.ViewModel;
using ContaUsuario.Mvc.Dados.Db;

namespace ContaUsuario.Mvc.Web.AutoMapper
{
	public class AutoMapperManager
	{
		private static readonly Lazy<AutoMapperManager> _instance
			= new Lazy<AutoMapperManager>(() =>
			{
				return new AutoMapperManager();
			});

		public static AutoMapperManager Instancia
		{
			get { return _instance.Value; }
		}

		private MapperConfiguration _config;

		public IMapper Mapper
		{
			get { return _config.CreateMapper(); }
		}

		private AutoMapperManager()
		{
			_config = new MapperConfiguration((cfg) =>
			{
				cfg.CreateMap<RegistraViewModel, TB_USUARIO>();
				cfg.CreateMap<TB_USUARIO, RegistraViewModel>()
				.ForSourceMember(u => u.CONFIRMA_SENHA, opt =>
				{
					opt.Ignore();
				})
				.ForSourceMember(u => u.SENHA, opt =>
				{
					opt.Ignore();
				});

				cfg.CreateMap<TB_USUARIO, UsuarioViewModel>()
				.ForSourceMember(u => u.SENHA, opt =>
				{
					opt.Ignore();
				})
				.ForSourceMember(u => u.CONFIRMA_SENHA, opt =>
				{
					opt.Ignore();
				});

				cfg.CreateMap<UsuarioViewModel, TB_USUARIO>();

				cfg.CreateMap<LoginViewModel, TB_USUARIO>();				
			});
		}
	}
}