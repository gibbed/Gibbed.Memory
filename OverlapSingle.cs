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

using System.Runtime.InteropServices;

namespace Gibbed.Memory
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct OverlapSingle
    {
        [FieldOffset(0)]
        private float _F;

        [FieldOffset(0)]
        private uint _U;

        public OverlapSingle(float f)
        {
            this._U = default;
            this._F = f;
        }

        public OverlapSingle(uint u)
        {
            this._F = default;
            this._U = u;
        }

        public float AsF
        {
            readonly get => this._F;
            set => this._F = value;
        }

        public uint AsU
        {
            readonly get => this._U;
            set => this._U = value;
        }
    }
}
