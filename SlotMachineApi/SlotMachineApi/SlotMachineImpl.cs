namespace SlotMachineApi
{
    public class SlotMachineImpl
    {
        private List<SlotMachineBlock> slotMachineRoll;

        public SlotMachineImpl()
        {
            slotMachineRoll = new();
        }

        public List<SlotMachineBlock> GetRoll(int credits)
        {
            slotMachineRoll = GenerateRoll();
            if(credits >= 40 && credits  <= 60)
            {
                //cheat mode
                if (IsWinningRoll())
                {
                    if(ShouldReRoll(30))
                    {
                        slotMachineRoll = GenerateRoll();
                    }
                }
            } else if(credits > 60)
            {
                if (IsWinningRoll())
                {
                    if (ShouldReRoll(60))
                    {
                        slotMachineRoll = GenerateRoll();
                    }
                }

            }
            
            return slotMachineRoll;
        }

        private bool IsWinningRoll()
        {
            //A winning roll is if all the items are the same.
            return slotMachineRoll.Any(rollItem => rollItem != slotMachineRoll[0]);
        }

        private bool ShouldReRoll(int reRollPercentage)
        {
            //Determine if the server should reroll based on a provided reroll chance.
            Random random = new Random();
            int reRollChance = random.Next(1, 100);

            if(reRollChance <= reRollPercentage)
            {
                return true;
            }

            return false;
        }

        private List<SlotMachineBlock> GenerateRoll()
        {
            //Generate a new random roll
            Array values = Enum.GetValues(typeof(SlotMachineBlock));
            Random random = new();

            List<SlotMachineBlock> slotMachineRoll = new List<SlotMachineBlock>();

            SlotMachineBlock randomBlock = (SlotMachineBlock)values.GetValue(random.Next(values.Length));
            slotMachineRoll.Add(randomBlock);

            randomBlock = (SlotMachineBlock)values.GetValue(random.Next(values.Length));
            slotMachineRoll.Add(randomBlock);

            randomBlock = (SlotMachineBlock)values.GetValue(random.Next(values.Length));
            slotMachineRoll.Add(randomBlock);
            

            return slotMachineRoll;
        }
    }
}
