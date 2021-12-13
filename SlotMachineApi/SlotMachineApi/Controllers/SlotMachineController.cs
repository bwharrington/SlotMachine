using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SlotMachineApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class SlotMachineController : ControllerBase
    {
        private readonly ILogger<SlotMachineController> _logger;

        public SlotMachineController(ILogger<SlotMachineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("roll/{credits}")]
        public ActionResult<List<SlotMachineBlock>> GetSlotMachineRoll(int credits)
        {
            _logger.LogInformation("Calling GetSlotMachineRoll");
            _logger.LogInformation("Credits : " + credits);
            SlotMachineImpl slotMachine = new SlotMachineImpl();

            List<SlotMachineBlock> slotMachineRoll;
            try
            {   
                slotMachineRoll = slotMachine.GetRoll(credits);
            } catch(Exception ex)
            {
                _logger.LogError("Error in GetSlotMachineRoll");
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            return Ok(slotMachineRoll);
        }

    }
}