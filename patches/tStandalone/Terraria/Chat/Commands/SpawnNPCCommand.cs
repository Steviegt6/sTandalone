using Terraria.ID;

namespace Terraria.Chat.Commands
{
	// Added by tStandalone.
	[ChatCommand("SpawnNPC")]
	public class SpawnNPCCommand : IChatCommand
	{
		public void ProcessIncomingMessage(string text, byte clientId) {
			if (int.TryParse(text, out int num) && num > 0 && num < NPCID.Count) {
				NPC.NewNPC((int)Main.player[clientId].position.X, (int)Main.player[clientId].position.Y, num);
			}
		}

		// Required by IChatCommand
		public void ProcessOutgoingMessage(ChatMessage message) {
		}
	}
}
