using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

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

		/// <summary>
		/// Randomly returns true or false, with an even chance for each.
		/// </summary>
		public static bool NextBool() {
			return Main.rand.Next(2) == 0;
		}

		/// <summary>
		/// Returns the passed amount of seconds in ticks. Rounds up if calculation returns decimal value.
		/// </summary>
		public static int SecondsToTicks(float seconds) => (int)Math.Round(seconds * 60f);

		/// <summary>
		/// Returns the passed amount of seconds in ticks. Rounds up if calculation returns decimal value.
		/// </summary>
		public static int SecondsToTicks(double seconds) => (int)Math.Round(seconds * 60);

		/// <summary>
		/// Returns the passed amount of minutes in ticks. Rounds up if calculation returns decimal value.
		/// </summary>
		public static int MinutesToTicks(float minutes) => (int)Math.Round(minutes * 60f * 60f);

		/// <summary>
		/// Returns the passed amount of minutes in ticks. Rounds up if calculation returns decimal value.
		/// </summary>
		public static int MinutesToTicks(double minutes) => (int)Math.Round(minutes * 60 * 60);

		/// <summary>
		/// Kills all projectiles currently alive of a given type. Invalid projectile type make nothing happen.
		/// </summary>
		/// <param name="projectileType">Type of Projectile.</param>
		public static void KillAllProjectileType(int projectileType) {
			if (projectileType > 0 && projectileType < ProjectileID.Count) {
				for (int projIndex = 0; projIndex < Main.maxProjectiles; projIndex++) {
					if (Main.projectile[projIndex].type == projectileType)
						Main.projectile[projIndex].Kill();
				}
			}
		}
	}
}
