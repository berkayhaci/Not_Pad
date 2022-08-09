using NoteNTier.BLL.Services;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220609_NoteNTier
{
    public partial class frmAdmin : Form
    {
        UserService userService;
        List<User> passiveUsers;
        public frmAdmin()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            passiveUsers = userService.GetPassiveUsers();
            FillListView();
        }

        void FillListView()
        {
            lvUsers.Items.Clear();
            ListViewItem lvi;
            foreach (User item in passiveUsers)
            {
                lvi = new ListViewItem();
                lvi.Text = item.FirstName;
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.IsActive ? "Aktif" : "Pasif");
                lvi.Tag = item.ID;
                lvUsers.Items.Add(lvi);
            }
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            int userID = (int)lvUsers.SelectedItems[0].Tag;
            
            try
            {
                userService.UserActivated(userID);
                FillListView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
