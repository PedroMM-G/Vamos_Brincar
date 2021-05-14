namespace Vamos_Brincar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public class CadastroEntities : DbContext
    {
        public CadastroEntities()
    : base("name=CadastroEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Criancamod> crianca { get; set; }
    }
}
