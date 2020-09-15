using System;
using System.Collections.Generic;
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
		protected int maxSpeed;
		protected int curSpeed;

		public virtual int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
		public virtual int CurSpeed { get => curSpeed; set => curSpeed = value; }
	}
}
