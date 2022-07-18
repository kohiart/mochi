using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class RenderArgs : RenderArgsBase { }

    public class RenderArgsBase 
    {
        [Parameter("int16", "index", 1)]
        public virtual short Index { get; set; }
        [Parameter("uint8", "stage", 2)]
        public virtual byte Stage { get; set; }
        [Parameter("int32", "seed", 3)]
        public virtual int Seed { get; set; }
        [Parameter("uint32[16384]", "buffer", 4)]
        public virtual List<uint> Buffer { get; set; }
        [Parameter("tuple", "prng", 5)]
        public virtual PRNG Prng { get; set; }
    }
}
