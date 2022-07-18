using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class Particle2D : Particle2DBase { }

    public class Particle2DBase 
    {
        [Parameter("int64", "ox", 1)]
        public virtual long Ox { get; set; }
        [Parameter("int64", "oy", 2)]
        public virtual long Oy { get; set; }
        [Parameter("int64", "px", 3)]
        public virtual long Px { get; set; }
        [Parameter("int64", "py", 4)]
        public virtual long Py { get; set; }
        [Parameter("int64", "x", 5)]
        public virtual long X { get; set; }
        [Parameter("int64", "y", 6)]
        public virtual long Y { get; set; }
        [Parameter("int32", "frames", 7)]
        public virtual int Frames { get; set; }
        [Parameter("bool", "dead", 8)]
        public virtual bool Dead { get; set; }
        [Parameter("tuple", "force", 9)]
        public virtual Point2D Force { get; set; }
        [Parameter("int256", "_lifetime", 10)]
        public virtual BigInteger Lifetime { get; set; }
        [Parameter("int64", "_forceScale", 11)]
        public virtual long ForceScale { get; set; }
        [Parameter("int64", "_noiseScale", 12)]
        public virtual long NoiseScale { get; set; }
    }
}
