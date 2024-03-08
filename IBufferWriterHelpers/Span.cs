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

using System;
using System.Buffers;

namespace Gibbed.Memory
{
    public static partial class IBufferWriterHelpers
    {
        public static void WriteBytes(this IBufferWriter<byte> writer, byte[] buffer)
        {
            ReadOnlySpan<byte> span = new(buffer);
            writer.Write(span);
        }

        public static void WriteBytes(this IBufferWriter<byte> writer, byte[] buffer, int index, int count)
        {
            ReadOnlySpan<byte> span = new(buffer, index, count);
            writer.Write(span);
        }
    }
}
