using System;

namespace GameLibrary
{
    public struct Vector2
    {
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
        public static Vector2 operator /(Vector2 v1, float divider)
        {
            return new Vector2(v1.x / divider, v1.y / divider);
        }
        public override string ToString()
        {
            return $"X: {x}, Y: {y}";
        }
    }
}
