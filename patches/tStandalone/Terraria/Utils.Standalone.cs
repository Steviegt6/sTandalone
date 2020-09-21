using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria
{
	partial class Utils
	{
		/// <summary>
		/// Converts the specified amount of blocks to pixel measurements.
		/// Useful for distance calculations.
		/// </summary>
		/// <param name="blocks">Block count/</param>
		/// <returns>Block count in pixels.</returns>
		public static int BlocksToPixels(int blocks) => blocks * 16;

		/// <summary>
		/// Equal chance to return true or false.
		/// </summary>
		/// <param name="rand"></param>
		/// <returns>Equal chance for true or false</returns>
		public static bool NextBool(this UnifiedRandom rand) => rand.NextDouble() < 0.5;

		/// <summary>
		/// 1 over <c>consequent</c> chance of returning true.
		/// </summary>
		/// <param name="rand"></param>
		/// <param name="consequent">The consequent.</param>
		/// <returns>1 over <c>consequent</c> chance of returning true, otherwise returns false.</returns>
		public static bool NextBool(this UnifiedRandom rand, int consequent) => consequent < 1 ? throw new ArgumentOutOfRangeException("consequent", "consequent must be greater than or equal to 1.") : rand.Next(consequent) == 0;

		/// <summary>
		/// <c>antecedent</c> over <c>consequent</c> chance of returning true.
		/// </summary>
		/// <param name="rand"></param>
		/// <param name="antecedent">The antecedent.</param>
		/// <param name="consequent">The consequent.</param>
		/// <returns><c>antecedent</c> over <c>consequent</c> chance of returning true, otherwise returns false.</returns>
		public static bool NextBool(this UnifiedRandom rand, int antecedent, int consequent) => antecedent > consequent ? throw new ArgumentOutOfRangeException("antecedent", "antecedent must be less than or equal to consequent.") : rand.Next(consequent) < antecedent;

		/// <summary>
		/// Converts seconds to ticks.
		/// </summary>
		/// <param name="seconds"></param>
		/// <returns>The amount of seconds in ticks.</returns>
		public static int SecondsToTicks(float seconds) => (int)Math.Round(seconds * 60);

		/// <summary>
		/// Converts minutes to ticks.
		/// </summary>
		/// <param name="minutes"></param>
		/// <returns>The amount of minutes in ticks.</returns>
		public static int MinutesToTicks(float minutes) => (int)Math.Round(minutes * 60 * 60);

		/// <summary>
		/// Kill all active projectiles of the given type.
		/// </summary>
		/// <param name="projectileType">The type of projectile you wish to kill.</param>
		public static void KillAllProjectileType(int projectileType) {
			if (projectileType > 0 && projectileType < ProjectileID.Count) {
				for (int projIndex = 0; projIndex < Main.maxProjectiles; projIndex++) {
					if (Main.projectile[projIndex].type == projectileType) {
						Main.projectile[projIndex].Kill();
					}
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
			int num = Clamp(value, 0, Main.maxTilesX - 1);
			value2 = Clamp(value2, 0, Main.maxTilesX - 1);
			value3 = Clamp(value3, 0, Main.maxTilesY - 1);
			value4 = Clamp(value4, 0, Main.maxTilesY - 1);
			Vector2 vector = default;

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

						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num2) {
							return true;
						}
					}
				}
			}

			return false;
		}
	}
}
