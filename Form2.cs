using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Notepad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label2.Text = "New file - Ctrl + T\nOpen File - Ctrl + O\nSave file - Ctrl + S\nSave as file - Ctrl + SHIFT + D" +
                "\nPrint file - Ctrl + P\nZoom in - Ctrl + Up\nZoom Out - Ctrl + Down\nRestore Default Zoom - Ctrl + O";
        }
    }
}
