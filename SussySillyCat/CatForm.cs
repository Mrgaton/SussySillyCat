using SussySillyCat.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SussySillyCat
{
    public partial class CatForm: Form
    {
        public CatForm()
        {
            InitializeComponent();

            this.catPictureBox.Image = Resources.sillyCat;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\EhStorAuthn.exe"));
        }
    }
}
