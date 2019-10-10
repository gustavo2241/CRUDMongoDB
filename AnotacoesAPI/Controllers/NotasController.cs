using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotacoesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AnotacoesAPI.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index()
        {
            MongoDbContext dbContext = new MongoDbContext();
            List<Nota> listaNotas = dbContext.Notas.Find(m => true).ToList();
            return View(listaNotas);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var entity = dbContext.Notas.Find(m => m.Id == id).FirstOrDefault();
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Nota entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Notas.ReplaceOne(m => m.Id == entity.Id, entity);
            return View(entity);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Nota entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            entity.Id = Guid.NewGuid();
            dbContext.Notas.InsertOne(entity);
            return RedirectToAction("Index", "Notas");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Notas.DeleteOne(m => m.Id == id);
            return RedirectToAction("Index", "Notas");
        }
    }
}