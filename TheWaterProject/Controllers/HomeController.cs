using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _waterRepository;

        public HomeController(IWaterRepository waterRepository)
        {
            _waterRepository = waterRepository;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var pageModel = new ProjectsListViewModel
            {
                Projects = _waterRepository.Projects
                    .OrderBy(x => x.ProjectName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _waterRepository.Projects.Count()
                }
            };           

    

            return View(pageModel);
        }

    }
}
