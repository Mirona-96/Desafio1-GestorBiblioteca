using GestaoBiblioteca.Application.InputModels;
using GestaoBiblioteca.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Application.Services.Interfaces
{
    public interface IEmprestimoService
    {
        List<EmprestimoViewModel> GetAll(string query);
        EmprestimoDetailsViewModel GetById (int id);
        int Create (NewEmprestimoInputModel inputModel);
        void Update(UpdateEmprestimoInputModel inputModel);
        void Delete(int id);
        void Criado(int id);
        void Atrasado(int id);
        void Terminado (int id);
    }
}
