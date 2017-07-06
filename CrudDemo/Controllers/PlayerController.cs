using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudDemo.Models;  

namespace CrudDemo.Controllers
{
    public class PlayerController : Controller
    {

        private CrudContext _context = null;

        public PlayerController()
        {
            _context = new CrudContext();
        }
        // GET: /Player/
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = _context.players.ToList();
            return Json(new { list = listPlayers }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id)
        {
            Player player = _context.players.Where(c => c.PlayerId == id).SingleOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player)
        {
            _context.players.Add(player);
                _context.SaveChanges();
            return Json(new { update = "Player added successfully" });
        }

        public JsonResult UpdatePlayer(Player player)
        {
            _context.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { update = "Player updated successfully" });
        }

        public JsonResult DeletePlayer(int id)
        {
            Player player = _context.players.Where(c => c.PlayerId == id).SingleOrDefault();
            _context.players.Remove(player);
            _context.SaveChanges();
            return Json(new { update = "Player deleted successfully" });
        }



    }
}