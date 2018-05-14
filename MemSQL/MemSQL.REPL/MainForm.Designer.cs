namespace MemSQL.REPL
{
    partial class MainForm
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
            this.cmdTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmdTextBox
            // 
            this.cmdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTextBox.Location = new System.Drawing.Point(0, 0);
            this.cmdTextBox.Name = "cmdTextBox";
            this.cmdTextBox.Size = new System.Drawing.Size(683, 487);
            this.cmdTextBox.TabIndex = 0;
            this.cmdTextBox.Text = "Welcome to MemSQL REPL.\nType here your SQL code. Ctrl+Enter to execute. Ctrl+C to" +
    " cancel.\n\n>>> ";
            this.cmdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmdTextBox_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 487);
            this.Controls.Add(this.cmdTextBox);
            this.Name = "MainForm";
            this.Text = "MemSQL REPL";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cmdTextBox;
    }
}

