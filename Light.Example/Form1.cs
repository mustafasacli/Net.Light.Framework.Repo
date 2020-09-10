using Light.Example.Source.BO;
using Light.Example.Source.DL;
using System.Windows.Forms;

namespace Light.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            using (CategoriesDL catDL = new CategoriesDL())
            {
                Categories cat = new Categories();
                grdVw.DataSource = catDL.GetTable(cat);//catDL.Categories; //catDL.GetTable(cat);
                grdVw.Refresh();
                cat.CategoryName = "MyNew Category";
                cat.Description = "New Added Category";
                //cat.Picture = File.ReadAllBytes(@"C:\Users\mustafa\Desktop\cay.jpg");
                //cat.CategoryID = catDL.InsertAndGetId(cat);
                MessageBox.Show(cat.CategoryID.ToString());
                //grdVw.DataSource = catDL.GetTable(cat);
                grdVw.Refresh();
            }
        }
    }
}