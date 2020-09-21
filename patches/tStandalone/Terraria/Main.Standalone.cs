using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria
{
	partial class Main
	{
		public static bool showWelcomeMessage = true;
		public static Ref<Effect> VerticalMirrorRef = new Ref<Effect>();

		public static void tStandaloneConfigPut() {
			Configuration.Put("ShowWelcomeMessage", showWelcomeMessage);
		}

		public static void tStandaloneConfigGet() {
			Configuration.Get("ShowWelcomeMessage", ref showWelcomeMessage);
		}

		public static void ModdedOffsetDefaults(float gravdir, int itemtype, ref Vector2 offset, ref float offsetX) {
			switch (itemtype) {
				case ItemID.TwinsGun:
					offsetX -= 18f;
					break;
			}
		}

		public static void InitializeModdedBuffs() {
			debuff[BuffID.TrueConfusion] = true;
			buffNoTimeDisplay[BuffID.TrueConfusion] = true;
		}

		public void InitializetStandaloneShaders() {
			VerticalMirrorRef.Value = ShaderContentManager.Load<Effect>("VerticalMirror");
		}

		public void AddModdedProjectilesBehindNPCs(int projectileIndex) {
			if (projectile[projectileIndex].type == ProjectileID.SmarterCursedFlames) {
				DrawCacheProjsBehindNPCs.Add(projectileIndex);
			}
		}

		private void DrawModdedMenus() {
			num5 = 2;
			array9[0] = Language.GetTextValue("Standalone.WelcomeMessage");
			array[0] = true;
			num2 = 220;
			+num4 = 250;
			array9[1] = Language.GetTextValue("Standalone.Continue");
			if (selectedMenu == 1) {
				_showWelcomeMessage = false;
				SaveSettings();
				SoundEngine.PlaySound(11);
				menuMode = 0;
				netMode = 0;
			}
		}

		private static void MMRHelpText() {
			bool isClothierAlive = false;
			int clotherIndex = 0;
			bool isWitchDoctorAlive = false;
			int witchDoctorIndex = 0;
			for (int npcIndex = 0; npcIndex < 200; npcIndex++) {
				if (npc[npcIndex].active) {
					if (npc[npcIndex].type == NPCID.WitchDoctor) {
						isWitchDoctorAlive = true;
						witchDoctorIndex = npcIndex;
					}
					if (npc[npcIndex].type == NPCID.Clothier) {
						isClothierAlive = true;
						clotherIndex = npcIndex;
					}
					if (isClothierAlive && isWitchDoctorAlive) {
						break;
					}
				}
			}
			if (!NPC.downedSlimeKing) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.KingSlimeTip");
				return;
			}
			if (!NPC.downedBoss1) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.EyeOfCthulhuTip");
				return;
			}
			if (!NPC.downedBoss2 && WorldGen.crimson) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.BrainOfCthulhuTip");
				return;
			}
			else if (!NPC.downedBoss2) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.EaterOfWorldsTip");
				return;
			}
			if (!NPC.downedQueenBee) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.QueenBeeTip");
				return;
			}
			if (!NPC.downedBoss3) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.SkeletronTip");
				return;
			}
			if (!Main.hardMode) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.WallOfFleshTip");
				return;
			}
			if (!NPC.downedQueenSlime) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.QueenSlimeTip");
				return;
			}
			if (!NPC.downedMechBoss2) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.TheTwinsTip");
				return;
			}
			if (!NPC.downedMechBoss1) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.TheDestroyerTip");
				return;
			}
			if (!NPC.downedMechBoss3) {
				if (isClothierAlive) {
					npcChatText = Language.GetTextValueWith("Standalone.GuideMMRHelp.SkeletronPrimeTip1", npc[clotherIndex].GivenOrTypeName);
				}
				else {
					npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.SkeletronPrimeTip2");
				}

				return;
			}
			if (!NPC.downedPlantBoss) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.PlanteraTip");
				return;
			}
			if (!NPC.downedGolemBoss) {
				if (isWitchDoctorAlive) {
					npcChatText = Language.GetTextValueWith("Standalone.GuideMMRHelp.GolemTip1", npc[witchDoctorIndex].GivenOrTypeName);
				}
				else {
					npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.GolemTip2");
				}

				return;
			}
			if (!NPC.downedEmpressOfLight) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.EmpressOfLightTip");
				return;
			}
			if (!NPC.downedAncientCultist) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.LunaticCultistTip");
				return;
			}
			if (!NPC.downedTowers) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.PillarTip");
				return;
			}
			if (!NPC.downedMoonlord) {
				npcChatText = Language.GetTextValue("Standalone.GuideMMRHelp.MoonLordTip");
				return;
			}
		}
	}
}
