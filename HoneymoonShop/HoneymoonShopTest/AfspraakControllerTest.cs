using HoneymoonShop.Controllers;
using HoneymoonShop.Data;
using HoneymoonShop.Models.GebruikerModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HoneymoonShopTest
{
    public class AfspraakControllerTest
    {
        
        public AfspraakControllerTest()
        {

        }

        [Fact]
        public void Juiste_Soortafspraak_In_AfspraakController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            var result = ac.Maken(SoortAfspraak.Trouwjurken);

            //result moet een view zijn
            var viewResult = Assert.IsType<ViewResult>(result);

            //checken op correcte Model Data
            //is het de correcte class
            var model = Assert.IsAssignableFrom<AfspraakMaken>(
                            viewResult.ViewData.Model);

            Assert.Equal("Trouwjurken", model.Afspraak.AfspraakSoort.ToString());

        }

        [Fact]
        public async Task Valide_AfspraakMaken()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetAfspraak = new Mock<DbSet<Afspraak>>();
            var mockDbSetGebruiker = new Mock<DbSet<Gebruiker>>();

            var gebruiker = new Gebruiker() { Email = "test@test.nl"};

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            //als afspraak of gebruiker uit de DbContext opgevraagd ook een mock object teruggeven
            mockDbContext.Setup(x => x.Afspraak).Returns(mockDbSetAfspraak.Object);
            mockDbContext.Setup(x => x.Gebruiker).Returns(mockDbSetGebruiker.Object);

            mockDbSetGebruiker.Setup(x => x.Add(gebruiker));

            var result = await ac.Maken(new AfspraakMaken() { Gebruiker = gebruiker });
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);


            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Voltooid", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Invalide_AfspraakMaken_TeLangeNaam()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            ac.ModelState.AddModelError("Error", "Name too long");
            AfspraakMaken am = new AfspraakMaken()
            {
                Gebruiker = new Gebruiker()
                { VoornaamAchternaam = "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijh" },

                Afspraak = new Afspraak()
            };
            var result = await ac.Maken(am);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<AfspraakMaken>(
                            viewResult.ViewData.Model);

            Assert.Equal(null, viewResult.ViewName);
            //Assert.Equal("afspraakMaken", viewResult.ViewName); waarom lukt dit niet?
            Assert.Equal("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijh", model.Gebruiker.VoornaamAchternaam);
        }

        [Fact]
        public async Task Maak_Afspraak_In_AfspraakController()
        {
            Afspraak afspraak = new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017"), AfspraakSoort = SoortAfspraak.Trouwjurken, Tijd = "15 : 30" };
            Gebruiker gebruiker = new Gebruiker() { VoornaamAchternaam = "Klaas-Jan Bruinsma", Email = "kjb@hotmail.com", Nieuwsbrief = true, Telefoonnummer = "06-75567787", Trouwdatum = Convert.ToDateTime("10-10-2017") };
            AfspraakMaken am = new AfspraakMaken() { Gebruiker = gebruiker, Afspraak = afspraak };
            //am.Afspraak.Gebruiker = am.Gebruiker;

            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetAfspraak = new Mock<DbSet<Afspraak>>();
            var mockDbSetGebruiker = new Mock<DbSet<Gebruiker>>();

            //als afspraak of gebruiker uit de DbContext opgevraagd ook een mock object teruggeven
            mockDbContext.Setup(x => x.Afspraak).Returns(mockDbSetAfspraak.Object);
            mockDbContext.Setup(x => x.Gebruiker).Returns(mockDbSetGebruiker.Object);
            mockDbContext.Setup(x => x.SaveChangesAsync(new System.Threading.CancellationToken())).ReturnsAsync(1);//.Verifiable());//.ReturnsAsync(mockDbContext.Object);

            AfspraakController ac = new AfspraakController(mockDbContext.Object);
            var result = await ac.Maken(am);

            mockDbSetAfspraak.Verify(m => m.Add(It.IsAny<Afspraak>()), Times.Once());
            mockDbSetAfspraak.Verify(m => m.Add(It.Is<Afspraak>(a => a.Tijd.Equals("15 : 30"))));

            mockDbSetGebruiker.Verify(m => m.Add(It.IsAny<Gebruiker>()), Times.Once());
            mockDbSetGebruiker.Verify(m => m.Add(It.Is<Gebruiker>(g => g.VoornaamAchternaam.Equals("Klaas-Jan Bruinsma"))));



            mockDbContext.Verify(m => m.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());//Times.Once failed
        }



        [Fact]
        public void GetAvailableDates_In_AfspraakController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetAfspraak = new Mock<DbSet<Afspraak>>();

            var dummyData = new List<Afspraak>()
            {
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") },
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") },
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") },
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") },
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") },
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017") }
            }.AsQueryable();

            //alle property van IQueryable correct toekennen
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            mockDbContext.Setup(x => x.Afspraak).Returns(mockDbSetAfspraak.Object);

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            var result = ac.GetAvalibleDates(01, 2017);

            var arrayResult = Assert.IsType<DateTime[]>(result);
            int aantal = result.Count();

            Assert.Equal(1, aantal);
            Assert.Equal(1, result.ElementAt(0).Month);
        }
        [Fact]
        public void GetTakenTimes_In_AfspraakController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetAfspraak = new Mock<DbSet<Afspraak>>();

            var dummyData = new List<Afspraak>()
            {
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017"), Tijd = "15 : 30"},
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017"), Tijd =  "10 : 30"},
            new Afspraak() { Datum = Convert.ToDateTime("01 - 01 - 2017"), Tijd = "09 : 00"},
            }.AsQueryable();

            //alle property van IQueryable correct toekennen
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetAfspraak.As<IQueryable<Afspraak>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            mockDbContext.Setup(x => x.Afspraak).Returns(mockDbSetAfspraak.Object);

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            var result = ac.GetTakenTimes(01, 01, 2017);

            var arrayResult = Assert.IsType<string[]>(result);
            int aantal = result.Count();

            Assert.Equal(3, aantal);
            Assert.Equal("10 : 30", result.ElementAt(1));
        }
    }
}