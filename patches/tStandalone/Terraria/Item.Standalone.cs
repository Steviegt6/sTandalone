using Terraria.Enums;
using Terraria.ID;

namespace Terraria
{
	partial class Item
	{
		public bool master;

		public bool isModdedRanged(int itemType) {
			switch (itemType) {
				case ItemID.TwinsGun:
					return true;

				default:
					return false;
			}
		}

		public void ModdedSetDefaults(int type) {
			switch (type) {
				case ItemID.MutantDevHeadItem:
					width = 20;
					height = 10;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					headSlot = ArmorIDs.Head.MutantDevHat;
					value = sellPrice(gold: 1);
					break;
				case ItemID.MutantDevBodyItem:
					width = 30;
					height = 22;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					bodySlot = ArmorIDs.Body.MutantDevBody;
					value = sellPrice(gold: 1);
					break;
				case ItemID.MutantDevLegsItem:
					width = 22;
					height = 18;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					legSlot = ArmorIDs.Legs.MutantDevLegs;
					value = sellPrice(gold: 1);
					break;
				case ItemID.StevieDevHeadItem:
					width = 22;
					height = 18;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					headSlot = ArmorIDs.Head.StevieDevHat;
					value = sellPrice(gold: 1);
					break;
				case ItemID.StevieDevBodyItem:
					width = 30;
					height = 20;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					bodySlot = ArmorIDs.Body.StevieDevBody;
					value = sellPrice(gold: 1);
					break;
				case ItemID.StevieDevLegsItem:
					width = 22;
					height = 14;
					vanity = true;
					rare = (int)ItemRarityColor.Cyan9;
					legSlot = ArmorIDs.Legs.StevieDevLegs;
					value = sellPrice(gold: 1);
					break;
				case ItemID.TwinsGun:
					width = 72;
					height = 28;
					useStyle = ItemUseStyleID.Shoot;
					glowMask = GlowMaskID.TwinsGunMask;
					shoot = ProjectileID.PurpleLaser;
					ranged = true;
					autoReuse = true;
					shootSpeed = 7f;
					useAnimation = 16;
					useTime = 16;
					master = true;
					value = sellPrice(gold: 3);
					damage = 40;
					knockBack = 1.5f;
					UseSound = SoundID.Item12;
					break;
			}
		}

		public void CloneDefaults(int typeToClone) {
			int originalType = type;
			int originalNetID = netID;

			SetDefaults(typeToClone);

			type = originalType;
			netID = originalNetID;
		}
	}
}
