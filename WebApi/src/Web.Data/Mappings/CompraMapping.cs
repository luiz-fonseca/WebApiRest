using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Models;

namespace Web.Data.Mappings
{
    public class CompraMapping : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).
                ValueGeneratedOnAdd();

            builder.Property(c => c.QtdComprada)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.DataCadastro)
                .HasColumnType("Datetime");

            // 1 : N => Produto : Compras
            builder.HasOne(p => p.Produto)
                .WithMany(c => c.Compras)
                .HasForeignKey(p => p.Id) ;

            builder.ToTable("Compra");
        }
    }
}
