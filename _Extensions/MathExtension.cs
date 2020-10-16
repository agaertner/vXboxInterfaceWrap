using System;

namespace vXboxInterfaceWrap
{
    internal static class MathExtension
    {
        internal static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            if(val.CompareTo(max) > 0) return max;
            return val;
        }
    }
}