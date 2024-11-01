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
        public async Task<IActionResult> List(string searchQuery)
        {
            // Start med at hente alle titler fra databasen
            var titlesQuery = dbContext.Titles.AsQueryable();

            // Anvend søgefilter, hvis der er en søgeforespørgsel
            if (!string.IsNullOrEmpty(searchQuery))
            {
                titlesQuery = titlesQuery.Where(t => t.PrimaryTitle.Contains(searchQuery) || t.OriginalTitle.Contains(searchQuery));
            }

            // Begræns resultaterne til de første 50 titler
            var titles = await titlesQuery.Take(50).ToListAsync();

            return View(titles);
        }

    }
}
