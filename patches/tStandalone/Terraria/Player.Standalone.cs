using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace Terraria
{
	partial class Player
	{
		public bool trulyConfused;

		public void UpdatetStandaloneBuffs(int index) {
			switch (buffType[index]) {
				case BuffID.TrueConfusion:
					trulyConfused = true;
					confused = true;
					break;
			}
		}

		public void PostUpdateBuffs() {
			if (trulyConfused) {
				Filters.Scene.Activate("VerticalMirror");
			}
			else {
				Filters.Scene.Deactivate("VerticalMirror");
			}
		}

		public void ResettStandaloneEffects() {
			trulyConfused = false;
		}

		public bool ModdedShoot(int itemType, Vector2 position, Vector2 velocity, int damage, float knockback, int owner) {
			switch (itemType) {
				case ItemID.TwinsGun:
					Projectile.NewProjectile(position, velocity.RotatedBy(MathHelper.ToRadians(6)), ProjectileID.FriendlyEyeFire, (int)(damage * 1.25f), knockback, owner);
					Projectile.NewProjectile(position, velocity.RotatedBy(MathHelper.ToRadians(-6)), ProjectileID.FriendlyEyeFire, (int)(damage * 1.25f), knockback, owner);
					SoundEngine.PlaySound(SoundID.Item34, position);
					break;
			}

			return true;
		}
	}
}
