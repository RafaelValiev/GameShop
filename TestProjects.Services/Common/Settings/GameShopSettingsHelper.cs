using System.Collections.Specialized;
using System.Configuration;

namespace TestProjects.Services.Common.Settings
{
	/// <summary>
	/// Класс для работы с настройками конфигурации сервиса для GameShop
	/// </summary>
	public class GameShopSettingsHelper
	{
		private static GameShopSettingsHelper _instance;
		private static readonly object SyncRoot = new object();

		public readonly string SourceFile;

		private GameShopSettingsHelper()
		{
			var gameShopSection = ConfigurationManager.GetSection("GameShop") as NameValueCollection;
			SourceFile = gameShopSection["SourceFile"];
		}

		public static GameShopSettingsHelper GetInstance()
		{
			if (_instance == null)
			{
				lock (SyncRoot)
				{
					if (_instance == null)
						_instance = new GameShopSettingsHelper();
				}
			}
			return _instance;
		}
	}
}
