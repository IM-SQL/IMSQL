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
        private SQLInterpreter interpreter = new SQLInterpreter();

        public MainForm()
        {
            InitializeComponent();
        }

        public Color TextColor { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            lastIndex = cmdTextBox.TextLength;
            cmdTextBox.SelectionStart = lastIndex;
        }

        public void WithTextColor(Color color, Action action)
        {
            Color old = TextColor;
            try
            {
                TextColor = color;
                action();
            }
            finally
            {
                TextColor = old;
            }
        }

        public void AppendText(string text)
        {
            // INFO(Richo): Code for text coloring taken from: https://stackoverflow.com/a/1926822
            cmdTextBox.SelectionStart = cmdTextBox.TextLength;
            cmdTextBox.SelectionLength = 0;
            cmdTextBox.SelectionColor = TextColor;
            cmdTextBox.AppendText(text);
        }

        private string Eval(string inputText)
        {
            var result = interpreter.Execute(inputText);
            return result.ToString();
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
                string outputText;
                Color color = Color.Blue;
                try
                {
                    outputText = Eval(inputText);
                }
                catch (Exception ex)
                {
                    outputText = ex.ToString();
                    color = Color.Red;
                }
                lastIndex = cmdTextBox.TextLength;
                WithTextColor(color, () => AppendText(outputText));
                AppendText("\r\n\r\n>>> ");
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
                && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
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
