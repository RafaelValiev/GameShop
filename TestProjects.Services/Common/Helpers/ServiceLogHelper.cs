using NLog;
using System.Web;

namespace TestProjects.Services.Common.Helpers
{
	/// <summary>
	/// Класс для логирования сервиса. В качестве уникального идентификатора сессии использует SessionID.
	/// </summary>
	public class ServiceLogHelper
	{
		public static string GetCurrentId()
		{
			return HttpContext.Current?.Session?.SessionID;
		}

		public static void Trace(string message, string loggerName)
		{
			LogManager.GetLogger(loggerName).Trace($"{GetCurrentId()}: {message}");
		}

		public static void Error(string message, string loggerName)
		{
			LogManager.GetLogger(loggerName).Error($"{GetCurrentId()}: {message}");
		}
	}

}
