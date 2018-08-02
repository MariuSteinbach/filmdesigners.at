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
    public class SeedEvents
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if(context.Event.Count() == 0)
                {
                    Event WorkshopREALANDDDIGITAL = new Event()
                    {
                        Title = "Werkstattgespräch REAL & DIGITAL",
                        Picture = "786527a6-4c5f-4c5d-8630-c73052ad6f56.png",
                        Teaser = "Scanline VFX Gmbh aus München präsentierte aktuelle Entwicklungen auf dem Gebiet CGI und VFX",
                        Text = "Zwei Veranstaltungen am 28. und 29. März 2014 waren dem Thema CGI (Computer Generated Imagery) und VFX (visuelle Effekte) gewidmet, die Firma Scanline VFX Gmbh aus München präsentierte Beispiele und beantwortete Fragen unserer KollegInnen.<br style=\"\">Moderation Florian Reichmann.&nbsp;",
                        Date = new DateTime(2014, 3, 28),
                        Created = DateTime.Now
                    };
                    Event WorkshopKramerOlah = new Event()
                    {
                        Title = "Werkstattgespräch Kramer, Oláh",
                        Picture = "32aea1cc-a366-4577-b58b-050c310c4ce2.png",
                        Teaser = "Udo Kramer und Thomas Oláh",
                        Text = "Udo Kramer, Szenenbildner, und Thomas Oláh, Kostümbildner, berichteten über ihre Arbeit und vor allem über die gemeinsam realisierten Projekte \"Die Vermesung der Welt\" 2012 und \"Der Medicus\" 2013.&nbsp;",
                        Date = new DateTime(2014, 12, 3),
                        Created = DateTime.Now
                    };
                    Event WorkshopPatinier = new Event()
                    {
                        Title = "VÖF Patinier-Workshop",
                        Picture = "423467d6-19f0-48bb-bf7e-74d8c9a72287.png",
                        Teaser = "Workshop 27.2.-1.3.2015",
                        Text = "Der VÖF veranstaltete für Requisiteure und Szenenbildner einen workshop für die filmgerechte Behandlung von Holz, Metall, Papier etc.<br style=\"\">Fotos: Susanna Schaden&nbsp;",
                        Date = new DateTime(2015, 02, 27),
                        Created = DateTime.Now
                    };
                    Event Graz = new Event()
                    {
                        Title = "Veranstaltung in Graz am 19. November 2014",
                        Picture = "821eab14-b6cd-4177-b52b-075b5f89a753.png",
                        Teaser = "Haus der Architektur Graz",
                        Text = "Im Rahmen dieser Veranstaltung gaben Szenenbildner/innen Einblick in den Arbeitsprozess und die kreative Gestaltung von Wohnwelten im österreichischen Film.<br style=\"\">Haus der Architektur Graz, in Kooperation mit VÖF und Diagonale - Festival des Österreichischen Films<br style=\"\"><a href=\"http://www.hda-graz.at/event.php?item=8921\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Haus der Architektur Graz</a>&nbsp;",
                        Date = new DateTime(2014, 11, 19),
                        Created = DateTime.Now
                    };
                    Event WorkshopHutter = new Event()
                    {
                        Title = "Werkstattgespräch Birgit Hutter",
                        Picture = "0ca6fe7c-b731-422e-ab18-897c19bc6b30.png",
                        Teaser = "Werkstattgespräch 16. März 2015",
                        Text = "Kostümbildnerin Birgit Hutter berichtete am 16. März im grossen Sall des Metro-Kinos über ihre Arbeit. Moderation Mercedes Echerer&nbsp;",
                        Date = new DateTime(2015, 03, 16),
                        Created = DateTime.Now
                    };
                    Event Punsch2015 = new Event()
                    {
                        Title = "VÖF + AAC Punsch 2015",
                        Picture = "",
                        Teaser = "am 14.12.2015 im Silberwirt",
                        Text = "Diesmal feierten wir gemeinsam mit den Kameraleuten !&nbsp;",
                        Date = new DateTime(2015, 12, 14),
                        Created = DateTime.Now
                    };
                    Event WorkshopGrosKlein = new Event()
                    {
                        Title = "Werkstattgespräch GROSS UND KLEIN",
                        Picture = "b4db49e6-5e61-45eb-88cb-5bc83f1f6704.png",
                        Teaser = "31. März 2016, Künstlerhaus Wien",
                        Text = "Alexandra Maringer (Szenenbild), Birgit Hutter (Kostümbild) und Sven Martin (VFX Supervisor, Pixomondo) berichteten über ihre Arbeit an dem Kinofilm \"Hilfe, " +
                        "ich habe meine Lehrerin geschrumpft\" A/D 2015<br style=\"\">Moderation&nbsp;<a href=\"http://www.filmdesigners.at/index.php?ctrl=mitglieder&amp;mid=93&amp;bid=1&amp;spr=4\" class=\"normlink\" style=\"cursor: pointer;\">Florian Reichmann</a><br style=\"\"><br style=\"\">Photos: Judith Stehlik&nbsp;",
                        Date = new DateTime(2016, 3, 31),
                        Created = DateTime.Now
                    };
                    Event Punsch2016 = new Event()
                    {
                        Title = "VÖF Punsch 2016",
                        Picture = "",
                        Teaser = "<div class=\"gal_textcont\" style=\"width: 412px; height: auto; padding - top: 17px; padding - left: 16px; float: left; \"><div class=\"filmdet\" style=\"width: 364px; height: auto; line - height: 14px; overflow: hidden; z - index: 2; \">Auch heuer wieder lud der VÖF zum traditionellen Punsch, diesmal in die Werkstatt von Tommy Vögel und das Lager von props.co.</div></div>",
                        Text = "Auch heuer wieder lud der VÖF zum traditionellen Punsch, diesmal in die Werkstatt von Tommy Vögel und das Lager von props.co.<br style=\"color: rgb(69, 69, 69); font - family: Verdana, Arial, Helvetica, sans - serif; font - size: 11px; background - color: rgb(14, 37, 51); \">",
                        Date = new DateTime(2016, 12, 14),
                        Created = DateTime.Now
                    };
                    Event VOF30 = new Event()
                    {
                        Title = "Jubiläum 30 Jahre VÖF",
                        Picture = "",
                        Teaser = "<div class=\"filmtyp_sm\" style=\"width: 394px; height: auto; padding - bottom: 18px; overflow: hidden; line - height: 14px; z - index: 2; \">DESIGN IM FILM -SZENENBILD -KOSTÜMBILD -REQUISITE -GARDEROBE</div><div class=\"filmdet\" style=\"width: 364px; height: auto; line - height: 14px; overflow: hidden; z - index: 2; \">Im Rahmen einer mehrtägigen Veranstaltung feiert der VÖF sein 30-Jähriges Bestehen und präsentiert das stilprägende Wirken des Filmdesigns in Kooperation mit der&nbsp;<a href=\"http://www.viennadesignweek.at/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Vienna Design Week</a></div>",
                        Text = "Im Rahmen einer mehrtägigen Veranstaltung feiert der VÖF sein 30-Jähriges Bestehen und präsentiert das stilprägende Wirken des Filmdesigns.<br style=\"\">Eine Filmschau mit anschließendem Q&amp;A mit Teammitgliedern zeigt exemplarische Arbeiten österreichischer Filmdesigner, kuratiert durch&nbsp;<a href=\"http://www.hoanzl.at/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Hoanzl</a>&nbsp;(„Edition Der Österreichische Film“).<br style=\"\">Workshops und Führungen durch Ateliers und Fundi von Mitgliedern des VÖF geben Einblicke ins Filmschaffen.<br style=\"\">Internationale Filmdesigner (Michele Clapton, Uli Hanisch) erläutern in Werkstattgesprächen ihre Arbeitsweisen.<br style=\"\">In einer Podiumsdiskussion werden die nicht vorhandenen Ausbildungsmöglichkeiten im Bereich des Filmdesigns thematisiert.<br style=\"\"><br style=\"\">Kooperationspartner:<br style=\"\"><a href=\"http://www.viennadesignweek.at/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Vienna Design Week</a><br style=\"\"><a href=\"http://www.hoanzl.at/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Hoanzl</a><br style=\"\"><a href=\"http://www.aacamera.org/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">aac - Verband Oesterreichischer Kameraleute</a><br style=\"\"><br style=\"\">Pressemeldungen:<br style=\"\"><a href=\"https://l.facebook.com/l.php?u=http%3A%2F%2Fm.schaufenster.diepresse.com%2Fhome%2Fwohnen%2Finspiration%2F5292595%2Findex.do&amp;h=ATO5pMCovVRtE6CX4wfXCjCsHBDqlXYAVLw_Uccy3D-crsezAaE3WqMQUhn3X4ZMWUhDJOpS8qg9IMHdl7yQX-6vX8_kW3zgg7PG_Zs_Jsz8HE-9B4IE3-RtJmIRZhd6-jW9h3AlNrrM50Q1WNJXaRLyxVfLOM1ydMfNlAFMzhChNcSt16CaNAJgihj74-wvpebHh5ReXWn3ZlBReSkqv76qggcI9UvRUgxAVhpqXemrbS2eU21CoYembmNa-kITDYFCxIYNtcgY72M5aw3-ZFaJi9sk_Kuc4A501QUnMjWgK1M\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">\"Die Presse\" /Schaufenster vom 29.9.2017</a><br style=\"\"><a href=\"https://kurier.at/kultur/game-of-thrones-kleider-erzaehlen-geschichten/288.618.272\" class=\"normlink\" style=\"cursor: pointer;\">\"Kurier\" vom 27.9.2017</a><br style=\"\"><a href=\"http://wien.orf.at/news/stories/2869122/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Kleider machen Leute und Filme - wien.ORF.at</a>",
                        Date = new DateTime(2016, 12, 14),
                        Created = DateTime.Now
                    };
                    Event Punsch2017 = new Event()
                    {
                        Title = "VÖF-Punsch 2017",
                        Picture = "",
                        Teaser = "Auch heuer wieder lud der VÖF zum traditionellen Punsch.",
                        Text = "Diesmal im Hof des Silberwirt, 1050 Wien, Schlossgasse 21<br style=\"\"><br style=\"\"><a href=\"https://www.dropbox.com/sh/qz7hyglsn5fezp5/AAA-QpfiyaG3QH68ACp2kXXXa?dl=0\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Galerie</a>&nbsp;",
                        Date = new DateTime(2016, 12, 14),
                        Created = DateTime.Now
                    };
                    context.Add(WorkshopREALANDDDIGITAL);
                    context.Add(WorkshopKramerOlah);
                    context.Add(WorkshopPatinier);
                    context.Add(Graz);
                    context.Add(WorkshopHutter);
                    context.Add(Punsch2015);
                    context.Add(WorkshopGrosKlein);
                    context.Add(Punsch2016);
                    context.Add(VOF30);
                    context.Add(Punsch2017);

                    await context.SaveChangesAsync();
                    await SeedEnrollments.Initialize(serviceProvider);
                }
            }
        }
        #endregion
    }
}
#endif