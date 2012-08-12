[assembly: WebActivator.PreApplicationStartMethod(typeof(ShareIt.App_Start.ElmahMvc), "Start")]
namespace ShareIt.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}