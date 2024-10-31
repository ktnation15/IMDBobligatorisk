using IMDBobligatorisk.Data;
using IMDBobligatorisk.Models;
using IMDBobligatorisk.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMDBobligatorisk.Controllers
{
    public class IMDBsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public IMDBsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddIMDBViewModel viewModel)
        {
            var title = new Title
            {
                Tconst = viewModel.Tconst,
                TitleType = viewModel.TitleType,
                PrimaryTitle = viewModel.PrimaryTitle,
                OriginalTitle = viewModel.OriginalTitle,
                IsAdult = viewModel.IsAdult,
                StartYear = viewModel.StartYear,
                EndYear = viewModel.EndYear,
                RuntimeMinutes = viewModel.RuntimeMinutes,
                Genres = viewModel.Genres
            };
            await dbContext.Titles.AddAsync(title);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var titles = await dbContext.Titles.ToListAsync();
            return View(titles);
        }
    }
}
