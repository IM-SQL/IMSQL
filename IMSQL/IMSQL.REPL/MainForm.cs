using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSQL.REPL
{
    public partial class MainForm : Form
    {
        private int lastIndex;
        private SQLInterpreter interpreter = new SQLInterpreter();
        private List<string> ExecutedCode = new List<string>();
        int cursor = 0;
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
            ExecutedCode.Add(inputText);
            cursor = ExecutedCode.Count - 1;

            var result = interpreter.Execute(inputText);
            return string.Join("\n", result.Select(e => e.ToString()));

        }

        private void cmdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmdTextBox.SelectionStart < lastIndex)
            {
                cmdTextBox.SelectionStart = lastIndex;
            }

            if (e.Control)
            {
                if (e.KeyCode == Keys.Enter)
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
                if (e.KeyCode == Keys.Up)
                {
                    string current = ExecutedCode[cursor--];
                    if (cursor < 0) cursor = 0;
                    cmdTextBox.Text = cmdTextBox.Text.Remove(lastIndex, cmdTextBox.Text.Length - lastIndex);
                    AppendText(current);
                }
                if (e.KeyCode == Keys.Down)
                {
                    string current = ExecutedCode[cursor++];
                    if (cursor >= ExecutedCode.Count) cursor = ExecutedCode.Count - 1;
                    cmdTextBox.Text = cmdTextBox.Text.Remove(lastIndex, cmdTextBox.Text.Length - lastIndex);
                    AppendText(current);
                }
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
