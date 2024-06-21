using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrirFormSecundario(object formSecundario)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form fh = formSecundario as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();
        }

        private void btnChofer_Click(object sender, EventArgs e)
        {
            AbrirFormSecundario(new FormRegistrarChofer());
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            AbrirFormSecundario(new FormRegistrarAutobuses());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormSecundario(new FormRegistrarRutas());
        }

        private void btnViajes_Click(object sender, EventArgs e)
        {
            AbrirFormSecundario(new FormViajes());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormSecundario(new FormInicio());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            pictureBox2_Click(null, e);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
