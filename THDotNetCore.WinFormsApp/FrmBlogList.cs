using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THDotNetCore.Shared;
using THDotNetCore.WinFormsApp.Models;
using THDotNetCore.WinFormsApp.Queries;

namespace THDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvBlogs.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            LoadBlogList();
        }

        private void LoadBlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogRead);
            dgvBlogs.DataSource = lst;
        }

        private void dgvBlogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int blogId = Convert.ToInt32(dgvBlogs.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frmBlog = new FrmBlog(blogId);
                frmBlog.ShowDialog();
            }
            else if(e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?" , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult.Equals(DialogResult.No)) return;
                DeleteBlog(blogId);
            }
            else
            {
                return;
            }

            LoadBlogList();
            #region test with switch case
            //int index = e.ColumnIndex;
            //EnumFormControlType enumFormControlType = (EnumFormControlType)index;
            //switch (enumFormControlType)
            //{
            //    case EnumFormControlType.None:
            //        break;
            //    case EnumFormControlType.Edit:
            //        break;
            //    case EnumFormControlType.Delete:
            //        break;
            //    default:
            //        MessageBox.Show("Invalid Case.");
            //        break;
            //}
            #endregion
        }

        private void DeleteBlog(int id)
        {
            string query = @"Delete from [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleted Successful." : "Deleted Failed";
            MessageBox.Show(message);
        }
    }
}
