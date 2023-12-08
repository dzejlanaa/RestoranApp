using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using System.Runtime.InteropServices;

namespace RestaurantApp.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class RestoranController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public RestoranController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Restoran Get(int id)
        {
            return _dbContext.Restorani.Find(id);
        }
        [HttpGet]
        public List<RestoranGetAllVM> GetAll(string ? name)
        {
            var data = _dbContext.Restorani.Where(x => name == null || x.Naziv.StartsWith(name)).OrderByDescending(s => s.Id)
                .Select(s => new RestoranGetAllVM
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Adresa = s.Adresa,
                    Telefon = s.Telefon,
                    Tip = s.Tip,
              
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public List<CmbStavke> GetByAll()
        {
            var data = _dbContext.Restorani
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.Id,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }


        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] RestoranAddVM x)
        {
            

            Restoran student;
            if (id == 0)
            {
                student = new Restoran()
                {
                    Tip="Fast Food"
                };
                _dbContext.Add(student);
            }
            else
            {
                student = _dbContext.Restorani.Find(id);
                if (student == null)
                    return BadRequest("Ne postoji restoran sa ovim IDom!");
            }



            student.Naziv = x.Naziv;
            student.Adresa = x.Adresa;
            student.Telefon = x.Telefon;
            
            

            _dbContext.SaveChanges();

            return Ok(student);
        }

    }

    public class CmbStavke
    {
        public int id { get; set; }
        public string opis { get; set; }
    }
}
