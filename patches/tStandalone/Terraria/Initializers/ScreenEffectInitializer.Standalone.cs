using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Terraria.Initializers
{
	partial class ScreenEffectInitializer
	{
		private static void LoadtStandaloneScreenEffects() {
			Filters.Scene["VerticalMirror"] = new Filter(new ScreenShaderData(Main.VerticalMirrorRef, "VerticallyMirror"), EffectPriority.Medium);
		}
	}
}
