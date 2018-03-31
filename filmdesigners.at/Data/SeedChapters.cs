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
                    Chapter Diagonale2018 = new Chapter()
                    {
                        Heading = "Diagonale-Filmpreise 2018",
                        Text = "Am 17. März wurden in Graz die Diagonale-Filmpreise verliehen," +
                            "<br style=\"\">die vom VÖF initiierten und von der VdFS mit je € 3.000,- dotierten Preise gingen an:<br style=\"\">" +
                            "Bestes Szenenbild: Paul Horn<br style=\"\">Bestes Kostümbild: Peter Paradies<br style=\"\">beide für \"Phaidros\" A 2018, Regie Mara Mattuschka",
                        Created = DateTime.Now,
                        Edited = new DateTime()
                    };
                    Chapter ATFilmpreis2018 = new Chapter()
                    {
                        Heading = "Österreichischer Filmpreis 2018",
                        Text = "Der Verein \"Akademie des Österreichischen Films\" vergab am 31.1.2018 den Österreichischen Filmpreis 2018 u.a. in folgenden Kategorien:" +
                            "<br style=\"\">Bestes Szenenbild an&nbsp;" +
                            "<a href=\"http://www.filmdesigners.at/index.php?ctrl=mitglieder&amp;mid=32&amp;bid=1&amp;spr=4\" class=\"normlink\" style=\"cursor: pointer;\">" +
                            "Katharina Wöppermann</a>,<br style=\"\">Bestes Kostümbild an&nbsp;" +
                            "<a href=\"http://www.filmdesigners.at/index.php?ctrl=mitglieder&amp;mid=117&amp;bid=4&amp;spr=4\" class=\"normlink\" style=\"cursor: pointer;\">" +
                            "Veronika Albert</a>, beide für \"Licht\" Regie Barabara Albert",
                        Created = DateTime.Now.AddDays(-1),
                        Edited = new DateTime()
                    };
                    Chapter EUFilmpreis2017 = new Chapter()
                    {
                        Heading = "Europäischer Filmpreis 2017",
                        Text = "Am 9. Dezember vergab die Europäische Filmakademie zum 30. Mal ihre Preise, darunter:<br style=\"\">" +
                            "EUROPEAN PRODUCTION DESIGNER 2017 Josefin Åsberg für THE SQUARE<br style=\"\">" +
                            "EUROPEAN COSTUME DESIGNER 2017 Katarzyna Lewińska für SPOOR&nbsp;<br style=\"\">" +
                            "<a href=\"https://www.europeanfilmacademy.org/News-detail.155.0.html?&amp;tx_ttnews%5Btt_news%5D=589&amp;cHash=8f61239d31c1b537970814c94a5a0c7a\" " +
                            "class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">European Film Academy</a>",
                        Page = "HomeIndex",
                        Created = DateTime.Now.AddDays(-2),
                        Edited = new DateTime()
                    };
                    Chapter VOFPunsch2017 = new Chapter()
                    {
                        Heading = "VÖF-PUNSCH 2017",
                        Text = "<p>" +
                            "<img src=\"/images/aeb9f938-92fc-4400-9d2e-ba13c191915c.jpeg\" alt=\"punsch.jpg\" style=\"width: 496px; \"><br></p>" +
                            "<p>Wie in den vergangenen Jahren lud der VÖF zum Punsch im Hof des Silberwirt, diesmal am 4. Dezember.<br style=\"\">" +
                            "Zahlreiche Mitglieder und Gäste erfreuten sich in vorweihnachtlicher Stimmung, an Atmosphäre, Speis &amp; Trank<br style=\"\"><br style=\"\">" +
                            "<a href=\"https://www.dropbox.com/sh/qz7hyglsn5fezp5/AAA-QpfiyaG3QH68ACp2kXXXa?dl=0\" class=\"normlink\" target=\"_blank\" " +
                            "style=\"cursor: pointer;\">Galerie</a></p>",
                        Page = "HomeIndex",
                        Created = DateTime.Now.AddDays(-3),
                        Edited = new DateTime()
                    };
                    Chapter EFPC = new Chapter()
                    {
                        Heading = "EUROPEAN FEDERATION for PRODUCTION & COSTUME DESIGN",
                        Text = "<p>" +
                            "<img src=\"/images/c0ea335f-a03a-4ba1-bb65-3327833042a6.jpeg\" alt=\"1.jpg\" style=\"width: 496px; \"></p>" +
                            "<p>2. offizielles Treffen in Rom - Cinecittà<br style=\"\"><br style=\"\">" +
                            "von links nach rechts: Carlo Poggioli (ASC), Maximilian Lange (VSK),&nbsp;" +
                            "<a href=\"http://filmdesigners.at/index.php?ctrl=mitglieder&amp;mid=4&amp;bid=1&amp;spr=4\" class=\"normlink\" target=\"_blank\" " +
                            "style=\"cursor: pointer;\">Alexandra Maringer</a>(VÖF), Michel Barthelemy (ADC), Monica Rottmeyer (SSFV), Sarah Maria Fritsche (DS)</p><p>" +
                            "<img src=\"/images/13e6303e-5019-45ed-a1ca-a62890c4b69d.jpeg\" style=\"width: 496px;\" alt=\"2.jpg\"><br></p><p>" +
                            "1. Reihe von links nach rechts: Chloë Cambournac (ADC), Anja Wessel (DS), Livia Borgognoni (ASC),&nbsp;" +
                            "<a href=\"http://filmdesigners.at/index.php?ctrl=mitglieder&amp;mid=40&amp;bid=4&amp;spr=4\" class=\"normlink\" target=\"_blank\" " +
                            "style=\"cursor: pointer;\">Birgit Hutter</a>&nbsp;(VÖF), Michèle Pezzin (AFCCA), Laurent Tesseyre (ADC, MAD)<br style=\"\">" +
                            "<br style=\"\">2. Reihe von rechts nach links: Laure Lepelley Monbillard (ADC), Stéphanie Bertrand (MAD), ??? (sorry !), " +
                            "Valeria Paoloni (ASC)<br style=\"\"><br style=\"\">stehend - von links nach rechts:<br style=\"\">??? (sorry !), " +
                            "Giovanni Licheri (ASC), Carlo Poggioli (ASC), Francesco Rutelli (Ex-Kulturminister, Präsident der ANICA - " +
                            "National Association of Film and Audiovisual Industry)<br style=\"\"><br style=\"\">- - -<br style=\"\"><br style=\"\">" +
                            "Das Treffen in Rom war sehr spannend und voller lebhafter Diskussionen, trotz der schwierigen und etwas trockenen Aufgabe die uns bevorstand: " +
                            "Es galt die wesentlichen Grundlagen für unseren Europaverband festzulegen (Name, Ort, Statuten, Vorhaben, ..).<br style=\"\">" +
                            "<br style=\"\">Dante Ferretti und der ehemalige italienische Kulturminister und derzeitige Präsident von ANICA, Francesco Rutelli, " +
                            "hielten eine kurze Rede um uns in unserem Anliegen aufs herzlichste zu unterstützen und einen guten weiteren Weg zu wünschen.<br><br></p>",
                        Page = "HomeIndex",
                        Created = DateTime.Now.AddDays(-4),
                        Edited = new DateTime()
                    };
                    Chapter VOF30 = new Chapter()
                    {
                        Heading = "30 Jahre VÖF",
                        Text = "<p style=\"margin-bottom: 0px; line-height: 14px; padding-bottom: 4px;\">" +
                            "<img src=\"/images/61a62f2d-5d09-47ba-9dfa-822c05d0259c.jpeg\" alt=\"30.jpg\" style=\"width: 248px; float: left;\" class=\"note-float-left\">" +
                            "Unser Verband wurde vor 30 Jahren gegründet und dieses Jubiläum wurde im Herbst 2017 gebührend gefeiert!<br>" +
                            "</p>" +
                            "<p style=\"margin-bottom: 0px; line-height: 14px; padding-bottom: 4px; \">" +
                            "Einerseits mit einem Fest am 30. September, aber auch mit Veranstaltungen, die unsere Tätigkeiten bei der Filmherstellung behandeln.<br>" +
                            "Im Zeitraum 29. September bis 8. Oktober wurden Werkstattgespräche mit internationalen Szenen- und KostümbildnerInnen, eine Podiumsdiskussion " +
                            "zum Thema \"Ausbildung\" und eine Filmreihe im Metro-Kino veranstaltet.<br>Weiters gab es Workshops sowie Atelier- und Fundusrundgänge in " +
                            "Kooperation mit der Vienna Design Week.<br><br>" +
                            "<a href=\"http://www.filmdesigners.at/index.php?spr=4&amp;ctrl=voef&amp;mid=94&amp;event=21\" " +
                            "class=\"normlink\" style=\"cursor: pointer;\">Galerie</a><br>" +
                            "<br><a href=\"http://www.viennadesignweek.at/search.php?search%5Bkeyword%5D=v%C3%B6f&amp;x=0&amp;y=0&amp;inc=search&amp;run_task=1\" " +
                            "class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">Vienna Design Week</a><br><br>" +
                            "<a href=\"https://l.facebook.com/l.php?u=http%3A%2F%2Fm.schaufenster.diepresse.com%2Fhome%2Fwohnen%2Finspiration%2F5292595%2Findex.do&amp;" +
                            "h=ATO5pMCovVRtE6CX4wfXCjCsHBDqlXYAVLw_Uccy3D-crsezAaE3WqMQUhn3X4ZMWUhDJOpS8qg9IMHdl7yQX-6vX8_kW3zgg7PG_Zs_Jsz8HE-9B4IE3-RtJmIRZhd6-" +
                            "jW9h3AlNrrM50Q1WNJXaRLyxVfLOM1ydMfNlAFMzhChNcSt16CaNAJgihj74-" +
                            "wvpebHh5ReXWn3ZlBReSkqv76qggcI9UvRUgxAVhpqXemrbS2eU21CoYembmNa-kITDYFCxIYNtcgY72M5aw3-ZFaJi9sk_Kuc4A501QUnMjWgK1M\" " +
                            "class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">\"Die Presse\" /Schaufenster vom 29.9.2017</a><br>" +
                            "<a href=\"https://kurier.at/kultur/game-of-thrones-kleider-erzaehlen-geschichten/288.618.272\" " +
                            "class=\"normlink\" style=\"cursor: pointer;\">\"Kurier\" vom 27.9.2017</a><br>" +
                            "<a href=\"http://wien.orf.at/news/stories/2869122/\" class=\"normlink\" target=\"_blank\" style=\"cursor: pointer;\">" +
                            "Kleider machen Leute und Filme - wien.ORF.at</a></p><div><br></div>",
                        Page = "HomeIndex",
                        Created = DateTime.Now.AddDays(-5),
                        Edited = DateTime.Now
                    };

                    context.Add(Diagonale2018);
                    context.Add(ATFilmpreis2018);
                    context.Add(EUFilmpreis2017);
                    context.Add(VOFPunsch2017);
                    context.Add(EFPC);
                    context.Add(VOF30);

                    await context.SaveChangesAsync();
                }
                await SeedEvents.Initialize(serviceProvider);
            }
        }
    }
}
#endif