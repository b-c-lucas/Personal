using FHL.Data.DB.FHL;
using FHL.Data.DB.FHL.Entities;
using FHL.Data.DB.FHL.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FHL.Admin.Controllers
{
    public sealed class LeagueController : Controller
    {
        private readonly LeagueRepository leagueRepository;

        private FHLContext fhlContext;

        public LeagueController()
        {
            this.fhlContext = new FHLContext();

            this.leagueRepository = new LeagueRepository(this.fhlContext);
        }

        public async Task<ActionResult> Index()
        {
            return this.View(await this.leagueRepository.ToListAsync());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View(new League());
        }

        [HttpPost]
        public async Task<ActionResult> Add(League league)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(league);
            }

            this.leagueRepository.Add(league);

            await this.leagueRepository.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (this.fhlContext != null)
                {
                    this.fhlContext.Dispose();
                }
            }
            finally
            {
                this.fhlContext = null;
            }

            base.Dispose(disposing);
        }
    }
}