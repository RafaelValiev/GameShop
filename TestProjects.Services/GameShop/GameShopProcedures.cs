using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TestProjects.Services.Common.Settings;
using TestProjects.Services.GameShopEntites.Models;

namespace TestProjects.Services.GameShop
{
    public class GameShopProcedures
    {
		public readonly string DbPath;
		public GameShopProcedures()
		{
			DbPath = GameShopSettingsHelper.GetInstance().SourceFile;
		}

		public List<Game> GetGames()
		{
			LogHelper.Trace("Get All Games");
			var games = new List<Game>();
			using (var m_dbConnection = new SQLiteConnection($@"Data Source={DbPath}"))
			{
				m_dbConnection.Open();

				var sql = "SELECT * FROM Games";
				var command = new SQLiteCommand(sql, m_dbConnection);
				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					games.Add(new Game
					{ 
						Id = Convert.ToInt32(reader["Id"]),
						Title = reader["Title"] as string,
						Description = reader["Description"] as string,
						IsAvailable = (bool)reader["IsAvailable"],
						ReleaseDate = ((DateTime)reader["ReleaseDate"]).ToString("yyyy-MM-dd"),
						Genre = reader["Genre"] as string,
						Developer = reader["Developer"] as string
					});
				}

				m_dbConnection.Close();
			};
				
			return games;			
		}

		public void AddGame(Game newGame)
		{
			LogHelper.Trace($"Add Game {newGame.Title}");
			using (var m_dbConnection = new SQLiteConnection($@"Data Source={DbPath}"))
			{
				m_dbConnection.Open();

				var sql = "INSERT INTO Games(Title,Description,IsAvailable,ReleaseDate, Genre,Developer)" +
					"VALUES" +
					$"('{newGame.Title}','{newGame.Description}','{newGame.IsAvailable}','{newGame.ReleaseDate}', '{newGame.Genre}','{newGame.Developer}');";
				var command = new SQLiteCommand(sql, m_dbConnection);
				command.ExecuteNonQuery();

				m_dbConnection.Close();
			};
		}

		public void RemoveGameById(int Id)
		{
			LogHelper.Trace($"Delete Game {Id}");
			using (var m_dbConnection = new SQLiteConnection($@"Data Source={DbPath}"))
			{
				m_dbConnection.Open();

				var sql = $"DELETE FROM Games WHERE Id = '{Id}'";
				var command = new SQLiteCommand(sql, m_dbConnection);
				command.ExecuteNonQuery();

				m_dbConnection.Close();
			};
		}
	}
}
