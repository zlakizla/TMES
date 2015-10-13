using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECSCore
{
    /// <summary>
    /// Class that knows how to unwrap container with elements
    /// </summary>
    public interface IExploder
    {
        void Explode(IExplodable Target);
    }
}
