



using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projet_API.Data;
using System;
using System.Linq;
namespace Projet_API.Models;
public static class SeedData3 // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Projet_APIContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<Projet_APIContext>>()))
        {
            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
            if (context.ChiffresVentes.Any())
            {
                return; // On ne fait rien
            }
            // Sinon on en ajoute un
            context.ChiffresVentes.AddRange(
            new ChiffresVentes
            {
                Annee = "2020",
                id_console = 1,
                NombreVentes= 1000
            }
            );
            context.SaveChanges();
        }
    }
}