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
    public partial class frmPassword : Form
    {
        PasswordService passwordService;
        User user;
        public frmPassword(User _user)
        {
            InitializeComponent();
            user = _user;
            passwordService = new PasswordService();
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                Password activePassword = passwordService.GetActivePassword(user.ID);
                if (txtEskiSifre.Text != activePassword.Text)
                {
                    MessageBox.Show("Mevcut şifrenizi hatalı girdiniz");
                    return;
                }

                if (txtyeniSifre.Text != txtYeniSifreTekrar.Text)
                {
                    MessageBox.Show("Şifre tekrarı hatalı");
                    return;
                }

                bool check = passwordService.Insert(new Password()
                {
                    Text = txtyeniSifre.Text,
                    UserID = user.ID
                });
                MessageBox.Show(check ? "Şifre değiştirildi" : "Şifre değiştirileMEdi");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
