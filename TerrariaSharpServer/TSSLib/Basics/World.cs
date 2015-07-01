using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TSSLib.Basics
{
    public class World
    {
        private Config.ConfigFile config;

        #region Variables
        double time;
        bool dayTime, bloodMoon, eclipse;
        int moonPhase;
        int maxTilesX;
        int maxTilesY;
        int spawnTileX;
        int spawnTileY;
        double worldSurface;
        double rockLayer;
        int worldID;
        string worldName;
        int moonType;
        int bg0, bg1, bg2, bg3, bg4, bg5, bg6, bg7;
        int iceBackStyle;
        int jungleBackStyle;
        int hellBackStyle;
        Single windSpeedSet;
        int numClouds;
        int treeX0, treeX1, treeX2;
        int treeStyle0, treeStyle1, treeStyle2, treeStyle3;
        int caveBackX0, caveBackX1, caveBackX2;
        int caveBackStyle0, caveBackStyle1, caveBackStyle2, caveBackStyle3;
        Single maxRaining;
        bool raining;
        bool shadowOrbSmashed, downedBoss1, downedBoss2, downedBoss3,
            hardMode, downedClown, ServerSideCharacter, downedPlantBoss;
        bool downedMechBoss1, downedMechBoss2, downedMechBoss3, 
            downedMechBossAny, crimson, pumpkinMoon, snowMoon;
        float cloudBGActive;
        #endregion

        public World(string name)
        {
            config = new Config.ConfigFile(name + "/" + name + ".tssc");
        }

        public void Load()
        {
            config.Load();
            time = Convert.ToDouble(config.GetData("time"));
            dayTime = Convert.ToBoolean(config.GetData("dayTime"));
            bloodMoon = Convert.ToBoolean(config.GetData("bloodMoon"));
            eclipse = Convert.ToBoolean(config.GetData("eclipse"));
            moonPhase = Convert.ToInt32(config.GetData("moonPhase"));
            maxTilesX = Convert.ToInt32(config.GetData("maxTilesX"));
            maxTilesY = Convert.ToInt32(config.GetData("maxTilesY"));
            spawnTileX = Convert.ToInt32(config.GetData("spawnTileX"));
            spawnTileY = Convert.ToInt32(config.GetData("spawnTileY"));
            worldSurface = Convert.ToDouble(config.GetData("worldSurface"));
            rockLayer = Convert.ToDouble(config.GetData("rockLayer"));
            worldID = Convert.ToInt32(config.GetData("worldID"));
            worldName = config.GetData("worldName");
            moonType = Convert.ToInt32(config.GetData("moonType"));
            bg0 = Convert.ToInt32(config.GetData("bg0"));
            bg1 = Convert.ToInt32(config.GetData("bg1"));
            bg2 = Convert.ToInt32(config.GetData("bg2"));
            bg3 = Convert.ToInt32(config.GetData("bg3"));
            bg4 = Convert.ToInt32(config.GetData("bg4"));
            bg5 = Convert.ToInt32(config.GetData("bg5"));
            bg6 = Convert.ToInt32(config.GetData("bg6"));
            bg7 = Convert.ToInt32(config.GetData("bg7"));
            iceBackStyle = Convert.ToInt32(config.GetData("iceBackStyle"));
            jungleBackStyle = Convert.ToInt32(config.GetData("jungleBackStyle"));
            hellBackStyle = Convert.ToInt32(config.GetData("hellBackStyle"));
            windSpeedSet = Convert.ToSingle(config.GetData("windSpeedSet"));
            numClouds = Convert.ToInt32(config.GetData("numClouds"));
            treeX0 = Convert.ToInt32(config.GetData("treeX0"));
            treeX1 = Convert.ToInt32(config.GetData("treeX1"));
            treeX2 = Convert.ToInt32(config.GetData("treeX2"));
            treeStyle0 = Convert.ToInt32(config.GetData("treeStyle0"));
            treeStyle1 = Convert.ToInt32(config.GetData("treeStyle1"));
            treeStyle2 = Convert.ToInt32(config.GetData("treeStyle2"));
            treeStyle3 = Convert.ToInt32(config.GetData("treeStyle3"));
            caveBackX0 = Convert.ToInt32(config.GetData("caveBackX0"));
            caveBackX1 = Convert.ToInt32(config.GetData("caveBackX1"));
            caveBackX2 = Convert.ToInt32(config.GetData("caveBackX2"));
            caveBackStyle0 = Convert.ToInt32(config.GetData("caveBackStyle0"));
            caveBackStyle1 = Convert.ToInt32(config.GetData("caveBackStyle1"));
            caveBackStyle2 = Convert.ToInt32(config.GetData("caveBackStyle2"));
            caveBackStyle3 = Convert.ToInt32(config.GetData("caveBackStyle3"));
            maxRaining = Convert.ToSingle(config.GetData("maxRaining"));
            raining = (maxRaining > 0f);
            shadowOrbSmashed = Convert.ToBoolean(config.GetData("shadowOrbSmashed"));
            downedBoss1 = Convert.ToBoolean(config.GetData("downedBoss1"));
            downedBoss2 = Convert.ToBoolean(config.GetData("downedBoss2"));
            downedBoss3 = Convert.ToBoolean(config.GetData("downedBoss3"));
            hardMode = Convert.ToBoolean(config.GetData("hardMode"));
            downedClown = Convert.ToBoolean(config.GetData("downedClown"));
            ServerSideCharacter = Convert.ToBoolean(config.GetData("ServerSideCharacter"));
            downedPlantBoss = Convert.ToBoolean(config.GetData("downedPlantBoss"));
            downedMechBoss1 = Convert.ToBoolean(config.GetData("downedMechBoss1"));
            downedMechBoss2 = Convert.ToBoolean(config.GetData("downedMechBoss2"));
            downedMechBoss3 = Convert.ToBoolean(config.GetData("downedMechBoss3"));
            downedMechBossAny = Convert.ToBoolean(config.GetData("downedMechBossAny"));
            cloudBGActive = Convert.ToSingle(config.GetData("cloudBGActive"));
            crimson = Convert.ToBoolean(config.GetData("crimson"));
            pumpkinMoon = Convert.ToBoolean(config.GetData("pumpkinMoon"));
            snowMoon = Convert.ToBoolean(config.GetData("snowMoon"));
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[256];
            using (MemoryStream ms = new MemoryStream(result))
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write((Int32)time);
                    BitsByte bb1 = new BitsByte(dayTime, bloodMoon, eclipse);
                    bw.Write((byte)bb1);
                    bw.Write((byte)moonPhase);
                    bw.Write((Int16)maxTilesX);
                    bw.Write((Int16)maxTilesY);
                    bw.Write((Int16)spawnTileX);
                    bw.Write((Int16)spawnTileY);
                    bw.Write((Int16)worldSurface);
                    bw.Write((Int16)rockLayer);
                    bw.Write((Int32)worldID);
                    bw.Write(worldName);
                    bw.Write((byte)moonType);
                    bw.Write((byte)bg0);
                    bw.Write((byte)bg1);
                    bw.Write((byte)bg2);
                    bw.Write((byte)bg3);
                    bw.Write((byte)bg4);
                    bw.Write((byte)bg5);
                    bw.Write((byte)bg6);
                    bw.Write((byte)bg7);
                    bw.Write((byte)iceBackStyle);
                    bw.Write((byte)jungleBackStyle);
                    bw.Write((byte)hellBackStyle);
                    bw.Write(windSpeedSet);
                    bw.Write((byte)numClouds);
                    bw.Write((Int32)treeX0);
                    bw.Write((Int32)treeX1);
                    bw.Write((Int32)treeX2);
                    bw.Write((Int32)treeStyle0);
                    bw.Write((Int32)treeStyle1);
                    bw.Write((Int32)treeStyle2);
                    bw.Write((Int32)treeStyle3);
                    bw.Write((Int32)caveBackX0);
                    bw.Write((Int32)caveBackX1);
                    bw.Write((Int32)caveBackX2);
                    bw.Write((Int32)caveBackStyle0);
                    bw.Write((Int32)caveBackStyle1);
                    bw.Write((Int32)caveBackStyle2);
                    bw.Write((Int32)caveBackStyle3);
                    bw.Write(maxRaining);
                    BitsByte bb2 = new BitsByte(downedBoss1, downedBoss2, downedBoss3,
                        hardMode, downedClown, ServerSideCharacter, downedPlantBoss);
                    bw.Write((byte)bb2);
                    BitsByte bb3 = new BitsByte(downedMechBoss1, downedMechBoss2, downedMechBoss3,
                        downedMechBossAny, Convert.ToBoolean(cloudBGActive), crimson, pumpkinMoon, snowMoon);
                    bw.Write((byte)bb3);
                    Array.Resize(ref result, (int)(bw.BaseStream.Position - 1));
                }
            }
            return result;
        }
    }
}
