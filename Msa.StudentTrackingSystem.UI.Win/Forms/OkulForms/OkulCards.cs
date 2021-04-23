using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms
{
    public partial class OkulCards : BaseCardsForm
    {
        public OkulCards()
        {
            InitializeComponent();

            OkulBll bll = new OkulBll();
            grid.DataSource = bll.List(null);
        }
    }
}