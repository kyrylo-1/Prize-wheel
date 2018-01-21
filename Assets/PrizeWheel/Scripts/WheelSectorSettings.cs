using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrizeWheel
{
    [Serializable]
    public class WheelSectorSettings : ScriptableObject
    {
        [SerializeField] private WheelSector[] wheelSectors;
        [SerializeField] private WheelSector[] wheelSectorsClockWise;

        public int SectorsQTY { get { return wheelSectors.Length; } }

        public WheelPrizes GetWheelPrize(int idSector, SpinDirections spinDir)
        {
            switch (spinDir)
            {
                case SpinDirections.Clockwise:
                    return wheelSectorsClockWise[idSector].PrizeType;

                case SpinDirections.AntiClockwise:
                    return wheelSectors[idSector].PrizeType;

                default:
                    return wheelSectors[idSector].PrizeType;
            }
        }


        [Serializable]
        public class WheelSector
        {
            [SerializeField] private WheelPrizes prizeType;
            public WheelPrizes PrizeType { get { return prizeType; } }
        }
    }
}