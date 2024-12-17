using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.api.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnType("SMALLINT");

            builder.Property(c => c.Amount)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.CreateAt)
                .IsRequired();

            builder.Property(c => c.PaidOrReceivedAt)
                .IsRequired();

        }
    }
}
