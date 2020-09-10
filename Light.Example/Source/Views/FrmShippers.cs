using System;
using System.Windows.Forms;

namespace Light.Example.Source.Views
{
    public partial class FrmShippers : FrmBase
    {
        int _shipperId = -1;
        public FrmShippers()
            : this(-1)
        {
            InitializeComponent();
        }

        public FrmShippers(int shipperId)
            : base()
        {
            InitializeComponent();
            _shipperId = shipperId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {

        }
    }
}