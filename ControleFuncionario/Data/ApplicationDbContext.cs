using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ControleFuncionario.Models;

namespace ControleFuncionario.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ControleFuncionario.Models.Funcionario> Funcionario { get; set; }
        public DbSet<ControleFuncionario.Models.Lotacao> Lotacao { get; set; }
        public DbSet<ControleFuncionario.Models.Cargo> Cargo { get; set; }
        public DbSet<ControleFuncionario.Models.ValeRefeicao> ValeRefeicao { get; set; }
        public DbSet<ControleFuncionario.Models.Empresa> Empresa { get; set; }
        public DbSet<ControleFuncionario.Models.Frequencia> Frequencia { get; set; }
        public DbSet<ControleFuncionario.Models.Situacao> Situacao { get; set; }
        public DbSet<ControleFuncionario.Models.ValeTransporte> ValeTransporte { get; set; }
    }
}