using Light.Example.Source.Variables;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Light.Example.Source.Views
{
    public class FrmBase : System.Windows.Forms.Form
    {
        protected ResourceManager formResource;
        protected ResourceManager messageResource;

        protected FrmBase()
            : base()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppVariables.AppCultureInfo);
            formResource =
                new ResourceManager("Bdy.InCareAdmin.Resources.ControlResources.WinFormResource", typeof(FrmBase).Assembly);
            messageResource =
                new ResourceManager("Bdy.InCareAdmin.Resources.MessageResources.AppMessages", typeof(FrmBase).Assembly);
        }
    }
}