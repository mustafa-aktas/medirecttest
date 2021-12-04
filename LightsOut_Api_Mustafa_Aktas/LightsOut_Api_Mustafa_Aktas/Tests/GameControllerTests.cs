using LightsOut_Api_Mustafa_Aktas.Controllers;
using LightsOut_Api_Mustafa_Aktas.DTO;
using LightsOut_Api_Mustafa_Aktas.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Assert = NUnit.Framework.Assert;

namespace LightsOut_Api_Mustafa_Aktas.Tests
{
    public class GameControllerTests
    {
        //test class is only included for demonstration, actual test project must be seperate
        [Test]
        public void TestGameController()
        {
            var board = new BoardDTO { ColCount = 3, RowCount = 3, DefaultTiles = new List<int> { 2 } };
            var mockService = new Mock<IGameService>();
            mockService.Setup(x => x.GetBoardData()).ReturnsAsync(board);

            // Arrange
            GameController controller = new GameController(mockService.Object);

            IActionResult res = controller.GetBoardInfAsync().GetAwaiter().GetResult();
            var contentResult = res as BoardDTO;

            Assert.Equals(board.ColCount, contentResult.ColCount);
        }
    }
}
