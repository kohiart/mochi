using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class ParticleSet2D : ParticleSet2DBase { }

    public class ParticleSet2DBase 
    {
        [Parameter("tuple[5000]", "particles", 1)]
        public virtual List<Particle2D> Particles { get; set; }
        [Parameter("bool", "dead", 2)]
        public virtual bool Dead { get; set; }
    }
}
