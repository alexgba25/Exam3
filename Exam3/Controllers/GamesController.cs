using Exam3.Data.DbGamesTableAdapters;
using Exam3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam3.Controllers
{
    public class GamesController
    {
        private videojuegosTableAdapter gamesAdapter = new videojuegosTableAdapter(); 


        public DataTable GetAllGames()
        {
            return gamesAdapter.GetData();
        }

        public void AddGames(Games games)
        {
            gamesAdapter.Insert(games.Nombre, games.Cantidad, games.Precio, games.Imagen);
        }
    }
}