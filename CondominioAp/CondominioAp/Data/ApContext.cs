
using CondominioAp.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioAp.Data

{
    public class ApContext :DbContext
    {
      
    // Classe que estabelece conexão com o banco de dados
    
        
            public ApContext(DbContextOptions<ApContext> opt) : base(opt)
            {

            }
            public DbSet<Inquilinos> Inquilinos { get; set; }
            public DbSet<Despesas> Despesas { get; set; }
            public DbSet<Unidades> Unidades { get; set; }
        
    }

}
