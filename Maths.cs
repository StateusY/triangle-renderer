using Rasterizer.Types;
namespace Rasterizer;

public static class Maths
{
    public static float Dot(float2 a, float2 b) => a.x * b.x + a.y * b.y;

    public static float2 Perpendicular(float2 vec) => new (vec.y, -vec.x);

    public static bool PointOnRightSideOfLine(float2 a, float2 b, float2 p)
    {
        float2 ap = p - a;
        float2 abPerp = Perpendicular(b - a);
        return Dot(ap, abPerp) >= 0;
    }

    public static bool PointInTriangle(float2 a, float2 b, float2 c, float2 p)
    {
        bool sideAB = PointOnRightSideOfLine(a, b, p);
        bool sideBC = PointOnRightSideOfLine(b, c, p);
        bool sideCA = PointOnRightSideOfLine(c, a, p);
        return sideAB == sideBC && sideBC == sideCA;
    }
}