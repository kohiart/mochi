using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class RenderResults : RenderResultsBase { }

    public class RenderResultsBase 
    {
        [Parameter("uint32[16384]", "buffer", 1)]
        public virtual List<uint> Buffer { get; set; }
        [Parameter("tuple", "prng", 2)]
        public virtual PRNG Prng { get; set; }
    }
}
