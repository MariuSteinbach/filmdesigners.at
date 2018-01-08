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
    public class SeedJobs
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if(context.Job.Count() == 0)
                {
                    Job Szenenbild = new Job()
                    {
                        Name = "Szenenbild",
                        Description = "SzenenbildnerInnen sorgen für die visuelle Gesamtkonzeption, die künstlerisch- eigenschöpferische Gestaltung, sowie die technisch-organisatorische Planung und Realisation der szenischen Ausstattung von Filmwerken, nach Maßgabe des Drehbuchs und in Abstimmung mit ProduzentInnen und Regie. Ihre Ideen, Milieudefinitionen, Farbkonzepte, Entwürfe und Motiv-Vorschläge sind eine wesentliche Grundlage für alle anderen am Filmbild mitgestaltenden Berufsgruppen.",
                        isPartner = false
                    };
                    Job KostumBild = new Job()
                    {
                        Name = "Kostümbild",
                        Description = "KostümbildnerInnen sorgen für die künstlerisch-eigenverantwortliche Gestaltung und technisch-organisatorische Realisation der Kostüme für einen Film. Sie tun dies in Zusammenarbeit mit Regie, Szenenbild, Maskenbild und den DarstellerstellerInnen.",
                        isPartner = false
                    };
                    Job SzenenbildAssistenz = new Job()
                    {
                        Name = "Szenenbild Assistenz",
                        Description = "Sie steht den SzenenbildnerInnen in all ihren Tätigkeiten zur Seite, sei es Motivsuche, Recherche, Kalkulation von Teilaufgaben, Protokollierung von Besprechungen, Ausführung von Planzeichnungen, Leitung diverser Bauaufgaben, Anfertigung von Modellen oder Spezialrequisiten, Grafik, Kommunikator zwischen allen Art Department Mitgliedern, Besorgungen, ...",
                        isPartner = false
                    };
                    Job KostumbildAssistenz = new Job()
                    {
                        Name = "Kostümbild Assistenz",
                        Description = "Kostümbild AssistenInnen wirken - nach Anweisung der KostümbildnerInnen - ausführend, weiterführend, unterstützend und oft auch eigenverantwortlich mit an der Planung, Ausführung und Organisation der Kostüme.",
                        isPartner = false
                    };
                    Job Aussenrequisite = new Job()
                    {
                        Name = "Außenrequisite",
                        Description = "Die Aufgabe der Außenrequisite besteht in der Recherche und Beschaffung der zur szenischen Ausstattung eines Filmes benötigten Einzelteile. SzenenbilderInnen geben den Look der einzelnen Räume / Szenen vor, sowie Möblierungs- und Dekorations- vorschläge, die Außenrequisite organisiert die dafür notwendigen Gegenstände. Das für Requisiten auszugebende Budget wird gemeinsam erstellt und von der Außenrequisite ständig überwacht. Ihr allein obliegt die organisatorische Abwicklung der Requisiten- beschaffung.",
                        isPartner = false
                    };
                    Job Innenrequisite = new Job()
                    {
                        Name = "Innenrequisite",
                        Description = "Die Aufgabe des lnnenrequisiteurs ist die szenische Betreuung der einzelnen Dekorationen während des eigentlichen Drehvorgangs in Abstimmung mit der Regie, dem Szenenbild, der Außenrequisite und der Kamera, sowie allen damit verbundenen Vorbereitungsarbeiten.",
                        isPartner = false
                    };
                    Job Garderobe = new Job()
                    {
                        Name = "Garderobe",
                        Description = "GarderoberInnen sorgen für die die Betreuung und Instandhaltung der Kostüme während der Dreharbeiten eines Films: Im Auftrag des Kostümbilds und in Zusammen- arbeit mit den MaskenbildnerInnen kleiden sie die DarstellerInnen am Set.<br />Es obliegt ihnen die Verantwortung über die szenisch - chronologischen Reihenfolge der einzelnen Kostüme während der Dreharbeiten und alle damit verbundenen Details.",
                        isPartner = false
                    };
                    Job Anwarterinnen = new Job()
                    {
                        Name = "AnwärterInnen",
                        Description = "",
                        isPartner = false
                    };
                    Job Ehrenmitglieder = new Job()
                    {
                        Name = "Ehrenmitglieder",
                        Description = "",
                        isPartner = false
                    };
                    Job MitgliederImRuhestand = new Job()
                    {
                        Name = "Mitglieder im Ruhestand",
                        Description = "",
                        isPartner = false
                    };
                    Job Kulissenbauleitung = new Job()
                    {
                        Name = "Kulissenbauleitung",
                        Description = "",
                        isPartner = true
                    };
                    Job Baubuhne = new Job()
                    {
                        Name = "Baubühne",
                        Description = "",
                        isPartner = true
                    };
                    Job Buhnenmaler = new Job()
                    {
                        Name = "Bühnenmaler",
                        Description = "",
                        isPartner = true
                    };
                    Job Requisitenfahrer = new Job()
                    {
                        Name = "Requisiten - Fahrer",
                        Description = "",
                        isPartner = true
                    };
                    Job Locations = new Job()
                    {
                        Name = "Locations",
                        Description = "",
                        isPartner = true
                    };
                    Job SFX = new Job()
                    {
                        Name = "SFX",
                        Description = "",
                        isPartner = true
                    };
                    Job Standfotos = new Job()
                    {
                        Name = "Standfotos",
                        Description = "",
                        isPartner = true
                    };
                    Job Requisitenverleih = new Job()
                    {
                        Name = "Requisiten Verleih",
                        Description = "",
                        isPartner = true
                    };
                    Job Kostumeverleih = new Job()
                    {
                        Name = "Kostüme - Verleih",
                        Description = "",
                        isPartner = true
                    };
                    Job WeitereFirmen = new Job()
                    {
                        Name = "Weitere Firmen",
                        Description = "",
                        isPartner = true
                    };
                    Job VFX = new Job()
                    {
                        Name = "VFX",
                        Description = "",
                        isPartner = true
                    };
                    context.Add(Szenenbild);
                    context.Add(KostumBild);
                    context.Add(SzenenbildAssistenz);
                    context.Add(KostumbildAssistenz);
                    context.Add(Aussenrequisite);
                    context.Add(Innenrequisite);
                    context.Add(Garderobe);
                    context.Add(Anwarterinnen);
                    context.Add(Ehrenmitglieder);
                    context.Add(MitgliederImRuhestand);
                    context.Add(Kulissenbauleitung);
                    context.Add(Baubuhne);
                    context.Add(Buhnenmaler);
                    context.Add(Requisitenfahrer);
                    context.Add(Locations);
                    context.Add(SFX);
                    context.Add(Standfotos);
                    context.Add(Requisitenverleih);
                    context.Add(Kostumeverleih);
                    context.Add(WeitereFirmen);
                    context.Add(VFX);

                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
#endif