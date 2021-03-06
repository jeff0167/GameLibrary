using System;

namespace GameLibrary
{
    public struct Vector2
    {
        /// <summary>
        /// Vector2 is used like a direction and as a position
        /// </summary>
        public float x;
        public float y;

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return MathF.Sqrt(MathF.Pow(v2.x - v1.x,2) + MathF.Pow(v2.y - v1.y, 2));
        }
        public static Vector2 Normalize(Vector2 dir)
        {
            float x = MathF.Sqrt((dir.x * dir.x) + (dir.y * dir.y));
            return new Vector2((dir.x / x), dir.y / x);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }  
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(Vector2 v1, float multiplier)
        {
            return new Vector2(v1.x * multiplier, v1.y * multiplier);
        } 
        public static Vector2 operator *(float multiplier, Vector2 v1)
        {
            return new Vector2(v1.x * multiplier, v1.y * multiplier);
        }
        public static Vector2 operator /(Vector2 v1, float divider)
        {
            return new Vector2(v1.x / divider, v1.y / divider);
        } 
        public static Vector2 operator /(float divider, Vector2 v1)
        {
            return new Vector2(v1.x / divider, v1.y / divider);
        }
        public override string ToString()
        {
            return $"X: {x}, Y: {y}";
        }
    }
}
