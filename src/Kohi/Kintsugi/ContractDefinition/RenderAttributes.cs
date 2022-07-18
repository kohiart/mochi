using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class RenderAttributes : RenderAttributesBase { }

    public class RenderAttributesBase 
    {
        [Parameter("uint256", "seed", 1)]
        public virtual BigInteger Seed { get; set; }
        [Parameter("uint256", "nonce", 2)]
        public virtual BigInteger Nonce { get; set; }
        [Parameter("bytes32", "packed", 3)]
        public virtual byte[] Packed { get; set; }
        [Parameter("uint64", "epoch", 4)]
        public virtual ulong Epoch { get; set; }
    }
}
