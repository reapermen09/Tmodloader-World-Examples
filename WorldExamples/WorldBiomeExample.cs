using Terraria.ID;
using Terraria.IO;
using Terraria;
using Terraria.WorldBuilding;
using System;

namespace TmodloaderWorldExamples.WorldExamples
{
    public class WorldBiomeExample : GenPass
    {
        public WorldBiomeExample(string name, float loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int spawnX = Main.spawnTileX - 300;
            int spawnY = Main.spawnTileY;
            progress.Message = "Generating an example biome...";

            for (int y = spawnY - 60; y < spawnY + 130; y++)
            {
                int waveLeft = (int)(8 * Math.Sin(y * 0.12));
                int waveRight = (int)(10 * Math.Sin(y * 0.1));
                int width = 140 + WorldGen.genRand.Next(-10, 10);

                int leftBoundary = spawnX + waveLeft;
                int rightBoundary = leftBoundary + width + waveRight;

                for (int x = leftBoundary; x < rightBoundary; x++)
                {
                    RemoveTrees(x, y);

                    if (y < spawnY + 20 || WorldGen.genRand.Next(100) < 100 - ((y - (spawnY + 45)) * 0.9))
                    {
                        PlaceBiomeTile(x, y);
                    }
                }
            }
        }

        private void RemoveTrees(int x, int y)
        {
            if (Main.tile[x, y].TileType == TileID.Trees)
            {
                WorldGen.KillTile(x, y, noItem: true); //remove trees
            }
        }

        private void PlaceBiomeTile(int x, int y)
        {
            //makes sure it doesnt overlap cloud islands
            if (Main.tile[x, y].TileType != TileID.Cloud && Main.tile[x, y].TileType != TileID.RainCloud)
            {
                WorldGen.ReplaceTile(x, y, TileID.CrystalBlock, 0);
                WorldGen.ReplaceWall(x, y, WallID.Crystal);
            }
        }
    }
}