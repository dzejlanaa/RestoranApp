using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;

namespace RestaurantApp.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class JeloController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public JeloController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


       
        [HttpGet]
        public JeloGetAllVM Get()
        {
            var R = new Random();
            var ToSkip = R.Next(0, _dbContext.Jela.Count());
            

            var data = _dbContext.Jela
                .Select(s => new JeloGetAllVM
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Cijena = s.Cijena,
                    restoran_id = s.restoran_id,
                    restoran = s.restoran

                })
                .AsQueryable();
            return data.Skip(ToSkip).Take(1).First();

        }
        [HttpGet]
        public List<JeloGetAllVM> GetAll(string? name)
        {
            var data = _dbContext.Jela.Where(x => name == null || x.Naziv.StartsWith(name)).OrderByDescending(s => s.Id)
                .Select(s => new JeloGetAllVM
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Cijena = s.Cijena,
                    restoran_id = s.restoran_id,
                    restoran= s.restoran

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] JeloAddVM x)
        {
            

            Jelo student;

            if (id == 0)
            {
                student = new Jelo()
                {
                   created_time=DateTime.Now,
                };
                _dbContext.Add(student);
            }
            else
            {
                student = _dbContext.Jela.Find(id);
                if (student == null)
                    return BadRequest("Ne postoji jelo sa ovim IDom!");
            }

            student.Naziv = x.Naziv;
            student.Cijena = x.Cijena;
            student.restoran_id = x.restoran_id;
           
            _dbContext.SaveChanges();

            return Ok(student);
        }

    }
}
