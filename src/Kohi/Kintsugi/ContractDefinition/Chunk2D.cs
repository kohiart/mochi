using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Kohi.Kintsugi.ContractDefinition
{
    public partial class Chunk2D : Chunk2DBase { }

    public class Chunk2DBase 
    {
        [Parameter("uint16", "index", 1)]
        public virtual ushort Index { get; set; }
        [Parameter("uint16", "width", 2)]
        public virtual ushort Width { get; set; }
        [Parameter("uint16", "height", 3)]
        public virtual ushort Height { get; set; }
        [Parameter("uint16", "chunkWidth", 4)]
        public virtual ushort ChunkWidth { get; set; }
        [Parameter("uint16", "chunkHeight", 5)]
        public virtual ushort ChunkHeight { get; set; }
        [Parameter("uint32", "startX", 6)]
        public virtual uint StartX { get; set; }
        [Parameter("uint32", "startY", 7)]
        public virtual uint StartY { get; set; }
    }
}
