using Terraria.ID;

namespace Terraria
{
	partial class Recipe
	{
		public void AddModdedRecipes() {
			currentRecipe.createItem.SetDefaults(ItemID.FirstFractal);
			currentRecipe.requiredItem[0].SetDefaults(ItemID.TerraBlade);
			currentRecipe.requiredItem[1].SetDefaults(ItemID.Meowmere);
			currentRecipe.requiredItem[2].SetDefaults(ItemID.StarWrath);
			currentRecipe.requiredTile[0] = TileID.LunarCraftingStation;
			AddRecipe();
		}
	}
}
