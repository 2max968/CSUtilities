using System.Runtime.InteropServices;

namespace Utilities
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Union32
    {
        [FieldOffset(0)] public byte uint8_1;
        [FieldOffset(1)] public byte uint8_2;
        [FieldOffset(2)] public byte uint8_3;
        [FieldOffset(3)] public byte uint8_4;
        [FieldOffset(0)] public ushort uint16_1;
        [FieldOffset(2)] public ushort uint16_2;
        [FieldOffset(0)] public uint uint32;

        [FieldOffset(0)] public sbyte int8_1;
        [FieldOffset(1)] public sbyte int8_2;
        [FieldOffset(2)] public sbyte int8_3;
        [FieldOffset(3)] public sbyte int8_4;
        [FieldOffset(0)] public short int16_1;
        [FieldOffset(2)] public short int16_2;
        [FieldOffset(0)] public int int32;

        [FieldOffset(0)] public float float32;

        public Union32(ushort uint16_1, ushort uint16_2)
            : this()
        {
            this.uint16_1 = uint16_1;
            this.uint16_2 = uint16_2;
        }

        public Union32(uint uint32)
            : this()
        {
            this.uint32 = uint32;
        }

        public Union32(float float32)
            : this()
        {
            this.float32 = float32;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Union64
    {
        [FieldOffset(0)] public byte uint8_1;
        [FieldOffset(1)] public byte uint8_2;
        [FieldOffset(2)] public byte uint8_3;
        [FieldOffset(3)] public byte uint8_4;
        [FieldOffset(4)] public byte uint8_5;
        [FieldOffset(5)] public byte uint8_6;
        [FieldOffset(6)] public byte uint8_7;
        [FieldOffset(7)] public byte uint8_8;
        [FieldOffset(0)] public ushort uint16_1;
        [FieldOffset(2)] public ushort uint16_2;
        [FieldOffset(4)] public ushort uint16_3;
        [FieldOffset(6)] public ushort uint16_4;
        [FieldOffset(0)] public uint uint32_1;
        [FieldOffset(4)] public uint uint32_2;

        [FieldOffset(0)] public sbyte int8_1;
        [FieldOffset(1)] public sbyte int8_2;
        [FieldOffset(2)] public sbyte int8_3;
        [FieldOffset(3)] public sbyte int8_4;
        [FieldOffset(4)] public sbyte int8_5;
        [FieldOffset(5)] public sbyte int8_6;
        [FieldOffset(6)] public sbyte int8_7;
        [FieldOffset(7)] public sbyte int8_8;
        [FieldOffset(0)] public short int16_1;
        [FieldOffset(2)] public short int16_2;
        [FieldOffset(4)] public short int16_3;
        [FieldOffset(6)] public short int16_4;
        [FieldOffset(0)] public int int32_1;
        [FieldOffset(4)] public int int32_2;

        [FieldOffset(0)] public float float32_1;
        [FieldOffset(4)] public float float32_2;
        [FieldOffset(0)] public double float64;
    }
}
