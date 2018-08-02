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
    public class SeedProjects
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Project.Count() == 0)
                {
                    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                    var UAdmin = await userManager.FindByEmailAsync("admin@filmdesigners.at");
                    Project Gotthard = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Gotthard",
                        Type = ProjectType.TV,
                        Date = new DateTime(2015, 1, 1),
                        Countries = "DE/CH",
                        Regiesseur = "Urs Egger",
                        Production = "Zodiac Pictures Ltd",
                        Link = ""
                    };
                    Project TrappFamilie = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Die Trapp Familie - Ein Leben für die Musik",
                        Type = ProjectType.Kino,
                        Date = new DateTime(2015, 1, 1),
                        Countries = "DE/AT",
                        Regiesseur = "Ben Verbong",
                        Production = "Clasart Film- und Fernsehproduktions GmbH, Concorde Media",
                        Link = "http://www.the-trapp-family.com/"
                    };
                    Project LiebeFurDenFrieden = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Eine Liebe für den Frieden - Bertha v. Suttner und Alfred Nobel",
                        Type = ProjectType.TV,
                        Date = new DateTime(2014, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Urs Egger",
                        Production = "Mona Film",
                        Link = ""
                    };
                    Project TatortVirus = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Tatort - Virus",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Barbara Eder",
                        Production = "Epo Film",
                        Link = ""
                    };
                    Project KastnerDienstag = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Kästner und der kleine Dienstag",
                        Type = ProjectType.TV,
                        Date = new DateTime(2015, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Wolfgang Murnberger",
                        Production = "Dor-Film",
                        Link = ""
                    };
                    Project TwilightBurma = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Twilight over Burma",
                        Type = ProjectType.TV,
                        Date = new DateTime(2014, 1, 1),
                        Countries = "AT/TH",
                        Regiesseur = "Sabine Derflinger",
                        Production = "Dor Film Produktion GmbH",
                        Link = ""
                    };
                    Project SchnellErmittelt6064 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Schnell Ermittelt 60-64",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Gerald Liegel",
                        Production = "MR-Film",
                        Link = "http://www.imdb.com/title/tt1153095/?ref_=fn_al_tt_1"
                    };
                    Project SchnellErmittelt5559 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Schnell Ermittelt 55-59",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Michael Riebl",
                        Production = "MR-Film",
                        Link = "http://www.imdb.com/title/tt1153095/?ref_=fn_al_tt_1"
                    };
                    Project WirTotenStella = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Wir töten Stella",
                        Type = ProjectType.Kino,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Julian Pölsler",
                        Production = "epo-film/Juwel Film",
                        Link = ""
                    };
                    Project JosefAmBerg = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "St. Josef am Berg",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT/DE",
                        Regiesseur = "Lars Montag",
                        Production = "Mona Film",
                        Link = ""
                    };
                    Project ErikWeltmeisterin = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Erik Weltmeisterin",
                        Type = ProjectType.Kino,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Reinhold Bilgeri",
                        Production = "Lotus Film",
                        Link = ""
                    };
                    Project DasSacher = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Das Sacher",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Robert Dornhelm",
                        Production = "MR Film",
                        Link = ""
                    };
                    Project TatortUndIrgendwann = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Tatort - Und irgendwann bleib i dann dort",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Barbara Eder",
                        Production = "DOR-Film",
                        Link = ""
                    };
                    Project VierFrauen6366 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "4 Frauen und 1 Todesfall (Staffel 9 Folgen 63-66)",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Andreas Kopriva",
                        Production = "Dor Film GmbH",
                        Link = ""
                    };
                    Project DerKardinal = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Der Kardinal",
                        Type = ProjectType.TV,
                        Date = new DateTime(2010, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Andreas Gruber",
                        Production = "tellux Film",
                        Link = ""
                    };
                    Project MedicopterS4 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Medicopter 117 - Staffel 4",
                        Type = ProjectType.TV,
                        Date = new DateTime(2000, 1, 1),
                        Countries = "AT/DE",
                        Regiesseur = "W. Dickmann",
                        Production = "MR-Film",
                        Link = ""
                    };
                    Project GeliebtePriester = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Die Geliebte und der Priester - Padre papà",
                        Type = ProjectType.TV,
                        Date = new DateTime(1995, 1, 1),
                        Countries = "DE/IT",
                        Regiesseur = "Sergio Martino",
                        Production = "Titanus Film, Rom",
                        Link = "http://us.imdb.com/title/tt0162513/combined"
                    };Project Balanceakt = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Balanceakt",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT/DE",
                        Regiesseur = "Vivian Naefe",
                        Production = "Mona Film",
                        Link = ""
                    };
                    Project Kaviar = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Kaviar",
                        Type = ProjectType.Kino,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Elena Tikhonova",
                        Production = "Witcraft Szenario",
                        Link = ""
                    };
                    Project Hohenstrasse = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Höhenstrasse",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "David Schalko",
                        Production = "Superfilm",
                        Link = ""
                    };
                    Project PoltAberPolt = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Polt - \"Alt aber Polt\"",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Julian Pölsler",
                        Production = "Epo-Film",
                        Link = ""
                    };
                    Project SOKOKitz208210 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "SOKO-Kitzbühel / 208-210",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Martin Kinkel",
                        Production = "beo-film",
                        Link = "http://www.imdb.com/title/tt0295620/"
                    };
                    Project SOKOKitz204207 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "SOKO-Kitzbühel / 204-207",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Gerald Liegel",
                        Production = "beo-film",
                        Link = "http://www.imdb.com/title/tt0295620/"
                    };
                    Project SOKODonau131013 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "SOKO Donau Staffel 13 Folgen 10 - 13",
                        Type = ProjectType.TV,
                        Date = new DateTime(2015, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Filippos Tsitos",
                        Production = "SATEL",
                        Link = ""
                    };
                    Project SOKODonau130105 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "SOKO Donau Staffel 13 Folgen 01-05",
                        Type = ProjectType.TV,
                        Date = new DateTime(2017, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Holger Barthel",
                        Production = "SATEL",
                        Link = ""
                    };
                    Project SOKODonau120508 = new Project()
                    {
                        OwnerID = UAdmin.Id,
                        Name = "Soko Donau - Staffel 12 / 05 - 08",
                        Type = ProjectType.TV,
                        Date = new DateTime(2016, 1, 1),
                        Countries = "AT",
                        Regiesseur = "Holger Gimpel",
                        Production = "Satel Film GmbHm",
                        Link = ""
                    };


                    context.Add(Gotthard);
                    context.Add(TrappFamilie);
                    context.Add(LiebeFurDenFrieden);
                    context.Add(TatortVirus);
                    context.Add(KastnerDienstag);
                    context.Add(TwilightBurma);
                    context.Add(SchnellErmittelt6064);
                    context.Add(SchnellErmittelt5559);
                    context.Add(WirTotenStella);
                    context.Add(JosefAmBerg);
                    context.Add(ErikWeltmeisterin);
                    context.Add(DasSacher);
                    context.Add(TatortUndIrgendwann);
                    context.Add(VierFrauen6366);
                    context.Add(DerKardinal);
                    context.Add(MedicopterS4);
                    context.Add(GeliebtePriester);
                    context.Add(Balanceakt);
                    context.Add(Kaviar);
                    context.Add(Hohenstrasse);
                    context.Add(PoltAberPolt);
                    context.Add(SOKOKitz208210);
                    context.Add(SOKOKitz204207);
                    context.Add(SOKODonau131013);
                    context.Add(SOKODonau130105);
                    context.Add(SOKODonau120508);

                    await context.SaveChangesAsync();
                }
                await SeedChapters.Initialize(serviceProvider);
            }
        }
        #endregion
    }
}
#endif