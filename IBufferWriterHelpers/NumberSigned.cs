/* Copyright (c) 2024 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.Buffers;

namespace Gibbed.Memory
{
    public static partial class SpanHelpers
    {
        public static void WriteValueS8(this IBufferWriter<byte> writer, sbyte value)
        {
            const int size = 1;
            writer.GetSpan(size)[0] = (byte)value;
            writer.Advance(size);
        }

        public static void WriteValueS16(this IBufferWriter<byte> writer, short value, Endian endian)
        {
            const int size = 2;
            writer.GetSpan(size).PackUnsafe(endian.ShouldSwap() == false ? value : value.Swap());
            writer.Advance(size);
        }

        public static void WriteValueS32(this IBufferWriter<byte> writer, int value, Endian endian)
        {
            const int size = 4;
            writer.GetSpan(size).PackUnsafe(endian.ShouldSwap() == false ? value : value.Swap());
            writer.Advance(size);
        }

        public static void WriteValueS64(this IBufferWriter<byte> writer, long value, Endian endian)
        {
            const int size = 8;
            writer.GetSpan(size).PackUnsafe(endian.ShouldSwap() == false ? value : value.Swap());
            writer.Advance(size);
        }
    }
}
