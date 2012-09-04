namespace WindowsFormsApplication1
{
using System.Threading;

    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private RenderWindow mRenderWindow;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            mRenderWindow.DestroyContexts();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

     
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mRenderWindow = new WindowsFormsApplication1.RenderWindow();
            this.SuspendLayout();
            // 
            // mRenderWindow
            // 
            this.mRenderWindow.AccumBits = ((byte)(0));
            this.mRenderWindow.AutoCheckErrors = false;
            this.mRenderWindow.AutoFinish = false;
            this.mRenderWindow.AutoMakeCurrent = true;
            this.mRenderWindow.AutoSwapBuffers = true;
            this.mRenderWindow.BackColor = System.Drawing.Color.Black;
            this.mRenderWindow.ColorBits = ((byte)(32));
            this.mRenderWindow.DepthBits = ((byte)(16));
            this.mRenderWindow.Location = new System.Drawing.Point(36, 43);
            this.mRenderWindow.Name = "mRenderWindow";
            this.mRenderWindow.Size = new System.Drawing.Size(306, 281);
            this.mRenderWindow.StencilBits = ((byte)(0));
            this.mRenderWindow.TabIndex = 0;
            this.mRenderWindow.Load += new System.EventHandler(this.mRenderWindow_Load);

            mRenderWindow.initViewPort();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 371);
            this.Controls.Add(this.mRenderWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        
    }
}

