using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre ?
	/// </summary>
	abstract class Fahrzeug
	{
		private int maxSpeed;
		private int curSpeed;
        private PictureBox sprite;
		private String direction;

        public virtual int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
		public virtual int CurSpeed { get => curSpeed; set => curSpeed = value; }
        public virtual PictureBox Sprite { get => sprite; set => sprite = value; }
        public string Direction
		{
			get => direction;
			set
			{
				if (String.Equals(value.ToLower(), "left") || String.Equals(value.ToLower(), "right"))
					direction = value;
			}
		}

        public Fahrzeug()
        {
			Sprite = new PictureBox();
			Direction = "left";
			
        }
    }
}
