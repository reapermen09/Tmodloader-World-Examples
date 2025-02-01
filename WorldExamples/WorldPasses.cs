using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TmodloaderWorldExamples.WorldExamples
{
    public class WorldPasses : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int basicHouse = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (basicHouse != -1)
                tasks.Insert(basicHouse + 1, new BasicHouse("Basic House", 237.4298f));
            /*
            int advancedHouse = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (advancedHouse != -1)
                tasks.Insert(advancedHouse + 1, new AdvancedHouse("Advanced House", 237.4299f));
            */
        }
    }
}
