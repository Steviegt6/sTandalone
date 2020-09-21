using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;

namespace Terraria
{
	partial class Projectile
	{
		public Vector2 originalPosition;
		public static int maxModdedAI = 4;
		public float[] moddedAI = new float[maxModdedAI];

		public void ModdedSetDefaults(int type) {
			switch (type) {
				case ProjectileID.KingSlimeShockwave:
					hostile = true;
					width = 288;
					height = 48;
					ignoreWater = true;
					knockBack = 3f;
					tileCollide = false;
					timeLeft = 15;
					penetrate = -1;
					velocity = new Vector2(0, 0);
					aiStyle = -1;
					alpha = 255;
					break;
				case ProjectileID.CorruptedFlames:
					hostile = true;
					width = 16;
					height = 16;
					tileCollide = false;
					ignoreWater = true;
					penetrate = -1;
					timeLeft = 60 * 8;
					aiStyle = 185;
					break;
				case ProjectileID.SmarterCursedFlames:
					width = 16;
					height = 16;
					aiStyle = 186;
					timeLeft = Utils.SecondsToTicks(20);
					hostile = true;
					light = 0.8f;
					alpha = 100;
					magic = true;
					penetrate = -1;
					scale = 0.9f;
					scale = 1.3f;
					tileCollide = false;
					break;
				case ProjectileID.FriendlyEyeFire:
					localNPCHitCooldown = -2;
					width = 16;
					height = 16;
					aiStyle = 23;
					alpha = 255;
					penetrate = -1;
					extraUpdates = 3;
					magic = true;
					friendly = true;
					break;
				default:
					active = false;
					break;
			}
		}

		public void OnHitNPC(NPC target) {
			switch (type) {
				case ProjectileID.FriendlyEyeFire:
					target.AddBuff(BuffID.CursedInferno, Utils.SecondsToTicks(8), false);
					break;
			}
		}

		public void OnHitPvP(Player target) {
			switch (type) {
				case ProjectileID.FriendlyEyeFire:
					target.AddBuff(BuffID.CursedInferno, Utils.SecondsToTicks(8), false);
					break;
			}
		}

		public void AI_Modded() {
			switch (aiStyle) {
				case 185:
					AI_185_CorruptedFlames();
					break;
				case 186:
					AI_186_SmarterCursedFlames();
					break;
			}
		}

		public void AI_185_CorruptedFlames() {
			if (localAI[0] == 0f) {
				SoundEngine.PlaySound(SoundID.Item20, Center);
				localAI[0] = 1f;
			}

			Dust dust;
			dust = Main.dust[Dust.NewDust(base.position, width, height, 27, 0f, 0f, 0, Color.White, 2f)];
			dust.noGravity = true;
			Lighting.AddLight(base.Center, new Vector3(0.5f, 0f, 1f)); // Dark purple light
		}

		public void AI_186_SmarterCursedFlames() {
			int cursedDust = Dust.NewDust(new Vector2(base.position.X + base.velocity.X, base.position.Y + base.velocity.Y), base.width, base.height, 75, base.velocity.X, base.velocity.Y, 100, default, 3f * scale);
			Main.dust[cursedDust].noGravity = true;

			if (moddedAI[0] == 1f) {
				Vector2 circleCenter = new Vector2(ai[0], ai[1]);

				if (++moddedAI[1] <= 120) {
					velocity = DirectionTo(circleCenter) * 12f;
				}
				else if (moddedAI[1] > 120 && moddedAI[2] == 0f) {
					velocity = DirectionTo(originalPosition) * 12f;
					moddedAI[2] = 1f;
				}
			}
		}
	}
}
