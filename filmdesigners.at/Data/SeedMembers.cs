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
    public class SeedMembers
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Member.Count() == 0)
                {
                    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                    var UBirgitHutter = await userManager.FindByEmailAsync("hutterbirgit@gmail.com");
                    var UHansJager = await userManager.FindByEmailAsync("jager@a1.net");
                    var UEnidLoser = await userManager.FindByEmailAsync("enid@chello.at");
                    var UBrigittaFink = await userManager.FindByEmailAsync("brigittafink@gmx.at");
                    var UChristineLudwig = await userManager.FindByEmailAsync("c.ludwig.cl@gmail.com");
                    var UHansJorgMikesch = await userManager.FindByEmailAsync("office@szenenbild.at");
                    var UFlorianReichmann = await userManager.FindByEmailAsync("mail@f-reichmann.at");
                    var UHannesSalat = await userManager.FindByEmailAsync("salatbox@mac.com");
                    var UDanielSteinbach = await userManager.FindByEmailAsync("danielsteinbach@gmx.net");
                    var UThomasVogel = await userManager.FindByEmailAsync("th.voegel@gmail.com");
                    var Kostumbild = context.Job.AsNoTracking().SingleOrDefaultAsync(j => j.Name == "Kostümbild");
                    var Szenenbild = context.Job.AsNoTracking().SingleOrDefaultAsync(j => j.Name == "Szenenbild");
                    Member BirgitHutter = new Member()
                    {
                        OwnerID = UBirgitHutter.Id,
                        JobId = Kostumbild.Result.JobId,
                        Name = "Birgit Hutter",
                        Male = false,
                        Street = "Dominikanerbastei 6/15",
                        ZIP = 1010,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "+43 1 512 30 22",
                        Mobile = "",
                        Phone = "+43 1 512 97 12",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "03cbce84-5084-436a-a35e-3cef1f1865b6.png",
                        Languages = "Englisch, Französisch, Italienisch",
                        InternationalExperiences = "Italien, Deutschland, USA",
                        Education = "Matura am Human. Gymnasium; Studium Malerei an Hochschule F. Angew. Kunst Wien; Art Students League, New York City, Diplom in der Klasse für Bühnenbild u. Kostüm Akademie der Bildenden Künste, Wien; Studium der Theaterwissenschaften, Universität Wien",
                        Activities = "Assistentin von Vivienne Westwood und Marc Bohan, Hochschule für Angew. Kunst, Wien; Lehrauftrag Prof. Paolo Piva, Hochschule für Angew. Kunst, Wien",
                        Galleries = "",
                        Awards =    "1988 bundes filmpreis für die kostüme von WEITES LAND regie .luc bondy\n" +
                                    "1994 goldener kader für die kostüme von SALZBARON regie : bernd fischerauer\n" +
                                    "2008 nominierung für den deutschen fernsehpreis für \"JÜNGSTES GERICHT\"\n" +
                                    "regie: urs egger\n" +
                                    "2013 nominierung für den österreichischen filmpreis 2013 für die kostüme von\n" +
                                    "TABU regie:christoph stark\n" +
                                    "2015 nominierung für den österreichischen filmpreis 2015 für die kostüme von DER TEUFELSGEIGER regie: bernhard rose\n" +
                                    "2015 nominierung für american costumedesigners guild for outstanding costumes for HOUDINI regie : uli edel",
                        Notes = "",
                        EMail = "hutterbirgit@gmail.com",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member HansJager = new Member()
                    {
                        OwnerID = UHansJager.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Hans Jager",
                        Male = true,
                        Street = "Wiener Straße 44",
                        ZIP = 3004,
                        City = "Riederberg",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 664 325 26 92",
                        Phone = "43 2271 8509",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "65953760-0a30-4175-9aaf-5394d2431f1d.png",
                        Languages = "Englisch",
                        InternationalExperiences = "",
                        Education = "",
                        Activities = "Bühnenrealisationen: Ensembletheater, Dario-Fo-Theater, Wiener Ensemble, Realisationen von Kunstobjekten u. Installationen: Bernd Fasching, Heimo Zobernig, Franz West, Werkstätte für Design und Herstellung von Möbel u. Inneneinrichtungen, Gestaltung von gewerblichen Betriebseinrichtungen: Div. Boutiquen u. Büros, Café Bar-Gasthaus \"Lux\", Tonstudio Gigele, Kino-Trabrennbahn Krieau",
                        Galleries = "",
                        Awards = "",
                        Notes = "",
                        EMail = "jager@a1.net",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member EnidLoser = new Member()
                    {
                        OwnerID = UEnidLoser.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Enid Löser",
                        Male = false,
                        Street = "Bischof Faber Platz 8/13",
                        ZIP = 1180,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 676 311 45 09",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "05971bd9-8846-4688-b396-e75593516d0c.png",
                        Languages = "englisch, französisch",
                        InternationalExperiences = "",
                        Education = "Bühnenbild Masterstudium an der TU Berlin, Master of Arts\n" +
                                    "Kolleg für Möbel - und Innenausbau, Diplom",
                        Activities = "",
                        Galleries = "",
                        Awards = "",
                        Notes = "",
                        EMail = "enid@chello.at",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member BrigittaFink = new Member()
                    {
                        OwnerID = UBrigittaFink.Id,
                        JobId = Kostumbild.Result.JobId,
                        Name = "Brigitta Fink",
                        Male = false,
                        Street = "Leopoldsgasse 22/12a",
                        ZIP = 1020,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 676 545 37 38",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "a99a3a45-029c-4541-87db-d536fe72d551.png",
                        Languages = "Englisch , Italienisch",
                        InternationalExperiences = "Italien , Schweden , Deutschland , Schweiz , Afrika , Dom.Rep. , China,GB,Ungarn",
                        Education = "Höhere Bundes -Lehr und Versuchsanstalt für Textilindustrie Dornbirn",
                        Activities = "Kostümassistenz , Kostümsupervisor, Kostümbild für Kino , Tv , Theater ,Werbung",
                        Galleries = "",
                        Awards = "",
                        Notes = "",
                        EMail = "brigittafink@gmx.at",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member ChristineLudwig = new Member()
                    {
                        OwnerID = UChristineLudwig.Id,
                        JobId = Kostumbild.Result.JobId,
                        Name = "Christine Ludwig",
                        Male = false,
                        Street = "Diepoldplatz 5/6",
                        ZIP = 1170,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 699 126 691 82",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "",
                        Languages = "englisch",
                        InternationalExperiences = "Jordanien, Italien, Spanien, Deutschland, Frankreich, Mauritius, Polen",
                        Education = "HBLA f. Mode Herbststraße, 1992-94 Studium Theaterwissenschaft und Kunstgeschichte, 1994-95 Speziallehrgang für Bühnenkostüme Herbststraße",
                        Activities = "Kostümbild, Kostümassistenz, Garderobe",
                        Galleries = "",
                        Awards = "",
                        Notes = "Eigener Kostümfundus - KostümRaum - Rötzergasse 18, 1170 Wien",
                        EMail = "c.ludwig.cl@gmail.com",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member HansJorgMikesch = new Member()
                    {
                        OwnerID = UHansJorgMikesch.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Hans Jörg Mikesch",
                        Male = true,
                        Street = "Westbahnstraße 33",
                        ZIP = 1070,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "www.szenenbild.at",
                        Fax = "",
                        Mobile = "+43 664 333 85 36",
                        Phone = "+43 1 522 18 39",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "6646be69-7afe-4391-9670-6f0d0b1ee241.png",
                        Languages = "englisch, italienisch, französisch",
                        InternationalExperiences = "Italien, Deutschland, Schweiz, Niederlande",
                        Education = "Visuelle Gestaltung bei Laurids Ortner ( Meisterklasse), Universität für Gestaltung Linz,\n" + 
                                    "European Summer Academy Berlin,\n" +
                                    "Filmarchitektur",
                        Activities = "",
                        Galleries = "",
                        Awards = "",
                        Notes = "",
                        EMail = "office@szenenbild.at",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member FlorianReichmann = new Member()
                    {
                        OwnerID = UFlorianReichmann.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Florian Reichmann",
                        Male = true,
                        Street = "Sigmundsgasse 2",
                        ZIP = 1070,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 664 315 57 88",
                        Phone = "+43 1 526 80 00",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "20032f3a-b676-48f9-8a84-368e6137a13e.png",
                        Languages = "Englisch",
                        InternationalExperiences = "Deuschland, Spanien, Ungarn",
                        Education = "Architekturstudium Technische Universität Wien",
                        Activities = "Filmausstattungen, Bauten, Einrichtungen, Bühnenbild, Design, Werbung etc.",
                        Galleries = "",
                        Awards = "",
                        Notes = "Nominiert für den deutschen Fernsehpreis 2008 in der Kategorie \"Beste Ausstattung - Szenenbild\" für \"Das jüngste Gericht\"\n" +
                                "Nominiert für den Goldenen Kader 1994 in der Kategorie \"Beste Ausstattung\" für \"Die Flucht\"",
                        EMail = "mail@f-reichmann.at",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member HannesSalat = new Member()
                    {
                        OwnerID = UHannesSalat.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Hannes Salat",
                        Male = true,
                        Street = "",
                        ZIP = 1090,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 664 132 41 81",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "dae3ec7b-5b94-48f2-a6fb-1ff980d51a25.png",
                        Languages = "Englisch",
                        InternationalExperiences = "Ukraine, Paris",
                        Education = "Architekturstudium Technische Universität Wien",
                        Activities =    "Szenenbild, Bühnenbild, Design, Messegestaltung, Außenrequisite, Szenenbildassistenz, Locationscout.\n" + 
                                        "seit März 2014 Lehrauftrag für Szenenbild an der Filmakademie Wien\n" +
                                        "seit Oktober 2016 Lehrauftrag für Szenenbild an der Klasse für Bühnen und Filmgestaltung - Akademie für angewandte Kunst Wien.",
                        Galleries = "",
                        Awards = "",
                        Notes = "Österreichischer Filmpreis 2016 für \"Ich seh Ich seh\" mit Hubert Klausner\n" +
                                "Österreichischer Filmpreis 2017 für \"Stille Reserven\"\n" +
                                "Szenenbild für diverse Werbungen: ONE, Iglo, WKO, Billa, Persil, Raiffeisen, Bausparkasse, Mc Donalds, Maggi, A1, Energie AG, FGÖ, Bundesministerium f. WFJ, Intersport, Cosmos, ÖBB, Dorotheum, Lutz, Mömax, Tirolmilch, Licht ins Dunkel",
                        EMail = "salatbox@mac.com",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member DanielSteinbach = new Member()
                    {
                        OwnerID = UDanielSteinbach.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Daniel Steinbach",
                        Male = true,
                        Street = "Hauptstrasse 156",
                        ZIP = 2391,
                        City = "Kaltenleutgeben",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 664 421 70 82",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "67e224a6-cc62-4142-9298-81702f0cfc2a.png",
                        Languages = "",
                        InternationalExperiences = "",
                        Education = "",
                        Activities = "",
                        Galleries = "",
                        Awards = "",
                        Notes = "",
                        EMail = "danielsteinbach@gmx.net",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };
                    Member ThomasVogel = new Member()
                    {
                        OwnerID = UThomasVogel.Id,
                        JobId = Szenenbild.Result.JobId,
                        Name = "Thomas Vogel",
                        Male = true,
                        Street = "Fassziehergasse 5",
                        ZIP = 1070,
                        City = "Wien",
                        Country = "Österreich",
                        Website = "",
                        Fax = "",
                        Mobile = "+43 664 300 63 59",
                        Phone = "",
                        OtherContact = "",
                        Birthday = new DateTime(),
                        Deathday = new DateTime(),
                        Picture = "943a9e1b-ec7f-4776-b24b-5ceaf8074a75.png",
                        Languages = "englisch",
                        InternationalExperiences = "Deutschland, Italien, Tschechien, Russland, Malta, Israel, Irland, Spanien, Frankreich, Schweiz, Ungarn",
                        Education = "Bildhauerei, Grafik, Fotolehre",
                        Activities = "Bühnenbau, Innen- und Außenrequisite, Spezialeffekte, seit mehreren Jahren ausschließlich Ausstattung für Kino, TV, Werbung, Musikvideos, Bühnenbilder für EAV und Wolfgang Ambros",
                        Galleries = "",
                        Awards = "",
                        Notes = "Projekte im ländlich alpinen Raum",
                        EMail = "th.voegel@gmail.com",
                        Active = true,
                        Locked = false,
                        Resigned = false,
                        Paused = false,
                        LastUpdate = DateTime.Now,
                        Status = MemberStatus.Approved
                    };



                    context.Add(BirgitHutter);
                    context.Add(HansJager);
                    context.Add(EnidLoser);
                    context.Add(BrigittaFink);
                    context.Add(ChristineLudwig);
                    context.Add(HansJorgMikesch);
                    context.Add(FlorianReichmann);
                    context.Add(HannesSalat);
                    context.Add(DanielSteinbach);
                    context.Add(ThomasVogel);

                    await context.SaveChangesAsync();

                }
                await SeedProjects.Initialize(serviceProvider);
            }
        }
    }
}
#endif