using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre Fahrrad.
	/// </summary>
	class Fahrrad : Landfahrzeug
	{
		public static readonly int absolute_maxSpeed = 130;
		public static readonly int absolute_minSpeed = 5;
		public Fahrrad(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        override public int MaxSpeed
		{
			get => base.MaxSpeed;
			set
			{
				if (value < absolute_maxSpeed && value > absolute_minSpeed)
				{
					base.MaxSpeed = value;
				}
			}
		}
		override public int CurSpeed
		{
			get => base.CurSpeed;
			set
			{
				if (value <= base.MaxSpeed && value >= 0)
				{
					base.CurSpeed = value;
				}
			}

		}
	}
}
