namespace Terraria.Chat
{
	partial class ChatCommandProcessor
	{
		public void ClearCommands() {
			_localizedCommands.Clear();
			_commands.Clear();
			_aliases.Clear();
		}
	}
}
