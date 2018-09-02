using TestProjects.Services.Common.Helpers;

namespace TestProjects.Services.GameShop
{
	public class LogHelper
	{
		public const string CreateLoggerName = "GameShopLogger";

		public static void Trace(string message)
		{
			ServiceLogHelper.Trace(message, CreateLoggerName);
		}

		public static void Error(string message)
		{
			ServiceLogHelper.Error(message, CreateLoggerName);
		}
	}
}
