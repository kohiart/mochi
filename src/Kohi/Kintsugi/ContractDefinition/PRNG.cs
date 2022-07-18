using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class PRNG : PRNGBase { }

    public class PRNGBase 
    {
        [Parameter("int32[56]", "_seedArray", 1)]
        public virtual List<int> SeedArray { get; set; }
        [Parameter("int32", "_inext", 2)]
        public virtual int Inext { get; set; }
        [Parameter("int32", "_inextp", 3)]
        public virtual int Inextp { get; set; }
    }
}
