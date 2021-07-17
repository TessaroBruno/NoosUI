using Noos.UI.Components;
using Noos.UI.Themes;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace NoosUIDemo {
 public partial class Form1 : NoosForm {
  private readonly ThemeManager noosTheme;
  public static ResourceManager language;
  public Form1() {
   Thread trd = new Thread(new ThreadStart(SplashRun));
   trd.Start();
   InitializeComponent();
   Thread.Sleep(1000);
   trd.Abort();

   noosTheme = ThemeManager.Instance;
   noosTheme.AddFormToManage(this);
   noosTheme.ColorScheme = new ColorScheme("themegray");

   noosSidebarLogo1.Image = global::NoosUIDemo.Properties.Resources.logo;

   /* Create Lang folder and file named like lang_it.resx, lang_en.resx in it
      Set file properties as Embedded Resource */
   language = new ResourceManager("NoosUIDemo.Lang.lang_" +
       System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
       Assembly.GetExecutingAssembly());
   noosLabel1.Text = language.GetString("MyText");
  }

  private void SplashRun() {
   Application.Run(new NoosSplashScreen("Sample App",
       new Bitmap(global::NoosUIDemo.Properties.Resources.logo)));
  }

  private void noosSidebarButton2_Click(object sender, System.EventArgs e) {
   NoosLogin login = new NoosLogin();
   login.ShowDialog();
  }

  private void noosSidebarButton1_Click(object sender, System.EventArgs e) {
   NoosDialog dialog = new Dialog();
   dialog.ShowNoosDialog();
  }

  private void noosSidebarButton3_Click(object sender, System.EventArgs e) {
   NoosNotification frm = new NoosNotification();
   frm.ShowNotification("Message to show");
  }
 }
}