using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store;
using Store.Controllers;
using Store.Models;
using Moq;
using System.Linq;


namespace Store.Tests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {

        //Moq Data
        CategoriesController controller;
        List<Category> Categories;
        Mock<IBLCategories> BL;


        //TestInitializer with Some Data
        [TestInitialize]
        public void TestInitializer()
        {
            Categories = new List<Category>
            {
                new Category{CategoryId = 1, CategoryName="ProductNumberOne",ProductPhoto = null  },
                new Category { CategoryId = 2, CategoryName = "ProductNumberTwo", ProductPhoto= null }
            };

            BL = new Mock<IBLCategories>();
            BL.Setup(c => c.Categories).Returns(Categories.AsQueryable());

            controller = new CategoriesController(BL.Object);
        }


        //Index Test1
        //Auther: - Keval Patel
        [TestMethod]
        public void IndexVewLoadTest()
        {
            //Arrange

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assest
            Assert.AreEqual("Index", result.ViewName);
        }

        //Index Test2
        [TestMethod]
        public void IndexLoadCategory()
        {
            //Arrange

            //Act
            var results = (List<Category>)((ViewResult)controller.Index()).Model;

            //Assest
            CollectionAssert.AreEqual(Categories, results);
        }
        [TestMethod]
        public void NullViewDetails()
        {
            //arrange

            //act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

        //Detail Test1
        [TestMethod]
        public void DetailsViewRightCategoryId()
        {
            //Arrange

            //Act
            var result = ((ViewResult)controller.Details(2)).Model;


            //Assest
            Assert.AreEqual(Categories.SingleOrDefault(c => c.CategoryId == 2), result);
        }

        //Test2
        [TestMethod]
        public void DetailsViewWrongId()
        {

            //Assest

            //Act
            HttpNotFoundResult result = controller.Details(4) as HttpNotFoundResult;

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }


        //Delete
        //Test1
        [TestMethod]
        public void Delete()
        {
            //Arrange

            //Act
            ViewResult result = controller.Delete(1) as ViewResult;

            //Assest
            Assert.AreEqual("Delete", result.ViewName);
        }

        //Delete Test2
        [TestMethod]
        public void DeleteConfimed()
        {
            //arrange
            RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //act
            var ResultList = result.RouteValues.ToArray();

            //assert
            Assert.AreEqual("Index", ResultList[0].Value);
        }

        //Test3
        [TestMethod]
        public void DeleteErrors()
        {
            //Arrange

            //Act
            HttpStatusCodeResult result = controller.Delete(null) as HttpStatusCodeResult;

            //Assest
            Assert.AreEqual(400, result.StatusCode);

        }

        //Edit
        //TEST1
        [TestMethod]
        public void Edit()
        {
            //Arrange

            //act
            ViewResult result = controller.Edit(1) as ViewResult;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        //Test2
        [TestMethod]
        public void EditWrongId()
        {
            //Arrange
            //Act
            HttpStatusCodeResult result = controller.Edit(7) as HttpStatusCodeResult;

            //Assest
            Assert.AreEqual(404, result.StatusCode);
        }

        //Test3
        [TestMethod]
        public void EditRightIdVeiw()
        {
            //Arrange
            //Act
            var result = ((ViewResult)controller.Edit(1)).Model;

            //assert
            Assert.AreEqual(Categories.SingleOrDefault(c => c.CategoryId == 1), result);
        }

        //Test4
        [TestMethod]
        public void EditWithNull()
        {
            //Arrange
            int? NullCategory = null;

            //Act
            HttpStatusCodeResult result = controller.Edit(NullCategory) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

        // Test5
        [TestMethod]
        public void EditPostMethodLoadsRightIndexView()
        {
            //arrange

            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(Categories[0]);

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        // Test6 
        [TestMethod]
        public void EditPostMethodLoadsInvalidView()
        {
            Category wrong = new Category { CategoryId = 40 };

            // arrange
            controller.ModelState.AddModelError("Erroe", "Don't work");

            // act
            ViewResult result = (ViewResult)controller.Edit(wrong);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        // Test 7
        [TestMethod]
        public void EditPostMethodLoadsInvalidCourse()
        {
            Category wrong = new Category { CategoryId = 90 };

            // arrange
            controller.ModelState.AddModelError("Error", "Don't work");
            // act
            Category result = (Category)((ViewResult)controller.Edit(wrong)).Model;

            // assert
            Assert.AreEqual(wrong, result);
        }



        //Create
        //Test1
        [TestMethod]
        public void CreateView()
        {
            //Arrange

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assaste
            Assert.AreEqual("Create", result.ViewName);

        }

        //Test2
        [TestMethod]
        public void CreateWrongCategory()
        {
            //Arrange
            Category newCategory = new Category { CategoryId = 2, CategoryName = "ProductNumberTwo", ProductPhoto = null };

            //act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(newCategory);

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        //Test3
        [TestMethod]
        public void CreateRightCategory()
        {            
            //arrange
            Category InvalidCourse = new Category();
            controller.ModelState.AddModelError("Not Working", "Please Help usfor this");

            //act
            ViewResult result = (ViewResult)controller.Create(InvalidCourse);

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }
    }

}