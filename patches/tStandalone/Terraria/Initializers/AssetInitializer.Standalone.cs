using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;

namespace Terraria.Initializers
{
	partial class AssetInitializer
	{
		private static void InitializetStandaloneAssets(AssetRequestMode mode) {
			TextureAssets.MMRLogo = LoadAsset<Texture2D>("Images\\MMRLogo", mode);
			TextureAssets.MMRLogo2 = LoadAsset<Texture2D>("Images\\MMRLogo2", mode);
			TextureAssets.MMRLogo3 = LoadAsset<Texture2D>("Images\\MMRLogo3", mode);
			TextureAssets.MMRLogo4 = LoadAsset<Texture2D>("Images\\MMRLogo4", mode);
		}
	}
}
