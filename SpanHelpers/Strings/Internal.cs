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
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Gibbed.Memory
{
    public static partial class SpanHelpers
    {
        internal unsafe static string ReadStringInternalStatic(
            this ReadOnlySpan<byte> span,
            ref int index,
            int size,
            Encoding encoding,
            bool trailingNull)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            if (size == 0)
            {
                return string.Empty;
            }

            string value;

            var slice = span.Slice(index, size);
            fixed (byte* buffer = slice)
            {
                value = encoding.GetString(buffer, size);
            }
            index += size;

            if (trailingNull == true)
            {
                var position = value.IndexOf('\0');
                if (position >= 0)
                {
                    value = value.Substring(0, position);
                }
            }

            return value;
        }

        internal unsafe static string ReadStringInternalDynamic(
            this ReadOnlySpan<byte> span,
            ref int index,
            char end,
            Encoding encoding)
        {
            int characterSize = encoding.GetByteCount("e");
            Debug.Assert(characterSize == 1 || characterSize == 2 || characterSize == 4);
            ReadOnlySpan<byte> endSpan = new(encoding.GetBytes(end.ToString(CultureInfo.InvariantCulture)));

            int length = 0;
            while (true)
            {
                var slice = span.Slice(index + length, characterSize);
                if (MemoryExtensions.SequenceEqual(slice, endSpan) == true)
                {
                    break;
                }
                length += characterSize;
            }

            if (length == 0)
            {
                return string.Empty;
            }

            string value;
            fixed (byte* buffer = span.Slice(index, length))
            {
                value = encoding.GetString(buffer, length);
            }
            index += length;
            return value;
        }
    }
}
