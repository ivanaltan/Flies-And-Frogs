using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            info = new GameFile();
        }

        public int players;

        public Timer gametimer;
        public Timer frametimer;
        public Timer flyspawntimer;

        public string file;
        public GameFile info;

        private void SaveGameFile()
        {
            if (file == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Frogs game file (*.fro)|*.fro";
                dialog.Title = "Save Frogs game file";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file = dialog.FileName;
                }
            }

            else
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, info);
                }
            }
        }
        private void LoadGameFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Frogs game file (*.fro)|*.fro";
            dialog.Title = "Open Frogs game file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file = dialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(file, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        info = (GameFile)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not read file: " + file);
                    file = null;
                    return;
                }
                Invalidate(true);
            }
        }



















    }
}
