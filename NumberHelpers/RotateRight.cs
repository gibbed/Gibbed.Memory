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

namespace Gibbed.Memory
{
    public static partial class NumberHelpers
    {
        public static sbyte RotateRight(this sbyte value, int count)
        {
            return (sbyte)((byte)value).RotateRight(count);
        }

        public static byte RotateRight(this byte value, int count)
        {
            return (byte)((value >> count) | (value << (8 - count)));
        }

        public static short RotateRight(this short value, int count)
        {
            return (short)((ushort)value).RotateRight(count);
        }

        public static ushort RotateRight(this ushort value, int count)
        {
            return (ushort)((value >> count) | (value << (16 - count)));
        }

        public static int RotateRight(this int value, int count)
        {
            return (int)((uint)value).RotateRight(count);
        }

        public static uint RotateRight(this uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }

        public static long RotateRight(this long value, int count)
        {
            return (long)((ulong)value).RotateRight(count);
        }

        public static ulong RotateRight(this ulong value, int count)
        {
            return (value >> count) | (value << (64 - count));
        }
    }
}
