﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeug_Klassen
{
	/// <summary>
	/// Ich fahre Zeppelin
	/// </summary>
	class Zeppelin:Luftfahrzeug
	{
		override public int MaxSpeed
		{
			get => maxSpeed;
			set
			{
				if (value < 130 && value > 0)
				{
					maxSpeed = value;
				}
			}
		}
		override public int CurSpeed
		{
			get => curSpeed;
			set
			{
				if (value <= maxSpeed && value >= 0)
				{
					curSpeed = value;
				}
			}

		}
	}
}
