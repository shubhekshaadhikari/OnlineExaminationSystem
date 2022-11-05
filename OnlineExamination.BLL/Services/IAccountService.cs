using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public interface IAccountService
    {
        LoginViewModel Login(LoginViewModel vm);
        bool AddTeacher(UserViewModel vm);
        PagedResult<UserViewModel> GetAllTeachers(int pageNumber, int pageSize);


    }
}
