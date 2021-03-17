using System;
using System.Linq;

namespace FootballWorldCupScoreBoard.Facts.TestUtilities
{
    public static class TestUtilities
    {
        public static Guid ToGuid(this int value)
        {
            return new Guid(Enumerable.Repeat((byte)value, 16).ToArray());
        }
    }
}