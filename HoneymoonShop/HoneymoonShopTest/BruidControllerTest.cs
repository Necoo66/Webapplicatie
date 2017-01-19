using HoneymoonShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Mock<DbSet<Merk>> mockDbSetMerk = null;
        Mock<DbSet<Categorie>> mockDbSetCategorie = null;
        Mock<DbSet<Kenmerk>> mockDbSetKenmerk = null;
        Mock<DbSet<Product>> mockDbSetProduct = null;
        Mock<DbSet<Product_X_Kenmerk>> mockDbSetPxK = null;

        public BruidControllerTest()
        {
            mockDbSetMerk = new Mock<DbSet<Merk>>();
            mockDbSetCategorie = new Mock<DbSet<Categorie>>();
            mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();
            mockDbSetProduct = new Mock<DbSet<Product>>();
            mockDbSetPxK = new Mock<DbSet<Product_X_Kenmerk>>();
        }

        [Fact]
        public void Valid_IndexReturnsViewResult()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            BruidController controller = initDB(mockDbContext);

            FilterSelectie filterSelectie = new FilterSelectie()
            {
                Categorie = 1,
                MinPrijs = 1000,
                MaxPrijs = 6000
            };
            var result = controller.Index(filterSelectie);

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        private BruidController initDB(Mock<ApplicationDbContext> m)
        {
            /*begin dummy merk*/
            var dummyMerk = new List<Merk>() { new Merk() { Id = 1, Naam = "Jan" } }.AsQueryable();

            mockDbSetMerk.As<IQueryable<Merk>>().Setup(x => x.Provider).Returns(dummyMerk.Provider);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(x => x.Expression).Returns(dummyMerk.Expression);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(x => x.ElementType).Returns(dummyMerk.ElementType);
            mockDbSetMerk.As<IQueryable<Merk>>().Setup(x => x.GetEnumerator()).Returns(dummyMerk.GetEnumerator());

            m.Setup(x => x.Merk).Returns(mockDbSetMerk.Object);
            /*eind dummy merk*/

            /*begin dummy categorie*/
            var dummyCategorie = new List<Categorie>(){ new Categorie() { Id = 1, Naam = "Sale" },
                                                        new Categorie() { Id = 2, Naam = "Winter"},
                                                        new Categorie() { Id = 3, Naam = "Summer"} };

            mockDbSetCategorie.As<IQueryable<Categorie>>().Setup(x => x.Provider).Returns(dummyCategorie.AsQueryable().Provider);
            mockDbSetCategorie.As<IQueryable<Categorie>>().Setup(x => x.Expression).Returns(dummyCategorie.AsQueryable().Expression);
            mockDbSetCategorie.As<IQueryable<Categorie>>().Setup(x => x.ElementType).Returns(dummyCategorie.AsQueryable().ElementType);
            mockDbSetCategorie.As<IQueryable<Categorie>>().Setup(x => x.GetEnumerator()).Returns(dummyCategorie.AsQueryable().GetEnumerator());

            m.Setup(x => x.Categorie).Returns(mockDbSetCategorie.Object);
            /*eind dummy categorie*/

            /*begin dummy kenmerk*/
            var dummyKenmerk = new List<Kenmerk>(){ new Kenmerk() {  Id = 1, Naam = "Rood", Type = "Kleur"},
                                                        new Kenmerk() { Id = 2, Naam = "Kant", Type="Neklijn"},
                                                        new Kenmerk() { Id = 3, Naam = "Gekke silhouette", Type="Silhouette"} }
                                                        .AsQueryable();

            mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(x => x.Provider).Returns(dummyKenmerk.Provider);
            mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(x => x.Expression).Returns(dummyKenmerk.Expression);
            mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(x => x.ElementType).Returns(dummyKenmerk.ElementType);
            mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(x => x.GetEnumerator()).Returns(dummyKenmerk.GetEnumerator());

            m.Setup(x => x.Kenmerk).Returns(mockDbSetKenmerk.Object);
            /*eind dummy kenmerk*/

            /*begin dummy product*/
            var dummyProduct = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Merk = dummyMerk.First(),
                    Categorie = dummyCategorie[1],
                    Beschrijving ="Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum",
                    ArtikelNummer = "123hujk",
                    Prijs = 25660
                },
                new Product()
                {
                    Id = 2,
                    Merk = dummyMerk.First(),
                    Categorie = dummyCategorie[0],
                    Beschrijving ="Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum",
                    ArtikelNummer = "159",
                    Prijs = 2500
                },
                new Product()
                {
                    Id = 3,
                    Merk = dummyMerk.First(),
                    Categorie = dummyCategorie[2],
                    Beschrijving ="Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum",
                    ArtikelNummer = "654",
                    Prijs = 3500
                }
            }.AsQueryable();

            mockDbSetProduct.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(dummyProduct.Provider);
            mockDbSetProduct.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(dummyProduct.Expression);
            mockDbSetProduct.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(dummyProduct.ElementType);
            mockDbSetProduct.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(dummyProduct.GetEnumerator());

            m.Setup(x => x.Product).Returns(mockDbSetProduct.Object);

            /*eind dummy product*/


            /*begin dummy PxK*/
            var dummyPxK = new List<Product_X_Kenmerk>() {
                new Product_X_Kenmerk()
                {
                    KenmerkId = 1, ProductId = 1
                },
                new Product_X_Kenmerk()
                {
                    KenmerkId = 2, ProductId = 2
                },
                new Product_X_Kenmerk()
                {
                    KenmerkId = 2, ProductId = 3
                },
                new Product_X_Kenmerk()
                {
                    KenmerkId = 1, ProductId = 1
                },
                new Product_X_Kenmerk()
                {
                    KenmerkId = 2, ProductId = 2
                },
                new Product_X_Kenmerk()
                {
                    KenmerkId = 2, ProductId = 3
                }
            }.AsQueryable();

            mockDbSetPxK.As<IQueryable<Product_X_Kenmerk>>().Setup(x => x.Provider).Returns(dummyPxK.Provider);
            mockDbSetPxK.As<IQueryable<Product_X_Kenmerk>>().Setup(x => x.Expression).Returns(dummyPxK.Expression);
            mockDbSetPxK.As<IQueryable<Product_X_Kenmerk>>().Setup(x => x.ElementType).Returns(dummyPxK.ElementType);
            mockDbSetPxK.As<IQueryable<Product_X_Kenmerk>>().Setup(x => x.GetEnumerator()).Returns(dummyPxK.GetEnumerator());

            m.Setup(x => x.Product_X_Kenmerk).Returns(mockDbSetPxK.Object);
            /*eind dummy PxK*/

            return new BruidController(m.Object);
        }
    }
}
