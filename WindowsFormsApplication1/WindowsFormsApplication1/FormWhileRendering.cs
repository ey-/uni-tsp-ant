using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
        public partial class FormWhileRendering : Form
        {
            public FormWhileRendering()
            {
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams lCreateParams = base.CreateParams;
                    lCreateParams.ExStyle |= (0x08000000 | 0x00000080); // WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW
                    return lCreateParams;
                }
            }

            private void Form2_Load(object sender, EventArgs e)
            {
                this.Location = new System.Drawing.Point(Control.MousePosition.X + 20, Control.MousePosition.Y + 20);
            }
        }
    }
