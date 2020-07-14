using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.sTandalone
{
	public class sMain
	{
		public static void sTandalonePut() {
			Main.Configuration.Put("ShowWelcomeMessage", Main._showWelcomeMessage);
		}
		public static void sTandaloneGet() {
			Main.Configuration.Get("ShowWelcomeMessage", ref Main._showWelcomeMessage);
		}
	}
}
