using Microsoft.Extensions.Logging;
using SlotMachineApi.Controllers;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using SlotMachineApi;
using System.Collections.Generic;

namespace SlotMachineTests
{
    public class SlotMachineApiTests
    {
        private ILogger<SlotMachineController> _logger;
        SlotMachineController slotMachineController;

        public SlotMachineApiTests()
        {
            var mock = new Mock<ILogger<SlotMachineController>>();
            _logger = mock.Object;

            slotMachineController = new(_logger);
        }


        [Fact]
        public void SlotMachineApiTests_10_credits_succedes_with_3_results()
        {
            var results = GetResultFromSlotMachineRoll(10);
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void SlotMachineApiTests_50_credits_succedes_with_3_results()
        {
            var results = GetResultFromSlotMachineRoll(50);
            Assert.Equal(3, results.Count);

        }

        [Fact]
        public void SlotMachineApiTests_70_credits_succedes_with_3_results()
        {
            var results = GetResultFromSlotMachineRoll(70);
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void SlotMachineApiTests_returns_200()
        {
            var items = slotMachineController.GetSlotMachineRoll(10);
            var results = (ObjectResult)items.Result;
            Assert.Equal(200, results.StatusCode);
        }

        private List<SlotMachineBlock> GetResultFromSlotMachineRoll(int credits)
        {
            var items = slotMachineController.GetSlotMachineRoll(credits);
            var results = (ObjectResult)items.Result;
            var resultValue = results.Value as List<SlotMachineBlock>;
            return resultValue;
        }
    }
}