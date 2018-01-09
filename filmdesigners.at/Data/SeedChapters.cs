#define SeedOnly
#if SeedOnly

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using filmdesigners.at.Authorization;
namespace filmdesigners.at.Data
{
    public class SeedChapters
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Chapter.Count() == 0)
                {
                    Chapter EUFilmpreis2017 = new Chapter()
                    {
                        Heading = "Europäischer Filmpreis 2017",
                        Text = "Am 9. Dezember vergab die Europäische Filmakademie zum 30. Mal ihre Preise, darunter:EUROPEAN PRODUCTION DESIGNER 2017 Josefin Åsberg für THE SQUAREEUROPEAN COSTUME DESIGNER 2017 Katarzyna Lewińska für SPOOREuropean Film Academy",
                        Page = "HomeIndex",
                        Created = new DateTime(),
                        Edited = new DateTime()
                    };
                    Chapter VOFPunsch2017 = new Chapter()
                    {
                        Heading = "VÖF-PUNSCH 2017",
                        Text = "Wie in den vergangenen Jahren lud der VÖF zum Punsch im Hof des Silberwirt, diesmal am 4. Dezember.Zahlreiche Mitglieder und Gäste erfreuten sich in vorweihnachtlicher Stimmung, an Atmosphäre, Speis & Trank\nGalerie",
                        Page = "HomeIndex",
                        Created = new DateTime(),
                        Edited = new DateTime()
                    };
                    Chapter EFPC = new Chapter()
                    {
                        Heading = "EUROPEAN FEDERATION for PRODUCTION & COSTUME DESIGN",
                        Text = "Das Treffen in Rom war sehr spannend und voller lebhafter Diskussionen, trotz der schwierigen und etwas trockenen Aufgabe die uns bevorstand: Es galt die wesentlichen Grundlagen für unseren Europaverband festzulegen (Name, Ort, Statuten, Vorhaben, ..). Dante Ferretti und der ehemalige italienische Kulturminister und derzeitige Präsident von ANICA,Francesco Rutelli,hielten eine kurze Rede um uns in unserem Anliegen aufs herzlichste zu unterstützen und einen guten weiteren Weg zu wünschen.",
                        Page = "HomeIndex",
                        Created = new DateTime(),
                        Edited = new DateTime()
                    };
                    Chapter VOF30 = new Chapter()
                    {
                        Heading = "30 Jahre VÖF",
                        Text = "Unser Verband wurde vor 30 Jahren gegründet und dieses Jubiläum wurde im Herbst 2017 gebührend gefeiert!Einerseits mit einem Fest am 30.September,aber auch mit Veranstaltungen,die unsere Tätigkeiten bei der Filmherstellung behandeln.Im Zeitraum 29.September bis 8.Oktober wurden Werkstattgespräche mit internationalen Szenen - und KostümbildnerInnen,eine Podiumsdiskussion zum Thema \"Ausbildung\" und eine Filmreihe im Metro - Kino veranstaltet.Weiters gab es Workshops sowie Atelier - und Fundusrundgänge in Kooperation mit der Vienna Design Week.",
                        Page = "HomeIndex",
                        Created = new DateTime(),
                        Edited = new DateTime()
                    };

                    context.Add(EUFilmpreis2017);
                    context.Add(VOFPunsch2017);
                    context.Add(EFPC);
                    context.Add(VOF30);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
#endif