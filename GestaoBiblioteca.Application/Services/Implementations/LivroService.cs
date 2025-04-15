using GestaoBiblioteca.Application.InputModels;
using GestaoBiblioteca.Application.Services.Interfaces;
using GestaoBiblioteca.Application.ViewModels;
using GestaoBiblioteca.Core.Entities;
using GestaoBiblioteca.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Application.Services.Implementations
{
    public class LivroService: ILivroService
    {
        private readonly LivrosDbContext _livrosDbContext;
        public LivroService(LivrosDbContext livrosDbContext)
        {
            _livrosDbContext = livrosDbContext;
        }
        public int Create(NewLivroInputModel inputModel)
        {
            var livro = new Livro (inputModel.Id, inputModel.Titulo, inputModel.Titulo, inputModel.ISBN, inputModel.AnoPublicacao);
            _livrosDbContext.Livros.Add(livro);
            return livro.Id;
        }

        void ILivroService.Delete(int id)
        {
            var livro = _livrosDbContext.Livros.SingleOrDefault(l => l.Id == id);
            livro.EliminarLivro();
        }

        List<LivroViewModel> ILivroService.GetAll(string query)
        {
            var livros = _livrosDbContext.Livros;

            if (!string.IsNullOrWhiteSpace(query)) 
            {
                livros = livros
                    .Where(l =>
                    l.Titulo.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    l.Autor.Contains(query, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
                
            var livrosViewModel = livros
            .Select(l => new LivroViewModel(l.Id, l.Titulo, l.Autor))
            .ToList();

            return livrosViewModel;
        }
        LivroDetailsModel ILivroService.GetById(int id)
        {
            var livro = _livrosDbContext.Livros.SingleOrDefault(l => l.Id == id);

            if (livro == null) return null;

            var livroDetailsModel = new LivroDetailsModel
            {
               IdLivro = livro.Id,
               Titulo = livro.Titulo,
               Autor = livro.Autor,
               ISBN = livro.ISBN,
               AnoPublicacao = livro.AnoPublicacao,
            };

            return livroDetailsModel;
        }
        void ILivroService.Update(UpdateLivroInputModel inputModel)
        {
            var livro = _livrosDbContext.Livros.SingleOrDefault(l => l.Id == inputModel.Id);
            livro.Update(inputModel.Autor, inputModel.Titulo, inputModel.ISBN, inputModel.AnoPublicacao);
        }
    }
}
