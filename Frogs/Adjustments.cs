using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public static class Adjustments
    {
        public static int JumpHeight = 150; // pixels
        public static int Ground = 430; // pixels
        public static int CircleRadius = 3; // pixels

        public static int JumpAngle = 70; // degrees
        public static int JumpVelocity = 23; // pixels per second
        public static int GravityAcceleration = 40; // pixels per second*second

        public static int TongueOffsetX = 43; // pixels
        public static int TongueOffsetY = 12; // pixels

        public static int FrogTextOffsetX = 3; // pixels
        public static int FrogTextOffsetY = -30; // pixels
        public static int FrogTextDuration = 60; // frames

        public static int FlyNumberLimit = 15; // number of flies
        public static int FlySpawnIntervalSingle = 2500; // milliseconds
        public static int FlySpawnIntervalMulti = 2000; // milliseconds
        public static double FlySpawnIntervalDecrease = 0.0001; // ratio

        public static int FlyLifetime = 30; // seconds
        public static int DeadStateDuration = 6; // frames
        public static int MaxAmplitude = 500; // pixels
        public static int MinAmplitude = 10; // pixels
        public static int MaxSpeed = 280; // pixels per seconds
        public static int MinSpeed = 150; // pixels per seconds
        public static int MaxFrequency = 5; // hz
        public static int MinFrequency = 1; // hz
        public static int MaxPosXL = -50; // position pixels
        public static int MinPosXL = -150; // position pixels
        public static int MaxPosXR = 1225; // position pixels
        public static int MinposXR = 1125; // position pixels
        public static int MaxPosY = 380; // position pixels
        public static int MinPosY = 80; // position pixels

        public static int NormalFlyPoints = 100; // points
        public static int WaspPoints = -150; // points
        public static int GoldenFlyPoints = 300; // points
        public static int DragonFlyPoints = 150; // points

        public static int NormalFlyRadius = 5; // pixels
        public static int WaspRadius = 7; // pixels
        public static int GoldenFlyRadius = 8; // pixels
        public static int DragonFlyRadius = 7; // pixels
    }
}
