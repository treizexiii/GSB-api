using System;
using GSB.api.Areas.Identity.Data;
using GSB.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GSB.api.Data
{
    public class GsbContext : IdentityDbContext<GSBapiUser>
    {
        public GsbContext(DbContextOptions<GsbContext> options) : base(options)
        {
        }

        public DbSet<Visiteur> Visiteurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Etat> Etats { get; set; }
        public DbSet<Forfait> Forfaits { get; set; }
        public DbSet<FicheFrais> FichesFrais { get; set; }
        public DbSet<LigneFrais> LignesFrais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //You need to call the base model creating for Identity or have to build your own
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FicheFrais>()
                .HasKey(p => new {p.VisiteurId, p.Mois});
            
            modelBuilder.Entity<Forfait>().HasData(
                new Forfait {
                    Id = "ETP",
                    Libelle = "Forfait Etape",
                    Montant = 110.00m
                },
                new Forfait {
                    Id = "KM",
                    Libelle = "Forfait Kilometrique",
                    Montant = 0.62m
                },
                new Forfait {
                    Id = "NUI",
                    Libelle = "Forfait Hotel",
                    Montant = 80.00m
                },
                new Forfait {
                    Id = "REP",
                    Libelle = "Forfait Restaurant",
                    Montant = 25.00m
                }
            );

            modelBuilder.Entity<Etat>().HasData(
                new Etat {
                    Id = "CL",
                    Libelle = "Sasie Cloturée",
                },
                new Etat {
                    Id = "CR",
                    Libelle = "Fiche crée, saisie en cours",
                },
                new Etat {
                    Id = "RB",
                    Libelle = "Remboursée",
                },
                new Etat {
                    Id = "VA",
                    Libelle = "Valdidée et mise en paiement",
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role {
                    Id = 1,
                    Libelle = "Comptable"
                },
                new Role {
                    Id = 2,
                    Libelle = "Commercial"
                }
            );

            modelBuilder.Entity<Visiteur>().HasData(
                new Visiteur {
                    Id = 1,
                    Prenom = "Jonathan",
                    Nom = "Rougier",
                    Adresse = "6 rue de Viroflay",
                    CodePostal = 75015,
                    Ville = "Paris",
                    DateEmbauche = new DateTime(2020, 01, 01),
                    RoleId = 2,
                    Email = "jonathan.rougier@hotmail.fr",
                }
            );

            // modelBuilder.Entity<GSBapiUser>().HasData(
            //     new GSBapiUser
            //     {
            //         VisiteurId = 1,
            //         UserName = "rougierjo",
            //     }
            // );
        }
    }
}
