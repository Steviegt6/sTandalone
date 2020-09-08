using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Microsoft.Xna.Framework;

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


		/// <summary>
		/// Modified SolidCollision from the Collision class to include platform collision
		/// </summary>
		/// <returns></returns>
		public static bool SolidCollisionExtension(Vector2 Position, int Width, int Height, bool includePlatforms = false) {
			int value = (int)(Position.X / 16f) - 1;
			int value2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int value3 = (int)(Position.Y / 16f) - 1;
			int value4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num = Utils.Clamp(value, 0, Main.maxTilesX - 1);
			value2 = Utils.Clamp(value2, 0, Main.maxTilesX - 1);
			value3 = Utils.Clamp(value3, 0, Main.maxTilesY - 1);
			value4 = Utils.Clamp(value4, 0, Main.maxTilesY - 1);
			Vector2 vector = default(Vector2);
			for (int i = num; i < value2; i++) {
				for (int j = value3; j < value4; j++) {
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[Main.tile[i, j].type] && (!Main.tileSolidTop[Main.tile[i, j].type] || includePlatforms)) {
						vector.X = i * 16;
						vector.Y = j * 16;
						int num2 = 16;
						if (Main.tile[i, j].halfBrick()) {
							vector.Y += 8f;
							num2 -= 8;
						}

						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num2)
							return true;
					}
				}
			}

			return false;
		}
	}
}
