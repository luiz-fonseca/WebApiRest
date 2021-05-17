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
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Id).
                ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.QtdEstoque)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.ValorUnitario)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(c => c.DataCadastro)
               .HasColumnType("Datetime");

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(p => p.Compras)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);


            builder.ToTable("Produto");
        }
    }
}
