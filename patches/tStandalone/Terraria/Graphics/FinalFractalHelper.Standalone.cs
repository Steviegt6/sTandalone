using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria.Graphics
{
	partial struct FinalFractalHelper
	{
		private static Dictionary<int, FinalFractalProfile> _fractalProfilesFunny;
		private static Dictionary<int, FinalFractalProfile> _fractalProfilesTerra = new Dictionary<int, FinalFractalProfile> {
			{ ItemID.TerraToilet, new FinalFractalProfile(20f, new Color(80, 222, 122)) }       };
		private static Dictionary<int, FinalFractalProfile> _fractalProfilesCactus = new Dictionary<int, FinalFractalProfile> {
			{ ItemID.Cactus, new FinalFractalProfile(10f, Color.Green) }       };

		public static void InitializeEveryItemFinalFractalProfile() {
			_fractalProfilesFunny = new Dictionary<int, FinalFractalProfile>();

			for (int i = 0; i < ItemID.Count; i++) {
				_fractalProfilesFunny.Add(i, new FinalFractalProfile(Main.rand.Next(10, 60), new Color(Main.rand.Next(256), Main.rand.Next(256), Main.rand.Next(256))));
			}
		}

		public static int GetRandomProfileIndexFunny() => _fractalProfilesFunny.Keys.ToList()[Main.rand.Next(_fractalProfilesFunny.Keys.ToList().Count)];

		public static int GetRandomProfileIndexTerra() => _fractalProfilesTerra.Keys.ToList()[Main.rand.Next(_fractalProfilesTerra.Keys.ToList().Count)];

		public static int GetRandomProfileIndexCactus() => _fractalProfilesCactus.Keys.ToList()[Main.rand.Next(_fractalProfilesCactus.Keys.ToList().Count)];

		public static FinalFractalProfile GetFinalFractalProfileFunny(int usedSwordId) => !_fractalProfilesFunny.TryGetValue(usedSwordId, out FinalFractalProfile value) ? _defaultProfile : value;

		public static FinalFractalProfile GetFinalFractalProfileTerra(int usedSwordId) => !_fractalProfilesTerra.TryGetValue(usedSwordId, out FinalFractalProfile value) ? _defaultProfile : value;

		public static FinalFractalProfile GetFinalFractalProfileCactus(int usedSwordId) => !_fractalProfilesCactus.TryGetValue(usedSwordId, out FinalFractalProfile value) ? _defaultProfile : value;
	}
}
