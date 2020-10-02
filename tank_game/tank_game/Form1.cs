using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tank_game
{
    public partial class Form1 : Form
    {
        int moveLeft = 0;
        int enemyMove = 5;
        Random random = new Random();
        int bulletSpeed = 10;
        bool shooting = false;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            enemy1.Top = -500;
            enemy2.Top = -900;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (fighter.Location.X <0)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = -10;
                }
            }

            else if (e.KeyCode == Keys.Right)
            {
                if(fighter.Location.X>510)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = 10;
                }
            }

            else if(e.KeyCode==Keys.Space)
            {
                if (shooting == false)
                {
                    bulletSpeed = 10;
                    bullet.Left = fighter.Left + 50;
                    bullet.Top = fighter.Top;
                    shooting = true;
                }
            }

        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = 0;
            }
            else if (e.KeyCode == Keys.Right)
            {
                moveLeft = 0;
            }
        }

        private void playtimer_Tick(object sender, EventArgs e)
        {
            fighter.Left += moveLeft;
            bullet.Top -= bulletSpeed;
            enemy1.Top += enemyMove;
            enemy2.Top += enemyMove;
            enemy3.Top += enemyMove;
            scoretext.Text = "" + score;

            if (enemy1.Top == 660 || enemy2.Top == 660 || enemy3.Top == 660)
            {
                GameOver();
            }
            if (shooting && bullet.Top < 0)
            {
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
            EnemyHit();
        }

        private void EnemyHit()
        {
            if (bullet.Bounds.IntersectsWith(enemy1.Bounds))
            {
                score += 1;
                enemy1.Top = -500;
                int ranP = random.Next(1, 300);
                enemy1.Left = ranP;
                if (enemy1.Left < 0)
                { enemy1.Left += 100; }
                else if (enemy1.Left > 510)
                { enemy1.Left -= 100; }
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;

            }
            else if (bullet.Bounds.IntersectsWith(enemy2.Bounds))
            {
                score += 1;
                enemy2.Top = -900;
                int ranP = random.Next(1, 400);
                enemy2.Left = ranP;
                if (enemy2.Left < 0)
                { enemy2.Left += 100; }
                else if (enemy2.Left > 510)
                { enemy2.Left -= 100; }
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;

            }
            else if (bullet.Bounds.IntersectsWith(enemy3.Bounds))
            {
                score += 1;
                enemy3.Top = -1300;
                int ranP = random.Next(1, 500);
                enemy3.Left = ranP;
                if (enemy3.Left < 0)
                { enemy3.Left += 100; }
                else if (enemy3.Left > 510)
                { enemy3.Left -= 100; }
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
        }

        private void GameOver()
        {
            playtimer.Enabled = false;
            MessageBox.Show("糟了!你被擊敗了!\n你這次擊墜了 " + score + "架敵機\n按空白鍵或確認來再玩一次","遊戲結算");
            score = 0;
            scoretext.Text = "0";
            enemy1.Top = -500;
            enemy2.Top = -900;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;
            playtimer.Enabled = true;
        }
    }
}
