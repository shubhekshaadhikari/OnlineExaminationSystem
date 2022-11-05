using OnlineExamination.DataAcess;
using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public interface IExamService
    {
        PagedResult<ExamViewModel> GetAll(int pageNumber, int pageSize);
        Task<ExamViewModel> AddAsync(ExamViewModel examVM);
        IEnumerable<Exams> GetAllExams();

    }
}
