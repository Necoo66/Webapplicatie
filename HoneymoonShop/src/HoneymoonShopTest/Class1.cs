using HoneymoonShop.Controllers;
using HoneymoonShop.Data;
using HoneymoonShop.Models.GebruikerModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HoneymoonShopTest
{
    public class Class1
    {
        public Class1()
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

            AfspraakController ac = new AfspraakController(mockDbContext.Object);


            var result = await ac.Maken(new AfspraakMaken());
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
    }
}
