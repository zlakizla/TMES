using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECSCore
{
    /// <summary>
    /// Indicates that class represents container for several elements.
    /// </summary>
    public interface IExplodable
    {
        ICollection<Element> Content { get; set; }

        void Explode(IExploder Exploder);
    }
}
