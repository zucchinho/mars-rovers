using System;

namespace Nasa.MarsMission.Rovers.Core
{
    public interface IMover
    {
        int[] Move(int magnitude);
    }
}