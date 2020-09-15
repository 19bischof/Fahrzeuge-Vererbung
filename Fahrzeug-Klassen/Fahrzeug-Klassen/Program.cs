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
		public static PictureBox[] arr_pics = new PictureBox[2];
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var myform = new Form1();
            myform.Width = 1000;
			myform.Height = 600;

            myform.BackgroundImageLayout = ImageLayout.Stretch;
			myform.Text = "Eine Straße";
			myform.FormBorderStyle = FormBorderStyle.FixedSingle;
			myform.StartPosition = FormStartPosition.CenterScreen;


			Image myimage = Image.FromFile("../../images/STRASSE/road image simple top view.png");


			//Auto:
			var myAuto = new Auto();
			var myAuto1 = new Auto();
			myAuto.Sprite = Image.FromFile("../../images/PKW/orange.png");
			myAuto1.Sprite = Image.FromFile("../../images/PKW/Blue_small.png");


			myform.BackgroundImage = myimage;
			myform.BackgroundImageLayout = ImageLayout.Stretch;
			PictureBox first_pic = new PictureBox();
			first_pic.Image = myAuto.Sprite;
            first_pic.Height = 60;
			first_pic.Width = 100;
            first_pic.SizeMode = PictureBoxSizeMode.StretchImage;
			first_pic.Location = new Point(1000 - 110,170);
			first_pic.BackColor = Color.Transparent;

			PictureBox second_pic = new PictureBox();
			second_pic.Image = myAuto1.Sprite;
			second_pic.SizeMode = PictureBoxSizeMode.StretchImage;
			second_pic.Location = new Point(0, 250);
			second_pic.BackColor = Color.Transparent;
			second_pic.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);



			Program.arr_pics[0] = first_pic;
			myform.Controls.Add(first_pic);
			myform.Controls.Add(second_pic);

			public delegate void Time_is_real();

			//Thread thread = new Thread(new ThreadStart(Time_is_real));
			//thread.Start();
			//System.Windows.Forms.MethodInvoker(Time_is_real);

			//Delegate timmy = new Delegate(Time_is_real);
			System.Windows.Forms.Control.Invoke(Time_is_real);

			Application.Run(myform);
			

			
			
		
			
				}
		public static void Time_is_real()
        {
			PictureBox the_pic; 
			the_pic = Program.arr_pics[0];
			for (int i = 0; i < 1000; i++)
			{
				Console.WriteLine(the_pic.Location);
				the_pic.Location = new Point(the_pic.Location.X + 1, the_pic.Location.Y);
				System.Threading.Thread.Sleep(200);

			}
		}
	}
}
