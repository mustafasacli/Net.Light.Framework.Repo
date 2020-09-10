using Net.Light.Framework.Base;
using Net.Light.Framework.ConnectionStringBuilding.PropertyBuilding;
using Net.Light.Framework.ConnectionStringBuilding.Test;
using System;
using System.Windows.Forms;

namespace Net.Light.Framework.ConnectionStringBuilding
{
    public partial class FrmSecureHash : Form
    {

        #region [ FrmSecureHash Ctor ]

        public FrmSecureHash()
        {
            try
            {
                InitializeComponent();
                chkConnectionStringContains.Checked = true;
                cmbxConnectionType.DataSource = Enum.GetValues(typeof(ConnectionTypes));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion


        #region [ Error Property ]

        public static string Error { get; set; }

        #endregion


        #region [ BuildProperties method ]

        private void BuildProperties(object sender, EventArgs e)
        {
            try
            {
                if (cmbxConnectionType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please, Choose a connectionType.");
                    return;
                }

                if (true == string.IsNullOrWhiteSpace(txtConnStr.Text))
                {
                    MessageBox.Show(
                       "Connection string can not be empty.",
                       "Warning!..");
                    return;
                }

                if (true == string.IsNullOrWhiteSpace(txtPropName.Text))
                {
                    MessageBox.Show(
                        "Connection Name can not be empty.",
                       "Warning!..");
                    return;
                }

                txtHashedString.ResetText();
                ConnectionTypes connType = (ConnectionTypes)cmbxConnectionType.Items[cmbxConnectionType.SelectedIndex];
                string propStr = PropertyBuilder.BuildNew(connType, txtPropName.Text, txtConnStr.Text, chkConnectionStringContains.Checked);
                txtHashedString.AppendText(propStr);
            }
            catch (Exception exc)
            {
                txtHashedString.ResetText();
                txtHashedString.AppendText(exc.Message + "\n" + exc.StackTrace);
            }
        }

        #endregion


        //Server=KRK; Initial Catalog=NorthWind;User Id=sa; Password=123123;
        #region [ Test method ]

        private void Test(object sender, EventArgs e)
        {
            if (cmbxConnectionType.SelectedIndex == -1)
            {
                MessageBox.Show("Please, Choose a connectionType.");
                return;
            }

            if (true == string.IsNullOrWhiteSpace(txtConnStr.Text))
            {
                MessageBox.Show(
                    "Connection string can not be empty.",
                    "Warning!..");
                return;
            }

            ConnectionTypes connType = (ConnectionTypes)cmbxConnectionType.Items[cmbxConnectionType.SelectedIndex];
            ConnectionTester.TestConnection(connType, txtConnStr.Text);
            MessageBox.Show(string.Format("{0}", Error), "Result");
        }

        #endregion

    }
}