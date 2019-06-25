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

        Image logoimage;
        Image background;
        Bitmap bitmap;

        bool pause;

        public string file;
        public GameFile info;

        public Form1()
        {
            logoimage = Properties.Resources.logo;
            background = Properties.Resources.background;
            bitmap = new Bitmap(background);

            InitializeComponent();
            DoubleBuffered = true;
            info = new GameFile();
            logo.BackColor = Color.Transparent;
            logo.Image = logoimage;
            pause = false;
        }


        void StartGame(int time) {

            Player1 player1;
            Player2 player2;

            player1 = new Player1();

            if(players)
            player2 = new Player2();

            gametimer = new Timer();
            gametimer.Interval = time*1000;

            frametimer = new Timer();
            frametimer.Interval = 16;

            flyspawntimer = new Timer();
            if (players)
                flyspawntimer.Interval = 800;
            else flyspawntimer.Interval = 1500;


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

            if (result == DialogResult.OK)
            {
                players = form.players;
                StartGame(form.time);
            }

            else return;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
            
        }
    }
}
