using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeug_Klassen
{
	public partial class Form1 : Form
	{
        static String[] Auto_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Fahrrad_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Skateboard_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Airliner_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] FighterJet_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Zeppelin_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Segelboot_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] U_Boot_pics = System.IO.Directory.GetFiles("../../images/PKW/");
        static String[] Schlauchboot_pics = System.IO.Directory.GetFiles("../../images/PKW/");

        public static List<bool> dispose ;

        private int frame_count = 0;
        DateTime start = System.DateTime.Now;
        private Random _random;
        private PictureBox checkpoint0;
        private PictureBox checkpoint1;
		public Form1()
		{
			InitializeComponent();
            dispose = new List<bool>(new bool[Program.List_obj.Count]);

            this.Width = 1000;
            this.Height = 600;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "Eine Straße";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            Image myimage = Image.FromFile("../../images/STRASSE/road image simple top view.png");
            this.BackgroundImage = myimage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            _random = new Random();
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.DoubleBuffered = true;
            checkpoint0 = new PictureBox();
            checkpoint0.Width = 10;
            checkpoint0.Height = 20;
            checkpoint0.Location = new Point(100, 190);
            checkpoint0.Image = Image.FromFile("../../images/CHECKPOINT/black.png");
            this.Controls.Add(checkpoint0);

            checkpoint1 = new PictureBox();
            checkpoint1.Width = 10;
            checkpoint1.Height = 20;
            checkpoint1.Location = new Point(100, 340);
            checkpoint1.Image = Image.FromFile("../../images/CHECKPOINT/red.png");
            this.Controls.Add(checkpoint1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dispose = new List<bool>(new bool[Program.List_obj.Count]);

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            frame_count++;
            if (( DateTime.Now - start).Seconds > 1) {
                Console.WriteLine("FPS: " + frame_count);
                start = DateTime.Now;
                frame_count = 0;
            }
            this.SuspendLayout();
            
            int index = 0;
            

            foreach (Fahrzeug the_car in Program.List_obj) {
                if (the_car.CurSpeed > 0 && String.Equals(the_car.Direction.ToLower(), "left"))
                {
                    the_car.CurSpeed *= -1;
                    //Console.WriteLine("direction adjusted");

                }
                the_car.Sprite.Location = new Point(the_car.Sprite.Location.X + (the_car.CurSpeed / 3)/*so as to improve visuals*/, the_car.Sprite.Location.Y);
                if (the_car.Direction.Equals("left"))
                {
                    if (the_car.Sprite.Bounds.IntersectsWith(checkpoint0.Bounds) && !the_car.Hit_checkpoint0) { Console.WriteLine("\t\t\t\t\thit while left");the_car.Hit_checkpoint0= true; }
                }
                else
                {
                    if (the_car.Sprite.Bounds.IntersectsWith(checkpoint1.Bounds) && !the_car.Hit_checkpoint0) { Console.WriteLine("\t\t\t\t\thit while right"); the_car.Hit_checkpoint0 = true; }
                }
                if (Out_Of_Bounds(the_car) && !dispose[index])
                {
                    
                    dispose[index] = true;

                    Console.WriteLine("should be disposed");

                }
                index++;
            }

            this.ResumeLayout();
            //this.Update();
            //this.Refresh();

        }
        private bool Out_Of_Bounds(Fahrzeug _vessel)
        {
            if(_vessel.Sprite.Location.X < (0 - _vessel.Sprite.Width) || _vessel.Sprite.Location.X > this.Width)
            {
                return true;
            }
            return false;
        }
        public void AddAndRemove(object sender,EventArgs e)
        {
            int count_of_removed = 0;
            for (int i = 0; i < dispose.Count; i++)
            {
                if (dispose[i])
                {
                    var redundant_index = Program.List_obj[i - count_of_removed].Sprite;
                    this.Controls.Remove(redundant_index);
                    Program.List_obj.RemoveAt(i-count_of_removed);
                    Console.WriteLine("-Removed : Count : " + Program.List_obj.Count);
                    count_of_removed++;
                }
            }
            if(Program.List_obj.Count <= 4)
                Program.List_obj.Add(Spawn_vehicle());
            dispose = new List<bool>(new bool[Program.List_obj.Count]);
            Console.WriteLine("+Spawned : Count: " + Program.List_obj.Count);


        }
        private Fahrzeug Spawn_vehicle()
        {
            
            String direction;
            Fahrzeug vehicle;
            int maxSpeed;
            int minSpeed;
            int curSpeed;
            String image_path;
            //int class_picked = _random.Next(0, 9);
            //switch (class_picked){
            //    case 0: minSpeed = Fahrrad.absolute_minSpeed; maxSpeed= _random.Next(Fahrrad.absolute_minSpeed, Fahrrad.absolute_maxSpeed); vehicle = new Fahrrad(maxSpeed); break;
            //    case 1: minSpeed = Auto.absolute_minSpeed; maxSpeed = _random.Next(Auto.absolute_minSpeed, Auto.absolute_maxSpeed); vehicle = new Auto(maxSpeed); break;
            //    case 2: minSpeed = Skateboard.absolute_minSpeed; maxSpeed = _random.Next(Skateboard.absolute_minSpeed, Skateboard.absolute_maxSpeed); vehicle = new Skateboard(maxSpeed) ; break;
            //    case 3: minSpeed = Airliner.absolute_minSpeed; maxSpeed = _random.Next(Airliner.absolute_minSpeed, Airliner.absolute_maxSpeed); vehicle = new Airliner(maxSpeed); break;
            //    case 5: minSpeed = FighterJet.absolute_minSpeed; maxSpeed = _random.Next(FighterJet.absolute_minSpeed, FighterJet.absolute_maxSpeed); vehicle = new FighterJet(maxSpeed); break;
            //    case 7: minSpeed = Zeppelin.absolute_minSpeed; maxSpeed = _random.Next(Zeppelin.absolute_minSpeed, Zeppelin.absolute_maxSpeed); vehicle = new Zeppelin(maxSpeed); break;
            //    case 4: minSpeed = Segelboot.absolute_minSpeed; maxSpeed = _random.Next(Segelboot.absolute_minSpeed, Segelboot.absolute_maxSpeed); vehicle = new Segelboot(maxSpeed); break;
            //    case 6: minSpeed = U_Boot.absolute_minSpeed; maxSpeed = _random.Next(U_Boot.absolute_minSpeed, U_Boot.absolute_maxSpeed); vehicle = new U_Boot(maxSpeed); break;
            //    case 8: minSpeed = Schlauchboot.absolute_minSpeed; maxSpeed = _random.Next(Schlauchboot.absolute_minSpeed, Schlauchboot.absolute_maxSpeed); vehicle = new Schlauchboot(maxSpeed); break;
            //    default: vehicle = new Auto(60); minSpeed = 0;maxSpeed = 0;break;
            //}

            //curSpeed = _random.Next(minSpeed, maxSpeed);

            /*DELETE*/
            minSpeed = Auto.absolute_minSpeed; maxSpeed = _random.Next(Auto.absolute_minSpeed, Auto.absolute_maxSpeed); vehicle = new Auto(maxSpeed);
            curSpeed = _random.Next(minSpeed, maxSpeed);
            /*DELETE*/

            


            //switch (class_picked)
            //{
            //    case 0: image_path = Fahrrad_pics[0];break;
            //    case 1: image_path = Auto_pics[0]; break;
            //    case 2: image_path = Skateboard_pics[0]; break;
            //    case 3: image_path = Airliner_pics[0]; break;
            //    case 4: image_path = FighterJet_pics[0]; break;
            //    case 5: image_path = Zeppelin_pics[0]; break;
            //    case 6: image_path = Segelboot_pics[0]; break;
            //    case 7: image_path = U_Boot_pics[0]; break;
            //    case 8: image_path = Schlauchboot_pics[0]; break;
            //    default: image_path = Fahrrad_pics[0]; break;

            //}

            image_path = Auto_pics[_random.Next(0,7)];
            //Console.WriteLine("image_path : " +image_path);
            vehicle.Sprite.Height = 60;
            vehicle.Sprite.Width = 100;
            vehicle.Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            vehicle.Sprite.Location = new Point(300, 170);
            vehicle.Sprite.BackColor = Color.Transparent;


            vehicle.Sprite.Image = Image.FromFile(image_path);
            //direction = "left"; 
            vehicle.Sprite.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            switch (_random.Next(0, 2))
            {
                case 0: direction = "left"; vehicle.Sprite.Location = new Point(1000, 170); vehicle.Sprite.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                case 1: direction = "right"; vehicle.Sprite.Location = new Point(0 - vehicle.Sprite.Width, 320); break;
                default: direction = "left"; break;
            }

            vehicle.Direction = direction;
            vehicle.CurSpeed = curSpeed;
            Control control_of_sprite = new Control();
            control_of_sprite = vehicle.Sprite;
            //control_of_sprite.double
            this.Controls.Add(control_of_sprite);

            return vehicle;
        }
        //
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                Console.WriteLine("STyle : " + cp.ExStyle);
                return cp;
            }
        }
    }
}
