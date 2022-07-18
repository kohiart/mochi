using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class KintsugiParameters : KintsugiParametersBase { }

    public class KintsugiParametersBase 
    {
        [Parameter("uint256", "particleRange", 1)]
        public virtual BigInteger ParticleRange { get; set; }
        [Parameter("int64", "particleForceScale", 2)]
        public virtual long ParticleForceScale { get; set; }
        [Parameter("int64", "particleNoiseScale", 3)]
        public virtual long ParticleNoiseScale { get; set; }
        [Parameter("uint32", "cutoff", 4)]
        public virtual uint Cutoff { get; set; }
        [Parameter("uint32", "layers", 5)]
        public virtual uint Layers { get; set; }
        [Parameter("tuple[]", "particleSets", 6)]
        public virtual List<ParticleSetGroup2D> ParticleSets { get; set; }
        [Parameter("uint32", "outerGold", 7)]
        public virtual uint OuterGold { get; set; }
        [Parameter("uint32", "innerGold", 8)]
        public virtual uint InnerGold { get; set; }
        [Parameter("uint256", "frame", 9)]
        public virtual BigInteger Frame { get; set; }
        [Parameter("uint256", "iteration", 10)]
        public virtual BigInteger Iteration { get; set; }
    }
}
