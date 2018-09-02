# GameShop
This is an application that allows to View, Add and Delete Games from Games Shop
![alt text](https://github.com/RafaelValiev/GameShop/blob/master/Screenshots/Main.PNG)
![alt text](https://github.com/RafaelValiev/GameShop/blob/master/Screenshots/NewGame.PNG)

Installation Guide:
1. Download repository
2. Add path to the database file(GameShopDb\Dev and GameShopDb\Release) in the Web.config(release and debug) of TestProjects.Services
3. Deploy web api by running TestProjects.Services solution. 
4. Open Form/game_shop.html

There are several projects in this solution:
GameShopFolder
- GameShopEntities
  Contains models(Game model) and constants(Developers and Genres arrays) 
- GameShop
  Project that can Add, Delete and View All games stored in the database.
- Common
  Works with Nlogger and Service settings from the sections in Web.config (for now only connection string, but can be expanded)
  
  Front is based on vue.js, bootstrap 4, jquery and was written with native javascript.
