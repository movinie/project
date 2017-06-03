using System.Web.Optimization;

namespace MoviesCatalog.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/*.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}