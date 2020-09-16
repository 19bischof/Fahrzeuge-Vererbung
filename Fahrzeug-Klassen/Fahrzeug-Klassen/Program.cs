using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace Fahrzeug_Klassen
{
    static class Program
    {
        static System.Windows.Forms.Timer timer_move = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer_generate = new System.Windows.Forms.Timer();
        public static List<Fahrzeug> List_obj = new List<Fahrzeug>();
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var myform = new Form1();






            //Auto:
            //var myAuto = new Auto(120);
            //myAuto.Sprite.Image =  Image.FromFile("../../images/PKW/orange.png");
            //myAuto.Sprite.Height = 60;
            //myAuto.Sprite.Width = 100;
            //myAuto.Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            //myAuto.Sprite.Location = new Point(1000 - 110, 170);
            //myAuto.Sprite.BackColor = Color.Transparent;
            //myAuto.CurSpeed = 80;
            //////////////////////
            //var myAuto1 = new Auto(100);
            //myAuto1.Sprite.Image = Image.FromFile("../../images/PKW/Blue_small.png");
            //myAuto1.Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            //myAuto1.Sprite.Location = new Point(0, 320);
            //myAuto1.Sprite.BackColor = Color.Transparent;
            //myAuto1.Sprite.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //myAuto1.Direction = "right";
            //myAuto1.CurSpeed = 50;

            //Program.List_obj.Add(myAuto);
            //Program.List_obj.Add(myAuto1);

            //myform.Controls.Add(myAuto.Sprite);
            //myform.Controls.Add(myAuto1.Sprite);

            timer_move.Interval = 16;
            timer_move.Tick += myform.timer1_Tick;
            timer_move.Start();

            timer_generate.Interval = 1000;
            timer_generate.Tick += myform.AddAndRemove;
            timer_generate.Start();






            
            Application.Run(myform);


        }
    }
}
