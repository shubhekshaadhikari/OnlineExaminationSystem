using Microsoft.AspNetCore.Mvc;
using OnlineExamination.BLL.Services;
using OnlineExamination.ViewModels;

namespace OnlineExamination.Web.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IGroupService _groupSewrvice;

        public ExamsController(IExamService examService, IGroupService groupSewrvice)
        {
            _examService = examService;
            _groupSewrvice = groupSewrvice;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
            return View(_examService.GetAll(pageNumber,pageSize));
        }
        public IActionResult Create()
        {
            var model = new ExamViewModel();
            model.GroupList = _groupSewrvice.GetAllGroups();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExamViewModel examViewModel)
        {
            if(ModelState.IsValid)
            {
                await _examService.AddAsync(examViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(examViewModel);
        }

    }
}
