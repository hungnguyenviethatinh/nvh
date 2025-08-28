using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.PostgresSQL.Entity
{
    internal class Record
    {
        public required string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedDateTz { get; set; }
    }

    internal class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable("record");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CreatedDate).HasColumnName("created_date").HasColumnType("timestamp");
            builder.Property(p => p.CreatedDateTz).HasColumnName("created_date_tz");//.HasColumnType("timestamptz");
        }
    }
}
