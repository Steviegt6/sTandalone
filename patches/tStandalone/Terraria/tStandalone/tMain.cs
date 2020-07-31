﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.tStandalone
{
	public class tMain
	{
		internal static void tStandalonePut() {
			Main.Configuration.Put("ShowWelcomeMessage", Main._showWelcomeMessage);
			Main.Configuration.Put("UselessDontEditThis", Main.restartRequired);
			Main.Configuration.Put("TerrariaPlus", Main.terrariaPlus);
			Main.Configuration.Put("MasterModeReloaded", Main.masterModeReloaded);
			Main.Configuration.Put("FirstFractalRecipe", Main.firstFractalRecipe);
			Main.Configuration.Put("SlowerMasterModeRarity", Main.slowerMasterModeRarity);
			Main.Configuration.Put("AllAccessorySlotsInVanity", Main.allAccessoriesInVanitySlots);
		}
		internal static void tStandaloneGet() {
			Main.Configuration.Get("ShowWelcomeMessage", ref Main._showWelcomeMessage);
			Main.Configuration.Get("UselessDontEditThis", false);
			Main.Configuration.Get("TerrariaPlus", ref Main.terrariaPlus);
			Main.Configuration.Get("MasterModeReloaded", ref Main.masterModeReloaded);
			Main.Configuration.Get("FirstFractalRecipe", ref Main.firstFractalRecipe);
			Main.Configuration.Get("SlowerMasterModeRarity", ref Main.slowerMasterModeRarity);
			Main.Configuration.Get("AllAccessorySlotsInVanity", ref Main.allAccessoriesInVanitySlots);
		}

		internal static void UpdateEnabledMods() {
		}
	}
}