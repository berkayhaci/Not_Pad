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
    public partial class frmMain : Form
    {
        NoteService noteService;
        User user;
        public frmMain(User _user)
        {
            InitializeComponent();
            user = _user;
            noteService = new NoteService();
        }

        void FillNotes()
        {
            try
            {
                List<Note> notes = noteService.GetById(user.ID);
                lstNotes.DataSource = notes;
                lstNotes.DisplayMember = "Title";
                lstNotes.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void TextHide()
        {
            txtContent.Hide();
            txtTitle.Hide();
        }

        void TextClear()
        {
            txtContent.Clear();
            txtTitle.Clear();
        }

        void TextShow()
        {
            txtContent.Show();
            txtTitle.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            TextHide();
            FillNotes();
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            lstNotes.SelectedIndex = -1;
            TextShow();
            TextClear();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            bool check;
            try
            {
                if (lstNotes.SelectedIndex == -1) //seçili not yok ise işlem insert
                {
                    check = noteService.Insert(new Note()
                    {
                        Content = txtContent.Text,
                        Title = txtTitle.Text,
                        UserID = user.ID
                    });
                    MessageBox.Show(check ? "Ekleme başarılı" : "EkleneMEdi");
                    TextClear();
                    TextHide();
                }
                else //update
                {
                    int noteID = (int)lstNotes.SelectedValue;
                    check = noteService.Update(new Note()
                    {
                        ID = noteID,
                        Content = txtContent.Text,
                        Title = txtTitle.Text
                    });
                    MessageBox.Show(check ? "Güncelleme başarılı" : "GüncelleneMEdi");
                }
                FillNotes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lstNotes_MouseClick(object sender, MouseEventArgs e)
        {
            TextShow();
            int noteID = (int)lstNotes.SelectedValue;
            try
            {
                Note note = noteService.GetByNoteId(noteID);
                txtContent.Text = note.Content;
                txtTitle.Text = note.Title;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int noteID = (int)lstNotes.SelectedValue;

            try
            {
                bool check = noteService.Delete(noteID);
                MessageBox.Show(check ? "Silme başarılı" : "SilineMEdi");
                TextClear();
                TextHide();
                FillNotes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void linkLblSifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPassword frmPassword = new frmPassword(user);
            frmPassword.ShowDialog();
        }
    }
}
