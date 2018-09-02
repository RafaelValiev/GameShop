using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TestProjects.Services.GameShop;
using TestProjects.Services.GameShopEntites.Models;
using TestProjects.Services.GameShopEntites.Const;

namespace Services.Controllers
{
	[RoutePrefix("api/gameshop")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class GameShopController : ApiController
	{
		GameShopProcedures gameShopProcedures;

		public GameShopController()
		{
			gameShopProcedures = new GameShopProcedures();
		}

		[HttpPost]
		[Route("add_game")]
		public void GenerateReport([FromBody] Game game)
		{
			try
			{
				gameShopProcedures.AddGame(game);
			}
			catch(Exception ex)
			{
				LogHelper.Error(ex.ToString());
				throw ex;
			}			
		}

		[HttpGet]
		[Route("delete_game/{Id}")]
		public void RemoveGameById(int Id)
		{
			try
			{
				gameShopProcedures.RemoveGameById(Id);
			}
			catch (Exception ex)
			{
				LogHelper.Error(ex.ToString());
				throw ex;
			}
		}

		[HttpGet]
		[Route("get_games")]
		public List<Game> GetReportStatus()
		{
			try
			{
				return gameShopProcedures.GetGames();
			}
			catch (Exception ex)
			{
				LogHelper.Error(ex.ToString());
				throw ex;
			}			 
		}
		[HttpGet]
		[Route("get_developers")]
		public string[] GetDevelopers()
		{
			try
			{
				return CommonConst.Developers;
			}
			catch (Exception ex)
			{
				LogHelper.Error(ex.ToString());
				throw ex;
			}
		}

		[HttpGet]
		[Route("get_genres")]
		public string[] GetGenres()
		{
			try
			{
				return CommonConst.GameGenres;
			}
			catch (Exception ex)
			{
				LogHelper.Error(ex.ToString());
				throw ex;
			}
		}
	}
}
