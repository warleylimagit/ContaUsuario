using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContaUsuario.Mvc.Web.Filter
{
	public class AutorizaAttribute : FilterAttribute, IAuthorizationFilter
	{
		public static bool Autenticado
		{
			get
			{
				if (HttpContext.Current.Session["Autentica"] != null)
					return (bool)HttpContext.Current.Session["Autentica"];
				return false;
			}
			set
			{
				HttpContext.Current.Session["Autentica"] = value;
			}
		}

		public static int SessionId
		{
			get
			{
				if (HttpContext.Current.Session["SessionId"] != null)
					return (int)HttpContext.Current.Session["SessionId"];
				return 0;
			}
			set
			{
				HttpContext.Current.Session["SessionId"] = value;
			}
		}

		public AutorizaAttribute()
		{

		}

		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if(!Autenticado)
				filterContext.Result = new RedirectToRouteResult(
					new RouteValueDictionary {{ "Controller", "Home" },
									  { "Action", "Login" } });
		}
	}
}