using HoneymoonShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using HoneymoonShop.Controllers;
using HoneymoonShop.Models.Bruid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneymoonShopTest
{
    public class BruidControllerTest
    {
        

        public BruidControllerTest()
        {
            
        }

        [Fact]
        public void Valid_IndexReturnsViewResult()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetMerk = new Mock<DbSet<Merk>>();
            var mockDbSetCategorie = new Mock<DbSet<Categorie>>();
            var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();

            var dummyKenmerk = new List<Merk>() { new Merk() { Id = 1, Naam = "Jan"} }.AsQueryable();

            mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.Provider).Returns(dummyKenmerk.Provider);

            mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.Provider).Returns(dummyKenmerk.Provider);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.Expression).Returns(dummyKenmerk.Expression);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.ElementType).Returns(dummyKenmerk.ElementType);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.GetEnumerator()).Returns(dummyKenmerk.GetEnumerator());

            mockDbContext.Setup(x => x.Merk).Returns(mockDbSetMerk.Object);
            mockDbContext.Setup(x => x.Categorie).Returns(mockDbSetCategorie.Object);
            mockDbContext.Setup(x => x.Kenmerk).Returns(mockDbSetKenmerk.Object);
            
            //init controller
            //Foutmelding komt hier
            BruidController c = new BruidController(mockDbContext.Object);

            //FilterSelectie filterSelectie = new FilterSelectie() { Categorie = 1, Kenmerken = new List<int>() { 1, 2 }, MinPrijs = 1000, MaxPrijs = 2500 };

            //var result = c.Index(filterSelectie);

            //var viewResult = Assert.IsType<ViewResult>(result);


        }
    }
}
