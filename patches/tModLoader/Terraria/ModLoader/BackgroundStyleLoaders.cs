﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.Graphics.Effects;

namespace Terraria.ModLoader
{
	//todo: further documentation
	/// <summary>
	/// This serves as the central class from which ModUgBgStyle functions are supported and carried out.
	/// </summary>
	public static class UgBgStyleLoader
	{
		public const int vanillaUgBgStyleCount = 18;
		private static int nextUgBgStyle = vanillaUgBgStyleCount;
		internal static readonly IList<ModUgBgStyle> ugBgStyles = new List<ModUgBgStyle>();

		internal static int ReserveBackgroundSlot() {
			int reserve = nextUgBgStyle;
			nextUgBgStyle++;
			return reserve;
		}

		/// <summary>
		/// Returns the ModUgBgStyle object with the given ID.
		/// </summary>
		public static ModUgBgStyle GetUgBgStyle(int style) {
			return style >= vanillaUgBgStyleCount && style < nextUgBgStyle
				? ugBgStyles[style - vanillaUgBgStyleCount] : null;
		}

		internal static void ResizeAndFillArrays() {
		}

		internal static void Unload() {
			nextUgBgStyle = vanillaUgBgStyleCount;
			ugBgStyles.Clear();
		}

		public static void ChooseStyle(ref int style) {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}
			foreach (var ugBgStyle in ugBgStyles) {
				if (ugBgStyle.ChooseBgStyle()) {
					style = ugBgStyle.Slot;
				}
			}
			foreach (var hook in GlobalBgStyleLoader.HookChooseUgBgStyle) {
				hook(ref style);
			}
		}

		public static void FillTextureArray(int style, int[] textureSlots) {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}
			var ugBgStyle = GetUgBgStyle(style);
			if (ugBgStyle != null) {
				ugBgStyle.FillTextureArray(textureSlots);
			}
			foreach (var hook in GlobalBgStyleLoader.HookFillUgTextureArray) {
				hook(style, textureSlots);
			}
		}
	}

	public static class SurfaceBgStyleLoader
	{
		public const int VanillaSurfaceBgStyleCount = Main.BG_STYLES_COUNT;

		private static int nextSurfaceBgStyle = VanillaSurfaceBgStyleCount;
		
		internal static readonly IList<ModSurfaceBgStyle> surfaceBgStyles = new List<ModSurfaceBgStyle>();

		//public static int SurfaceStyleCount => nextSurfaceBackgroundStyle;

		internal static int ReserveBackgroundSlot() {
			int reserve = nextSurfaceBgStyle;
			nextSurfaceBgStyle++;
			return reserve;
		}

		/// <summary>
		/// Returns the ModSurfaceBgStyle object with the given ID.
		/// </summary>
		public static ModSurfaceBgStyle GetSurfaceBgStyle(int style) {
			return style >= VanillaSurfaceBgStyleCount && style < nextSurfaceBgStyle
				? surfaceBgStyles[style - VanillaSurfaceBgStyleCount] : null;
		}

		internal static void ResizeAndFillArrays() {
			Array.Resize(ref Main.bgAlphaFrontLayer, nextSurfaceBgStyle);
			Array.Resize(ref Main.bgAlphaFarBackLayer, nextSurfaceBgStyle);
		}

		internal static void Unload() {
			nextSurfaceBgStyle = VanillaSurfaceBgStyleCount;
			surfaceBgStyles.Clear();
		}

		public static void ChooseStyle(ref int style) {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}
			foreach (var surfaceBgStyle in surfaceBgStyles) {
				if (surfaceBgStyle.ChooseBgStyle()) {
					style = surfaceBgStyle.Slot;
				}
			}
			foreach (var hook in GlobalBgStyleLoader.HookChooseSurfaceBgStyle) {
				hook(ref style);
			}
		}

		public static void ModifyFarFades(int style, float[] fades, float transitionSpeed) {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}
			var surfaceBgStyle = GetSurfaceBgStyle(style);
			if (surfaceBgStyle != null) {
				surfaceBgStyle.ModifyFarFades(fades, transitionSpeed);
			}
			foreach (var hook in GlobalBgStyleLoader.HookModifyFarSurfaceFades) {
				hook(style, fades, transitionSpeed);
			}
		}

		public static void DrawFarTexture() {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}

			// TODO: Causes background to flicker during load because Main.bgAlpha2 is resized after surfaceBgStyles is added to in AutoLoad.
			foreach (var style in surfaceBgStyles) {
				int slot = style.Slot;
				float alpha = Main.bgAlphaFarBackLayer[slot];

				Main.ColorOfSurfaceBackgroundsModified = Main.ColorOfSurfaceBackgroundsBase * alpha;

				if (alpha > 0f) {
					int textureSlot = style.ChooseFarTexture();

					if (textureSlot >= 0 && textureSlot < TextureAssets.Background.Length) {
						Main.instance.LoadBackground(textureSlot);

						for (int k = 0; k < Main.instance.bgLoops; k++) {
							Main.spriteBatch.Draw(
								TextureAssets.Background[textureSlot].Value,
								new Vector2(Main.instance.bgStartX + Main.bgWidthScaled * k, Main.instance.bgTopY),
								new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
								Main.ColorOfSurfaceBackgroundsModified,
								0f,
								default,
								Main.bgScale,
								SpriteEffects.None,
								0f
							);
						}
					}
				}
			}
		}

		public static void DrawMiddleTexture() {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}

			foreach (var style in surfaceBgStyles) {
				int slot = style.Slot;
				float alpha = Main.bgAlphaFarBackLayer[slot];

				Main.ColorOfSurfaceBackgroundsModified = Main.ColorOfSurfaceBackgroundsBase * alpha;

				if (alpha > 0f) {
					int textureSlot = style.ChooseMiddleTexture();

					if (textureSlot >= 0 && textureSlot < TextureAssets.Background.Length) {
						Main.instance.LoadBackground(textureSlot);

						for (int k = 0; k < Main.instance.bgLoops; k++) {
							Main.spriteBatch.Draw(
								TextureAssets.Background[textureSlot].Value,
								new Vector2(Main.instance.bgStartX + Main.bgWidthScaled * k, Main.instance.bgTopY),
								new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
								Main.ColorOfSurfaceBackgroundsModified,
								0f,
								default,
								Main.bgScale,
								SpriteEffects.None,
								0f
							);
						}
					}
				}
			}
		}

		public static void DrawCloseBackground(int style) {
			if (!GlobalBgStyleLoader.loaded) {
				return;
			}

			if (Main.bgAlphaFrontLayer[style] <= 0f) {
				return;
			}

			var surfaceBgStyle = GetSurfaceBgStyle(style);

			if (surfaceBgStyle != null && surfaceBgStyle.PreDrawCloseBackground(Main.spriteBatch)) {
				Main.bgScale = 1.25f;
				Main.instance.bgParallax = 0.37;

				float a = 1800.0f;
				float b = 1750.0f;
				int textureSlot = surfaceBgStyle.ChooseCloseTexture(ref Main.bgScale, ref Main.instance.bgParallax, ref a, ref b);

				if (textureSlot >= 0 && textureSlot < TextureAssets.Background.Length) {
					//Custom: bgScale, textureslot, patallaz, these 2 numbers...., Top and Start?
					Main.instance.LoadBackground(textureSlot);
					Main.bgScale *= 2f;
					Main.bgWidthScaled = (int)((float)Main.backgroundWidth[textureSlot] * Main.bgScale);

					SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / (float)Main.instance.bgParallax);

					Main.instance.bgStartX = (int)(-Math.IEEERemainder(Main.screenPosition.X * Main.instance.bgParallax, Main.bgWidthScaled) - (Main.bgWidthScaled / 2));
					Main.instance.bgTopY = (int)((-Main.screenPosition.Y + Main.instance.screenOff / 2f) / (Main.worldSurface * 16.0) * a + b) + (int)Main.instance.scAdj;
					
					if (Main.gameMenu) {
						Main.instance.bgTopY = 320;
					}

					Main.instance.bgLoops = Main.screenWidth / Main.bgWidthScaled + 2;

					if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0) {
						for (int k = 0; k < Main.instance.bgLoops; k++) {
							Main.spriteBatch.Draw(
								TextureAssets.Background[textureSlot].Value,
								new Vector2(Main.instance.bgStartX + Main.bgWidthScaled * k, Main.instance.bgTopY),
								new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
								Main.ColorOfSurfaceBackgroundsModified,
								0f,
								default,
								Main.bgScale,
								SpriteEffects.None,
								0f
							);
						}
					}
				}
			}
		}
	}

	internal static class GlobalBgStyleLoader
	{
		internal static readonly IList<GlobalBgStyle> globalBgStyles = new List<GlobalBgStyle>();
		internal static bool loaded = false;
		internal delegate void DelegateChooseUgBgStyle(ref int style);
		internal static DelegateChooseUgBgStyle[] HookChooseUgBgStyle;
		internal delegate void DelegateChooseSurfaceBgStyle(ref int style);
		internal static DelegateChooseSurfaceBgStyle[] HookChooseSurfaceBgStyle;
		internal static Action<int, int[]>[] HookFillUgTextureArray;
		internal static Action<int, float[], float>[] HookModifyFarSurfaceFades;

		internal static void ResizeAndFillArrays(bool unloading = false) {
			ModLoader.BuildGlobalHook(ref HookChooseUgBgStyle, globalBgStyles, g => g.ChooseUgBgStyle);
			ModLoader.BuildGlobalHook(ref HookChooseSurfaceBgStyle, globalBgStyles, g => g.ChooseSurfaceBgStyle);
			ModLoader.BuildGlobalHook(ref HookFillUgTextureArray, globalBgStyles, g => g.FillUgTextureArray);
			ModLoader.BuildGlobalHook(ref HookModifyFarSurfaceFades, globalBgStyles, g => g.ModifyFarSurfaceFades);

			if (!unloading) {
				loaded = true;
			}
		}

		internal static void Unload() {
			loaded = false;
			globalBgStyles.Clear();
		}
	}
}
