using FuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosAPI.DataContext
{
    public class ApplicationDbContext : DbContext /*Herança, estou herdando do DbContext*/
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        /*Criando um contruto DbContextOptions<ApplicationDbContext> de options,
         * usado para fazer conexão com o banco*/
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; } /*A model que quero criar dentro do banco*/
    }
}
