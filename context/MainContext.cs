using Microsoft.EntityFrameworkCore;
using taxex_api.model;

namespace taxex_api.context;

public class MainContext : DbContext {
    protected MainContext(){
    }

    public MainContext(DbContextOptions options) : base(options) {
    }

    public DbSet<Country> m_country { get; set; }
    public DbSet<Harbour> m_harbour { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Country>().HasData(
            new Country()
            {
                id = 1,
                kd_country = "ID",
                name = "Indonesia"
            }, new Country()
            {
                id = 2,
                kd_country = "SG",
                name = "Singapore"
            }, new Country()
            {
                id = 3,
                kd_country = "IR",
                name = "Iraq"
            }, new Country()
            {
                id = 4,
                kd_country = "MY",
                name = "Malaysia"
            }, new Country()
            {
                id = 5,
                kd_country = "PH",
                name = "Philippines"
            }
        );

        modelBuilder.Entity<Harbour>().HasData(
            new Harbour()
            {
                id = 111,
                id_country = 2,
                name = "Jurong",
            },
            new Harbour()
            {
                id = 112,
                id_country = 2,
                name = "Marina",
            },
            new Harbour()
            {
                id = 113,
                id_country = 2,
                name = "Keppel",
            },
            new Harbour()
            {
                id = 114,
                id_country = 1,
                name = "Merak",
            },
            new Harbour()
            {
                id = 115,
                id_country = 1,
                name = "Batam",
            },
            new Harbour()
            {
                id = 116,
                id_country = 3,
                name = "Klang",
            },
            new Harbour()
            {
                id = 117,
                id_country = 4,
                name = "Flous",
            },
            new Harbour()
            {
                id = 118,
                id_country = 5,
                name = "Rafles",
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}



    
