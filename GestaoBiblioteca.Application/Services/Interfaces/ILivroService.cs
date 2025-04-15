using GestaoBiblioteca.Application.InputModels;
using GestaoBiblioteca.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Application.Services.Interfaces
{
   public interface ILivroService
    {
        List<LivroViewModel> GetAll(string query);
        LivroDetailsModel GetById(int id);
        public int Create(NewLivroInputModel inputModel);
        void Update(UpdateLivroInputModel inputModel);
        void Delete(int id);
    }
}
