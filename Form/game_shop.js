'use strict';

if (!window.GameShop) {
    window.GameShop = (function () {
        const getGamesServiceUrl = "http://localhost:63419/api/gameshop/get_games";
        const addGameServiceUrl = "http://localhost:63419/api/gameshop/add_game";
        const deleteGameServiceUrl = "http://localhost:63419/api/gameshop/delete_game";
        const getDevelopersServiceUrl = "http://localhost:63419/api/gameshop/get_developers";
        const getGenresServiceUrl = "http://localhost:63419/api/gameshop/get_genres";
        let games = [];
        let genres = [];
        let developers = [];

        let vueJs = null;

        function game(id, title, description, isAvailable, releaseDate, genre, developer) {
            return {
                id, title, description, isAvailable, releaseDate, genre, developer
            }
        }

        function loadDevelopers() {
            const dfd = $.Deferred();
            $.ajax({
                url: getDevelopersServiceUrl,
                type: "GET",
                success: function (results) {
                    developers = results;
                    dfd.resolve();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //TODO: Add popup window about error
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                    dfd.reject();
                }
            });
            return dfd.promise();
        }

        function loadGenres() {
            const dfd = $.Deferred();
            $.ajax({
                url: getGenresServiceUrl,
                type: "GET",
                success: function (results) {
                    genres = results;
                    dfd.resolve();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //TODO: Add popup window about error
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                    dfd.reject();
                }
            });
            return dfd.promise();
        }

        function loadGames() {
            const dfd = $.Deferred();
            $.ajax({
                url: getGamesServiceUrl,
                type: "GET",
                success: function (results) {
                    games = [];
                    results.forEach(function (item) {
                        games.push(game(item["Id"], item["Title"], item["Description"], item["IsAvailable"], item["ReleaseDate"], item["Genre"], item["Developer"]));
                    });
                    dfd.resolve();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //TODO: Add popup window about error
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                    dfd.reject();
                }
            });
            return dfd.promise();
        }


        function addGame() {
            vueJs._data.modalVisibility = false;

            const game = {
                Title: $("#newGameTitle").val(),
                Description: $("#newGameDescription").val(),
                IsAvailable: $("#newGameAvailability")[0].checked,
                ReleaseDate: $("#newGameReleaseDate").val(),
                Genre: vueJs._data.newGameGenre,
                Developer: vueJs._data.newGameDeveloper
            };

            $.ajax({
                url: addGameServiceUrl,
                type: "POST",
                data: game,
                success: function () {
                    //TODO: Add some animation about  success adding
                    location.reload();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //TODO: Add popup window about error
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });
        }


        function deleteGame() {
            const idToDelete = vueJs._data.games[vueJs._data.selectedGameIndex].id;
            $.ajax({
                url: deleteGameServiceUrl + "/" + idToDelete,
                type: "GET",
                success: function () {
                    //TODO: Add some animation about  success deleting
                    location.reload();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //TODO: Add popup window about error
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });
        }

        function initVue() {
            vueJs = new Vue({
                el: "#gameShop",
                data: {
                    games: games,
                    developers: developers,
                    genres: genres,
                    newGameGenre: genres[0],
                    newGameDeveloper: developers[0],
                    game: games[0],
                    selectedGameIndex: 0,
                    search: "",
                    modalVisibility: false
                },
                methods: {
                    selectGame: function (index) {
                        this.game = games[index];
                        this.selectedGameIndex = index;
                    },
                    addGame: addGame,
                    deleteGame: deleteGame
                },
                computed: {
                    filteredGames() {
                        const self = this;
                        const filteredGames = this.games.filter(function (game) {
                            return game.title.toLowerCase().indexOf(self.search.toLowerCase()) > -1
                        });
                        return filteredGames;
                    }
                }
            });
        }


        // Load all necessary data and fill form fields
        const promises = []
        promises.push(loadGames());
        promises.push(loadGenres());
        promises.push(loadDevelopers());

        $.when.apply($, promises).then(function () {
            initVue();
        });        
    })();
}