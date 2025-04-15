using GestaoBiblioteca.Application.InputModels;
using GestaoBiblioteca.Application.Services.Interfaces;
using GestaoBiblioteca.Application.ViewModels;
using GestaoBiblioteca.Core.Entities;
using GestaoBiblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly GestaoBibliotecaDbContext _dbContext; //onde esta a lista dos emprestimos
        private readonly LivrosDbContext _livrosDbContext;

        public EmprestimoService (GestaoBibliotecaDbContext dbContext, LivrosDbContext livrosDbContext)
        {
            _dbContext = dbContext;
            _livrosDbContext = livrosDbContext;


            _dbContext.usuarios ??= new List<Usuario>();
            _livrosDbContext.Livros ??=new List<Livro>();
            _dbContext.emprestimos ??= new List<Emprestimo>();
        }

        private (string NomeUsuario, string TituloLivro) BuscarNomeUsuarioTituloLivro(int idUsuario, int idLivro)
        {
            var usuario = _dbContext.usuarios.FirstOrDefault(
                   u => u.Id == idUsuario);

            var livro = _livrosDbContext.Livros.FirstOrDefault(
                l => l.Id == idLivro);

            string NomeUsuario = usuario != null ? usuario.Nome : "Usuario não encontrado";
            string TituloLivro = livro != null ? livro.Titulo : "Livro não encontrado";

            return (TituloLivro, NomeUsuario);
        }

        public void Atrasado(int id)
        {
            var emprestimo = _dbContext.emprestimos.SingleOrDefault(emp => emp.Id == id);

            DateTime data = DateTime.Now;
            emprestimo.Atrasado(data);
        }

        public int Create(NewEmprestimoInputModel inputModel)
        {
            var emprestimo = new Emprestimo(inputModel.IdUsuario, inputModel.IdLivro ,inputModel.DataEmprestimo, inputModel.DataDevolucao);
            _dbContext.emprestimos.Add(emprestimo);
            return emprestimo.Id;
        }

        public void Criado(int id)
        {
            var emprestimo =  _dbContext.emprestimos.SingleOrDefault(emp => emp.Id == id);

            emprestimo.Criado();
        }

        public void Delete(int id)
        {
            var emprestimo = _dbContext.emprestimos.SingleOrDefault(e => e.Id == id);
            emprestimo.CancelarEmprestimo();
        }

        public List<EmprestimoViewModel> GetAll(string query)
        {
            var emprestimoViewModel = new List<EmprestimoViewModel>();

            foreach (var emprestimo in _dbContext.emprestimos)
            {
                var (nomeUsuario, tituloLivro) = BuscarNomeUsuarioTituloLivro(emprestimo.IdUsuario, emprestimo.IdLivro);

                if(!string.IsNullOrWhiteSpace(query) &&
                        !nomeUsuario.Contains(query,StringComparison.OrdinalIgnoreCase) &&
                        !tituloLivro.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    continue; //filtra se encontrar a "query"
                }

                emprestimoViewModel.Add(new EmprestimoViewModel
                {
                    IdEmprestimo = emprestimo.Id,
                    NomeUsuario = nomeUsuario,
                    TituloLivro = tituloLivro,
                    DataEmprestimo = emprestimo.DataEmprestimo
                });
            }

            return emprestimoViewModel;
        }

        public EmprestimoDetailsViewModel GetById(int id)
        {
            var emprestimo = _dbContext.emprestimos.SingleOrDefault(emp => emp.Id == id);

            if (emprestimo == null) return null;

            var (nomeUsuario, tituloLivro) = BuscarNomeUsuarioTituloLivro(emprestimo.IdUsuario, emprestimo.IdLivro);

            var emprestimoDetailsViewModel = new EmprestimoDetailsViewModel
            {
                IdEmprestimo = emprestimo.Id,
                IdUsuario = emprestimo.IdUsuario,
                NomeUsuario = nomeUsuario,
                IdLivro = emprestimo.IdLivro,
                TituloLivro = tituloLivro,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucao = emprestimo.DataDevolucao,
                Status = emprestimo.Status,
            };

            return emprestimoDetailsViewModel;
        }

        public void Terminado(int id)
        {
            var emprestimo = _dbContext.emprestimos.SingleOrDefault(emp => emp.Id == id);
            emprestimo.Terminado();
        }

        public void Update(UpdateEmprestimoInputModel inputModel)
        {
            var emprestimo = _dbContext.emprestimos.SingleOrDefault(emp => emp.Id == inputModel.Id);

            emprestimo.Update(inputModel.DataDevolucao);
        }
    }
}
