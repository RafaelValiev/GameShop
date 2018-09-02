using System;

namespace TestProjects.Services.GameShopEntites.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAvailable { get; set; }
		public string ReleaseDate { get; set; }
		public string Genre { get; set; }
		public string Developer { get; set; }
	}
}
