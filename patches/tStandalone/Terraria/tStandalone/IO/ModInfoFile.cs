using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.IO;
using Terraria.UI;
using Terraria.Utilities;

namespace Terraria.tStandalone.IO
{
	public class ModInfoFile
	{
		public readonly string Path;
		public readonly bool IsCloudSave;
		private Dictionary<string, Dictionary<string, bool>> _data = new Dictionary<string, Dictionary<string, bool>>();

		public ModInfoFile(string path, bool isCloud) {
			Path = path;
			IsCloudSave = isCloud;
		}

		public void SaveModInfo(FileData fileData) {
			if (!_data.ContainsKey(fileData.Type))
				_data.Add(fileData.Type, new Dictionary<string, bool>());

			_data[fileData.Type][fileData.GetFileName()] = fileData.IsFavorite;
			Save();
		}

		public void ClearEntry(FileData fileData) {
			if (_data.ContainsKey(fileData.Type)) {
				_data[fileData.Type].Remove(fileData.GetFileName());
				Save();
			}
		}

		public bool IsDisplayingModData(FileData fileData) {
			if (!_data.ContainsKey(fileData.Type))
				return false;

			string fileName = fileData.GetFileName();
			if (_data[fileData.Type].TryGetValue(fileName, out bool value))
				return value;

			return false;
		}

		public void Save() {
			try {
				string s = JsonConvert.SerializeObject(_data, Formatting.Indented);
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				FileUtilities.WriteAllBytes(Path, bytes, IsCloudSave);
			}
			catch (Exception exception) {
				FancyErrorPrinter.ShowFileSavingFailError(exception, Path);
				throw;
			}
		}

		public void Load() {
			if (!FileUtilities.Exists(Path, IsCloudSave)) {
				_data.Clear();
				return;
			}

			try {
				byte[] bytes = FileUtilities.ReadAllBytes(Path, IsCloudSave);
				string @string = Encoding.ASCII.GetString(bytes);
				_data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(@string);
				if (_data == null)
					_data = new Dictionary<string, Dictionary<string, bool>>();
			}
			catch (Exception) {
				Console.WriteLine("Unable to load tStandalone\\modinfo.json file ({0} : {1})", Path, IsCloudSave ? "Cloud Save" : "Local Save");
			}
		}
	}
}
