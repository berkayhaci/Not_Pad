using NoteNTier.BLL.Services;
using NoteNTier.Model.Entities;
using NoteNTier.Model.Enums;
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
    public partial class frmLogIn : Form
    {
        UserService userService;
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string userName = txtKullaniciAdi.Text;
            string password = txtSifre.Text;

            try
            {
                userService = new UserService();
                User user = userService.CheckLogIn(userName, password);
                if (user != null)
                {
                    if (!user.IsActive)
                    {
                        MessageBox.Show("Admin bu kullanıcıyı onaylamamış");
                        return;
                    }

                    switch (user.UserType)
                    {
                        case UserType.Admin:
                            frmAdmin frmAdmin = new frmAdmin();
                            this.Hide();
                            frmAdmin.ShowDialog();
                            this.Show();
                            break;
                        case UserType.Standard:
                            frmMain frmMain = new frmMain(user);
                            this.Hide();
                            frmMain.ShowDialog();
                            this.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen doğru bilgileri giriniz. Eğer üye değilseniz kayıt olunuz");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void linkLblKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            this.Hide();
            frmRegister.ShowDialog();
            this.Show();
        }
    }
}
