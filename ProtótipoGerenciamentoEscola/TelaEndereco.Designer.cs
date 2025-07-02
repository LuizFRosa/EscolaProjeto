namespace ProtótipoGerenciamentoEscola
{
    partial class TelaEndereco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEndereco));
            pictureBox1 = new PictureBox();
            pbFechar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(960, 540);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pbFechar
            // 
            pbFechar.BackColor = Color.Transparent;
            pbFechar.BackgroundImageLayout = ImageLayout.None;
            pbFechar.Location = new Point(912, 0);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(48, 39);
            pbFechar.TabIndex = 3;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // TelaEndereco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            Controls.Add(pbFechar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaEndereco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaEndereco";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pbFechar;
    }
}