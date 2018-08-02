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
    public class SeedEnrollments
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Enrollment.Count() == 0)
                {
                    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                    var UAdmin = await userManager.FindByEmailAsync("admin@filmdesigners.at");
                    Enrollment GotthardHutter = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Gotthard").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Birgit Hutter").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment TrappFamilieHutter = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Die Trapp Familie - Ein Leben für die Musik").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Birgit Hutter").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment LiebeFurDenFriedenHutter = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Eine Liebe für den Frieden - Bertha v. Suttner und Alfred Nobel").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Birgit Hutter").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment TatortVirusJager = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Tatort - Virus").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jager").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment KastnerDienstagJager = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Kästner und der kleine Dienstag").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jager").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment TwilightBurmaJager = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Twilight over Burma").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jager").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SchnellErmittelt6064Loser = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Schnell Ermittelt 60-64").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Enid Löser").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SchnellErmittelt5559Loser = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Schnell Ermittelt 55-59").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Enid Löser").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment WirTotenStellaLoser = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Wir töten Stella").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Enid Löser").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment JosefAmBergFink = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "St. Josef am Berg").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Brigitta Fink").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment ErikWeltmeisterinFink = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Erik Weltmeisterin").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Brigitta Fink").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment DasSacherFink = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Das Sacher").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Brigitta Fink").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment TatortUndIrgendwannLudwig = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Tatort - Und irgendwann bleib i dann dort").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Christine Ludwig").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment VierFrauen6366Ludwig = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "4 Frauen und 1 Todesfall (Staffel 9 Folgen 63-66)").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Christine Ludwig").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment DerKardinalLudwig = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Der Kardinal").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Christine Ludwig").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Kostümbild").FirstOrDefault().JobId
                    };
                    Enrollment MedicopterS4Mikesch = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Medicopter 117 - Staffel 4").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jörg Mikesch").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment GeliebtePriesterMikesch = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Die Geliebte und der Priester - Padre papà").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jörg Mikesch").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment BalanceaktMikesch = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Balanceakt").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hans Jörg Mikesch").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment BalanceaktReichmann = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Balanceakt").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Florian Reichmann").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment TrappFamilieHutterReichmann = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Die Trapp Familie - Ein Leben für die Musik").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Florian Reichmann").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment LiebeFurDenFriedenReichmann = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Eine Liebe für den Frieden - Bertha v. Suttner und Alfred Nobel").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Florian Reichmann").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment KaviarSalat = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Kaviar").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hannes Salat").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment HohenstrasseSalat = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Höhenstrasse").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Hannes Salat").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment PoltAberPoltSteinbach = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Polt - \"Alt aber Polt\"").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Daniel Steinbach").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SOKOKitz208210Steinbach = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "SOKO-Kitzbühel / 208-210").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Daniel Steinbach").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SOKOKitz204207Steinbach = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "SOKO-Kitzbühel / 204-207").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Daniel Steinbach").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SOKODonau131013Vogel = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "SOKO Donau Staffel 13 Folgen 10 - 13").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Thomas Vögel").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SOKODonau130105Vogel = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "SOKO Donau Staffel 13 Folgen 01-05").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Thomas Vögel").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    Enrollment SOKODonau120508Vogel = new Enrollment()
                    {
                        ProjectID = context.Project.Where(p => p.Name == "Soko Donau - Staffel 12 / 05 - 08").FirstOrDefault().ProjectID,
                        MemberID = context.Member.Where(m => m.Name == "Thomas Vögel").FirstOrDefault().MemberId,
                        JobId = context.Job.Where(j => j.Name == "Szenenbild").FirstOrDefault().JobId
                    };
                    context.Add(GotthardHutter);
                    context.Add(TrappFamilieHutter);
                    context.Add(LiebeFurDenFriedenHutter);
                    context.Add(TatortVirusJager);
                    context.Add(KastnerDienstagJager);
                    context.Add(TwilightBurmaJager);
                    context.Add(SchnellErmittelt6064Loser);
                    context.Add(SchnellErmittelt5559Loser);
                    context.Add(WirTotenStellaLoser);
                    context.Add(JosefAmBergFink);
                    context.Add(ErikWeltmeisterinFink);
                    context.Add(DasSacherFink);
                    context.Add(TatortUndIrgendwannLudwig);
                    context.Add(VierFrauen6366Ludwig);
                    context.Add(DerKardinalLudwig);
                    context.Add(MedicopterS4Mikesch);
                    context.Add(GeliebtePriesterMikesch);
                    context.Add(BalanceaktMikesch);
                    context.Add(KaviarSalat);
                    context.Add(HohenstrasseSalat);
                    context.Add(PoltAberPoltSteinbach);
                    context.Add(SOKOKitz208210Steinbach);
                    context.Add(SOKOKitz204207Steinbach);
                    context.Add(SOKODonau131013Vogel);
                    context.Add(SOKODonau130105Vogel);
                    context.Add(SOKODonau120508Vogel);

                    await context.SaveChangesAsync();
                }

            }
        }
        #endregion
    }
}
#endif