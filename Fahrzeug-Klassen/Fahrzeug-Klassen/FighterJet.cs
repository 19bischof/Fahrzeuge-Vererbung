using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre FighterJet.
	/// </summary>
	class FighterJet:Luftfahrzeug
	{
		public static readonly int absolute_maxSpeed = 3300;
		public static readonly int absolute_minSpeed = 400;

        public FighterJet(int maxSpeed)
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
