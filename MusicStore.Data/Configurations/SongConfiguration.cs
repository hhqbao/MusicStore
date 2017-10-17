using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Models.Entities;

namespace MusicStore.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs");

            builder.HasKey(song => song.Id);

            builder.Property(song => song.Id)
                .ValueGeneratedOnAdd();

            builder.Property(song => song.Title)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(song => song.FileUrl)
                .IsRequired();

            builder.HasOne(song => song.Category)
                .WithMany(category => category.Songs)
                .HasForeignKey(song => song.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(song => song.Author)
                .WithMany(author => author.Songs)
                .HasForeignKey(song => song.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(song => song.ApplicationUser)
                .WithMany(user => user.Songs)
                .HasForeignKey(song => song.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}