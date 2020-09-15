using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre ?
	/// </summary>
	abstract class Fahrzeug
	{
		private int maxSpeed;
		private int curSpeed;
        private Image sprite;

        public virtual int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
		public virtual int CurSpeed { get => curSpeed; set => curSpeed = value; }
        public Image Sprite { get => sprite; set => sprite = value; }
    }
}
