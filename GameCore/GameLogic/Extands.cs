﻿using System;
using Proto;
using EngineCore;
using UMath;

namespace GameLogic
{
    public static class Extands
    {
        public static Vector3 ToV3(this UVector3 v3)
        {
            return new Vector3 { x = v3.x, y = v3.y,z =v3.z};
        }

        public static Vector3 ToV3(this Layout.Vector3 v3)
        {
            return new Vector3 { x = v3.x, y = v3.y, z = v3.z };
        }

        public static Vector3ShortIndex ToSV3(this UVector3 v3)
        {
            return new Vector3ShortIndex() { x = (byte)v3.x, y = (byte)v3.y, z = (byte)v3.z };
        }
    }
}

