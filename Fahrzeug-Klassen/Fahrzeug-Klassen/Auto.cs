using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre Auto.
	/// </summary>
	class Auto:Landfahrzeug

	{
		public static readonly int absolute_maxSpeed = 400;
		public static readonly int absolute_minSpeed = 30;

		public Auto(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        override public int MaxSpeed
		{
			get => base.MaxSpeed;
			set
			{
				if (value <= absolute_maxSpeed && value > absolute_minSpeed)
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
				if (value <= base.MaxSpeed )
				{
					base.CurSpeed = value;
				}
			}

		}
	}
}
