using Microsoft.AspNetCore.Mvc;
using OnlineExamination.BLL.Services;
using OnlineExamination.ViewModels;

namespace OnlineExamination.Web.Controllers
{
    public class QnAsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQnAService _qnaService;

        public QnAsController(IExamService examService, IQnAService qnaService)
        {
            _examService = examService;
            _qnaService = qnaService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_qnaService.GetAll(pageNumber,pageSize));
        }
        public IActionResult Create()
        {
            var model = new QnAsViewModel();
            model.ExamList = _examService.GetAllExams();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QnAsViewModel qnasViewModel)
        {
            if (ModelState.IsValid)
            {
                await _qnaService.AddAsync(qnasViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(qnasViewModel);
        }
    }
}
