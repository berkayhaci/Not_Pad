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
    public partial class frmRegister : Form
    {
        UserService userService;
        public frmRegister()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    MessageBox.Show("Şifre tekrarı hatalı");
                    return;
                }

                User user = new User()
                {
                    FirstName = txtAd.Text,
                    LastName = txtSoyad.Text,
                    UserName = txtKAdi.Text
                };
                user.Passwords.Add(new Password()
                {
                    Text = txtSifre.Text
                });

                bool check = userService.Insert(user);
                MessageBox.Show(check ? "Kullanıcı eklendi" : "Kullanıcı ekleneMEdi");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
