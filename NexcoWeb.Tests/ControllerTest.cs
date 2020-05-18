using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexcoWeb.WebUI.Controllers;
using NexcoWeb.WebUI;
using NexcoWeb.WebuI.Controllers;
using System.Web.Mvc;

namespace NexcoWeb.Tests
{
    [TestClass]
    class ControllerTest
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

    }
}
