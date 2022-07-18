using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class Point2D : Point2DBase { }

    public class Point2DBase 
    {
        [Parameter("int256", "x", 1)]
        public virtual BigInteger X { get; set; }
        [Parameter("int256", "y", 2)]
        public virtual BigInteger Y { get; set; }
    }
}
