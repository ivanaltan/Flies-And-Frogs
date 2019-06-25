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
        public bool players;

        public Timer gametimer;
        public Timer frametimer;
        public Timer flyspawntimer;

        bool pause;

        public string file;
        public GameFile info;

        public Form1()
        {
            Image logoimage = Properties.Resources.logo;
            InitializeComponent();
            DoubleBuffered = true;
            info = new GameFile();
            logo.BackColor = Color.Transparent;
            logo.Image = logoimage;
            pause = false;
        }


        void StartGame() {


        }


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGameFile();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGameFile();
        }

        private void btnControls_Click(object sender, EventArgs e)
        {

            ControlsConfiguration form = new ControlsConfiguration(DeepClone(info.controls));
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                info.controls = form.c;

            else
                return;  
        }


        public static T DeepClone<T>(T obj)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            HighScoresList form = new HighScoresList(info.highscores);
            DialogResult result = form.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewGame form = new NewGame();
            DialogResult result = form.ShowDialog();

            if(result==DialogResult.OK)
            {
    //            StartGame(form.players, form.time);
            }
        }
    }
}
