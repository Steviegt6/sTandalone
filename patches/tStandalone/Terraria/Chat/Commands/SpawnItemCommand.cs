using Terraria.ID;

namespace Terraria.Chat.Commands
{
	// Added by tStandalone.
	[ChatCommand("SpawnItem")]
	public class SpawnItemCommand : IChatCommand
	{

		public void ProcessIncomingMessage(string text, byte clientId) {
			if (int.TryParse(text, out int num) && num > 0 && num < ItemID.Count) {
				Main.player[clientId].QuickSpawnItem(num);
			}
		}

		// Required by IChatCommand.
		public void ProcessOutgoingMessage(ChatMessage message) {
		}
	}
}
