using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace TmodloaderWorldExamples.WorldExamples
{
    public class BasicHouse : GenPass
    {
        public BasicHouse(string name, float loadWeight) : base(name, loadWeight) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int spawnX = Main.spawnTileX; //get the spawn tile for x
            int spawnY = Main.spawnTileY; //get the spawn tile for y
            progress.Message = "Generating a basic house..."; //shows this message during worldgen
            for (int i = 0; i < 11; i++) //repeats 11 times (floor) (and is in air)
            {
                WorldGen.PlaceTile(spawnX + i, spawnY - 30, TileID.WoodBlock, forced: true);
            }
            for (int i = 0; i < 11; i++) //repeats 11 times (roof)
            {
                WorldGen.PlaceTile(spawnX + i, spawnY - 35, TileID.WoodBlock, forced: true);
            }

            //left side w/doors
            WorldGen.PlaceTile(spawnX - 1, spawnY - 30, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX - 1, spawnY - 34, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX - 1, spawnY - 35, TileID.WoodBlock, forced: true);
            //calls after the blocks are made because thats just how doors work
            WorldGen.PlaceTile(spawnX - 1, spawnY - 31, TileID.ClosedDoor, forced: true); //takes -31, -32, and -33 away leaving -34 and lesser as the only options

            //right side
            WorldGen.PlaceTile(spawnX + 11, spawnY - 30, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX + 11, spawnY - 34, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX + 11, spawnY - 35, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX + 11, spawnY - 31, TileID.ClosedDoor, forced: true);

            //torch
            WorldGen.PlaceTile(spawnX, spawnY - 34, TileID.Torches, forced: true);

            //walls with a glass window...

            //walls:
            for (int i = 0; i < 11; i++)
            {
                WorldGen.PlaceWall(spawnX + i, spawnY - 31, WallID.Wood); //1
                WorldGen.PlaceWall(spawnX + i, spawnY - 34, WallID.Wood); //4
            }
            //glass windows:
            int yloop;
            for (yloop = 0; yloop < 2; yloop++) //repeats up twice
            {
                for (int i = 0; i < 2; i++)
                {
                    WorldGen.PlaceWall(spawnX + i, spawnY - 33 + yloop, WallID.Wood);
                }
                WorldGen.PlaceWall(spawnX + 2, spawnY - 33 + yloop, WallID.Glass);
                WorldGen.PlaceWall(spawnX + 3, spawnY - 33 + yloop, WallID.Glass);
                for (int i = 0; i < 7; i++)
                {
                    WorldGen.PlaceWall(spawnX + 4 + i, spawnY - 33 + yloop, WallID.Wood);
                }
            }

            //platform and chest
            WorldGen.PlaceTile(spawnX + 5, spawnY - 32, TileID.Platforms, forced: true);
            WorldGen.PlaceTile(spawnX + 6, spawnY - 32, TileID.Platforms, forced: true);

            WorldGen.PlaceChest(spawnX + 5, spawnY - 33);

            //place another one
            WorldGen.PlaceTile(spawnX + 8, spawnY - 32, TileID.Platforms, forced: true);
            WorldGen.PlaceTile(spawnX + 9, spawnY - 32, TileID.Platforms, forced: true);

            WorldGen.PlaceChest(spawnX + 8, spawnY - 33);

            //place workbench and chair
            WorldGen.PlaceTile(spawnX + 2, spawnY - 31, TileID.WorkBenches, forced: true);
            WorldGen.PlaceTile(spawnX + 1, spawnY - 31, TileID.Chairs, forced: true);
            Main.tile[spawnX + 1, spawnY - 31].TileFrameX = 18; //face right
            Main.tile[spawnX + 1, spawnY - 32].TileFrameX = 18;

            //if you did this it would automatically face left
            //WorldGen.PlaceTile(spawnX + 4, spawnY - 31, TileID.Chairs, forced: true);
        }
    }
}