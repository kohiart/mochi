using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class ParticleSetGroup2D : ParticleSetGroup2DBase { }

    public class ParticleSetGroup2DBase 
    {
        [Parameter("tuple[1]", "sets", 1)]
        public virtual List<ParticleSet2D> Sets { get; set; }
    }
}
