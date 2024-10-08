﻿using BlazorCrud.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Colocamos cada uno de los modelos

        public DbSet<Libro> libro { get; set; }
    }
}
