using System.Web;
using System.Web.Optimization;

namespace ContaUsuario.Mvc.Web
{
	public class BundleConfig
	{
		// Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-3.3.1.slim.min.js"));                         //"~/Scripts/jquery-{version}.js",

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/jquerymasked").Include(
						"~/Scripts/jquery-1.2.6.pack.js",
						"~/Scripts/jquery.maskedinput-1.1.4.pack.js"
				));


			bundles.Add(new ScriptBundle("~/bundles/popper").Include(
						"~/Scripts/popper.min.js"));

			// Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
			// pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.min.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.min.css",
					  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Login/css").Include(
				"~/Content/bootstrap.min.css",
				"~/Content/Signin.css"));
		}
	}
}
