using Microsoft.EntityFrameworkCore;
using ProjectDiaries.Shared;
using System.Collections.Generic;

namespace ProjectDiaries.Server.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Diary> Diaries { get; set; }
}
