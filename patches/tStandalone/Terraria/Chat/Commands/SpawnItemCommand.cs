using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	[ChatCommand("SpawnItem")]
	public class SpawnItemCommand : IChatCommand
	{

		public void ProcessIncomingMessage(string text, byte clientId) {
			int num;
			if (Int32.TryParse(text, out num)) {
				if (num > 0 && num < ItemID.Count)
					Main.player[clientId].QuickSpawnItem(num);
			}
		}

		public void ProcessOutgoingMessage(ChatMessage message) {
		}
	}
}
