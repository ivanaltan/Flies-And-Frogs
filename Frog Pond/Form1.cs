﻿using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Windows.Input;

namespace Frogs
{
    public partial class Form1 : Form
    {
        public int players;

        public Timer gametimer;
        public Timer frametimer;
        public Timer flyspawntimer;
        public Timer secondtimer;

        public int seconds;
        public int time;

        public Player1 player1;
        public Player2 player2;
        public Player3 player3;

        Image logoimage;
        Image background;
        Image backgroundidle;
        Bitmap image;
        Bitmap imageidle;

        bool playing;
        bool pause;

        public string file;
        public GameFile info;
        public FliesCollection flies;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;

            logoimage = Properties.Resources.logo;
            background = Properties.Resources.background;
            backgroundidle = Properties.Resources.background_idle;
            image = new Bitmap(background);
            imageidle = new Bitmap(backgroundidle);

            DoubleBuffered = true;
            KeyPreview = true;
            info = new GameFile();

            logo.BackColor = Color.Transparent;
            logo.Image = logoimage;

            playing = false;
            pause = false;
            btnPause.Enabled = false;

            ActiveControl = groupBox1;
        }


        void StartGame(int t) {

            btnPause.Enabled = true;
            playing = true;
            time = t;

            seconds = 2;

            flies = new FliesCollection();

            player1 = new Player1(flies);

            if(players>1)
            player2 = new Player2(flies);
            if (players == 3)
                player3 = new Player3(flies);

            secondtimer = new Timer();
            secondtimer.Interval = 1000;

            gametimer = new Timer();
            gametimer.Interval = time*1000;

            frametimer = new Timer();
            frametimer.Interval = 16;

            flyspawntimer = new Timer();
            if (players==1)
                flyspawntimer.Interval = Adjustments.FlySpawnIntervalSingle;
            else flyspawntimer.Interval = Adjustments.FlySpawnIntervalMulti;

            gametimer.Tick += new EventHandler(gametimer_Tick);
            frametimer.Tick += new EventHandler(frametimer_Tick);
            flyspawntimer.Tick += new EventHandler(flyspawn_Tick);
            secondtimer.Tick += new EventHandler(secondtimer_Tick);

            gametimer.Enabled = true;
            frametimer.Enabled = true;
            flyspawntimer.Enabled = true;
            secondtimer.Enabled = true;

            flies.AddFly();

            ActiveControl = groupBox1;
        }

        private void secondtimer_Tick(object sender, System.EventArgs e)
        {
            lblTime.Text = (time - seconds).ToString();
            seconds++;
        }

        private void gametimer_Tick(object sender, System.EventArgs e)
        {
            Form form;
            int position;

            Pause();

            if (players == 1)
            {
                position = info.highscores.Check(player1.points);

                if (position > 10)
                {
                    form = new NotHighScore(player1.points);
                    form.ShowDialog();
                }

                else
                {
                    NewHighScore formnhs = new NewHighScore(player1.points, position);
                    DialogResult result = formnhs.ShowDialog();
                    if (result == DialogResult.OK)
                        info.highscores.Add(player1.points, formnhs.name, position);
                    else
                        info.highscores.Add(player1.points, "Unnamed", position);
                }

                form = new HighScoresList(info.highscores);
            }

            else if (players == 2)
            {
                if (player1.points > player2.points)
                    form = new Winner(1, player1.img1);
                else if (player1.points < player2.points)
                    form = new Winner(2, player2.img1);
                else
                    form = new Winner(0, logoimage);
            }

            else
            {
                if(player1.points>player2.points && player1.points>player3.points)
                    form = new Winner(1, player1.img1);
                else if(player2.points>player1.points && player2.points>player3.points)
                    form = new Winner(2, player2.img1);
                else if (player3.points > player1.points && player3.points > player2.points)
                    form = new Winner(3, player3.img1);
                else
                    form = new Winner(0, logoimage);

            }

            form.ShowDialog();

            Pause();
            EndGame();

        }

        private void frametimer_Tick(object sender, System.EventArgs e)
        {
            CheckInputs();
            player1.UpdateJump();
            player1.UpdateTongue();
            player1.CheckCollisions();
            lblP1.Text = player1.points.ToString();

            if (players>1)
            {
                player2.UpdateJump();
                player2.UpdateTongue();
                player2.CheckCollisions();
                lblP2.Text = player2.points.ToString();
            }

            if(players==3)
            {
                player3.UpdateJump();
                player3.UpdateTongue();
                player3.CheckCollisions();
                lblP3.Text = player3.points.ToString();
            }

            flies.RemoveEaten();
            flies.Move();

            Invalidate(true);
        }

        private void flyspawn_Tick(object sender, EventArgs e)
        {
            if (flies.flies.Count >= Adjustments.FlyNumberLimit)
                return;
            flies.AddFly();
            flyspawntimer.Interval -= (int)(flyspawntimer.Interval * Adjustments.FlySpawnIntervalDecrease);
        }

        private void SaveGameFile()
        {
            if (file == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Frogs game file (*.fgf)|*.fgf";
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
            dialog.Filter = "Frogs game file (*.fgf)|*.fgf";
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
            form.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            
            if (playing)
            {
                e.Graphics.DrawImage(image, new Point(0, 0));

                player1.Draw(e.Graphics);
                if (players > 1) player2.Draw(e.Graphics);
                if (players == 3) player3.Draw(e.Graphics);

                flies.Draw(e.Graphics);
            }

            else
                e.Graphics.DrawImage(imageidle, new Point(0, 0));

        }

        private void CheckInputs()
        {
            if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P1right)))
                player1.Move(true);
            else if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P1left)))
                player1.Move(false);
            if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P1jump)))
                player1.Jump();
            if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P1tongue)))
                player1.Tongue();

            if (players>1)
            {
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P2right)))
                    player2.Move(true);
                else if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P2left)))
                    player2.Move(false);
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P2jump)))
                    player2.Jump();
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P2tongue)))
                    player2.Tongue();
            }

            if (players == 3)
            {
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P3right)))
                    player3.Move(true);
                else if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P3left)))
                    player3.Move(false);
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P3jump)))
                    player3.Jump();
                if (Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)info.controls.P3tongue)))
                    player3.Tongue();
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Pause();
        }


        private void Pause() {

            if (!playing) return;

            if (!pause)
            {

                frametimer.Stop();
                gametimer.Stop();
                flyspawntimer.Stop();
                secondtimer.Stop();
                pause = true;
                btnPause.Text = "Unpause";
                btnNew.Enabled = false;

            }

            else
            {
                frametimer.Start();
                gametimer.Start();
                flyspawntimer.Start();
                secondtimer.Start();
                pause = false;
                btnPause.Text = "Pause";
                btnNew.Enabled = true;
            }

        }

        private void NewGame()
        {
            if (pause) return;

            NewGame form = new NewGame();
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (playing)
                    EndGame();
                
                players = form.players;
                StartGame(form.time);
            }

            else return;
        }

        private void EndGame()
        {
            frametimer.Dispose();
            flyspawntimer.Dispose();
            secondtimer.Dispose();
            btnPause.Enabled = false;
            playing = false;
            gametimer.Dispose();
            Invalidate(true);
            flies = null;
            lblTime.Text = "0";
            lblP1.Text = "0";
            lblP2.Text = "0";
            lblP3.Text = "0";
        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == info.controls.pause)
                Pause();
            if (e.KeyCode == info.controls.newgame)
                NewGame();
        }

        private void Form1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!playing)
            {
                if (e.X > 358 && e.X < 726 && e.Y > 220 && e.Y < 448)
                    NewGame();
            }
        }
    }
}
