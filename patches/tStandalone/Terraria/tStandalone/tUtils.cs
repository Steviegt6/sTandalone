using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.tStandalone
{
	public class tUtils
	{
		/// <summary>
		/// Converts an amount of blocks to pixel measurements.
		/// Useful for distance calculations.
		/// </summary>
		/// <param name="blocks">Block count.</param>
		/// <returns></returns>
		public static int BlocksToPixels(int blocks) {
			return (blocks * 16);
		}
	}
}
