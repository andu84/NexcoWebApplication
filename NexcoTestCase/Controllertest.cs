using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NexcoWeb.WebUI;
using NexcoWeb.WebUI.Controllers;
using NexcoWeb.WebuI.Controllers;


namespace NexcoTestCase
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Home()
        {
            //Arrange
            IncomeExpenditureController controller = new IncomeExpenditureController();
            //Act
            ViewResult result = controller.Home() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void HowItWorks()
        {
            //Arrange
            IncomeExpenditureController controller = new IncomeExpenditureController();
            //Act
            ViewResult result = controller.HowItWorks() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index()
        {
            //Arrange
            IncomeExpenditureController controller = new IncomeExpenditureController();
            //Act
            ViewResult Vresult = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(Vresult);
        }

        [TestMethod]
        public void Support()
        {
            //Arrange
            IncomeExpenditureController controller = new IncomeExpenditureController();
            //Act
            ViewResult result = controller.Support() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void About()
        {
            //Arrange
            IncomeExpenditureController controller = new IncomeExpenditureController();
            //Act
            ViewResult result = controller.About() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

      

    }
}
