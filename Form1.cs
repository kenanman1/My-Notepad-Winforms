namespace My_Notepad
{
    public partial class Form1 : Form
    {
        string fileText = "";
        string loc = null;
        int zoom = 100;
        Font defaultFont = null;
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Line 1, Col 1";
            toolStripStatusLabel2.Text = "100%";
            defaultFont = textBox1.Font;
            Text = "Без названия";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = default;
            if (Text == "Без названия" && textBox1.Text == "")
                return;
            if (fileText != textBox1.Text)
                dialogResult = MessageBox.Show($"Вы хотите сохранить изменения в файле?", "Блокнот", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text(*.txt) | *.txt";
                save.DefaultExt = "txt";
                save.AddExtension = true;
                save.OverwritePrompt = true;
                save.CreatePrompt = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, textBox1.Text);
                }
            }
            else if (dialogResult == DialogResult.No || fileText == textBox1.Text)
            {
                fileText = "";
                textBox1.Text = "";
                Text = "Без названия";
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                wordWrapToolStripMenuItem.CheckState = CheckState.Checked;
                textBox1.WordWrap = true;
            }
            else
            {
                wordWrapToolStripMenuItem.CheckState = CheckState.Unchecked;
                textBox1.WordWrap = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            if (fileText != textBox1.Text)
                dialogResult = MessageBox.Show($"Вы хотите сохранить изменения в файле?", "Блокнот", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text(*.txt) | *.txt";
                save.DefaultExt = "txt";
                save.AddExtension = true;
                save.OverwritePrompt = true;
                save.CreatePrompt = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, textBox1.Text);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    fileText = File.ReadAllText(open.FileName);
                    textBox1.Text = fileText;
                    string name = open.FileName.Substring(open.FileName.LastIndexOf("\\") + 1);
                    Text = name;
                    loc = open.FileName;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(loc, textBox1.Text);
                MessageBox.Show("Сохранено", "Блокнот", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
            PrintDialog print = new PrintDialog();
            print.Document = docToPrint;

            DialogResult result = print.ShowDialog();

            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
                if (textBox1.Font.Size > 12)
                {
                    zoom = 100;
                    int sum = Convert.ToInt32(textBox1.Font.Size);
                    sum = sum - 12;
                    for (int i = sum; i > 0; i = i - 2)
                    {
                        zoom += 20;
                    }
                }
                else if (textBox1.Font.Size < 12)
                {
                    zoom = 100;
                    int sum = Convert.ToInt32(textBox1.Font.Size);
                    sum = 12 - sum;
                    for (int i = sum; i > 0; i = i - 2)
                    {
                        zoom -= 20;
                    }
                }
                else if (textBox1.Font.Size == 12)
                    zoom = 100;
                toolStripStatusLabel2.Text = $"{zoom}%";
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = default;
            if (Text == "Без названия" && textBox1.Text == "")
                return;
            if (fileText != textBox1.Text)
                dialogResult = MessageBox.Show($"Вы хотите сохранить изменения в файле?", "Блокнот", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text(*.txt) | *.txt";
                save.DefaultExt = "txt";
                save.AddExtension = true;
                save.OverwritePrompt = true;
                save.CreatePrompt = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, textBox1.Text);
                }
                else
                    e.Cancel = true;
            }
            else if (dialogResult == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text(*.txt) | *.txt";
            save.DefaultExt = "txt";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, textBox1.Text);
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void hotkeyHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            form.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form3();
            form.ShowDialog();
        }


        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = defaultFont;
            zoom = 100;
            toolStripStatusLabel2.Text = $"{zoom}%";
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                float size = textBox1.Font.Size;
                if (size < 72)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, size + 2, textBox1.Font.Style);
                    zoom += 20;
                    toolStripStatusLabel2.Text = $"{zoom}%";
                }
            }
            catch { }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (zoom > 0)
                {
                    float size = textBox1.Font.Size;
                    textBox1.Font = new Font(textBox1.Font.FontFamily, size - 2, textBox1.Font.Style);
                    zoom -= 20;
                    toolStripStatusLabel2.Text = $"{zoom}%";
                }

            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lineNumber = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int position = textBox1.GetFirstCharIndexFromLine(lineNumber);
            int lineEnd = textBox1.Text.IndexOf(Environment.NewLine, position);
            if (lineEnd < 0)
            {
                lineEnd = textBox1.Text.Length;
            }
            textBox1.Select(position, lineEnd - position);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            int position = textBox1.SelectionStart;
            int row = textBox1.GetLineFromCharIndex(position);

            int firstCharIndex = textBox1.GetFirstCharIndexFromLine(row);
            int column = position - firstCharIndex;
            row = row + 1;
            column = column + 1;
            toolStripStatusLabel1.Text = "Line " + row.ToString() + ", " + "Col " + column.ToString();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Back
                || e.KeyData == Keys.Right || e.KeyData == Keys.Left || e.KeyData == Keys.Enter || e.KeyData == Keys.Space)
            {
                int position = textBox1.SelectionStart;
                int row = textBox1.GetLineFromCharIndex(position);

                int firstCharIndex = textBox1.GetFirstCharIndexFromLine(row);
                int column = position - firstCharIndex;
                row = row + 1;
                column = column + 1;
                toolStripStatusLabel1.Text = "Line " + row.ToString() + ", " + "Col " + column.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int position = textBox1.SelectionStart;
            int row = textBox1.GetLineFromCharIndex(position);

            int firstCharIndex = textBox1.GetFirstCharIndexFromLine(row);
            int column = position - firstCharIndex;
            row = row + 1;
            column = column + 1;
            toolStripStatusLabel1.Text = "Line " + row.ToString() + ", " + "Col " + column.ToString();
        }
    }
}