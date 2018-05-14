using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemSQL.REPL
{
    public partial class MainForm : Form
    {
        private int lastIndex;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            lastIndex = cmdTextBox.TextLength;
            cmdTextBox.SelectionStart = lastIndex;
        }

        private void cmdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmdTextBox.SelectionStart < lastIndex)
            {
                cmdTextBox.SelectionStart = lastIndex;
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                string inputText = cmdTextBox.Text.Substring(lastIndex);
                lastIndex = cmdTextBox.TextLength;
                cmdTextBox.AppendText(inputText);
                cmdTextBox.AppendText("\r\n>>> ");
                lastIndex = cmdTextBox.TextLength;
                cmdTextBox.SelectionStart = lastIndex;
            }
        }
        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmdTextBox.SelectionStart < lastIndex)
            {
                e.SuppressKeyPress = true;
            }
            else if (cmdTextBox.SelectionStart == lastIndex 
                && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            {
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Enter)
            {
                cmdTextBox.SelectionStart = cmdTextBox.TextLength;
            }
        }
    }
}
