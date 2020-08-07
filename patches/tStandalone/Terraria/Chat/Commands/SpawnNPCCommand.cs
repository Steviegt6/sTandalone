using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	[ChatCommand("SpawnNPC")]
	public class SpawnNPCCommand : IChatCommand
	{

		public void ProcessIncomingMessage(string text, byte clientId) {
			int num;
			if (Int32.TryParse(text, out num)) {
				if (num > 0 && num < NPCID.Count) {
					Player caller = Main.player[clientId];
					NPC.NewNPC((int)caller.position.X, (int)caller.position.Y, num);
				}
			}
		}

		public void ProcessOutgoingMessage(ChatMessage message) {
		}
	}
}
