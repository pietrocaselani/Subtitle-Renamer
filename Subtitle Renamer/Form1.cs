using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subtitle_Renamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            using(var folderBrowser = new FolderBrowserDialog())
            {
                var result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    string[] paths = Directory.GetFiles(folderBrowser.SelectedPath);

                    for (int i = 0; i < paths.Count(); i++)
                    {
                        var absolutePath = paths[i];
                        var fileName = Path.GetFileNameWithoutExtension(absolutePath);

                        var index = fileName.IndexOf('[');
                        if (index != -1)
                        {
                            var path = Path.GetDirectoryName(absolutePath);
                            var extension = Path.GetExtension(absolutePath);

                            var newFileName = fileName.Substring(0, index);

                            var newPath = Path.Combine(path, newFileName);

                            newPath = newPath + extension;

                            File.Move(absolutePath, newPath);
                        }
                    }

                    Console.WriteLine(paths);
                }
            }
        }
    }
}
