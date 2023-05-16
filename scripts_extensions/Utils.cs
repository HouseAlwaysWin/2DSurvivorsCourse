using Godot;
using System;
using System.Collections.Generic;

namespace ScriptsExtension
{
    public class Utils
    {
        public static float Randf()
        {
            Random rand = new Random();
            float randomFloat = (float)rand.NextDouble();
            return randomFloat;
        }
    }

}

