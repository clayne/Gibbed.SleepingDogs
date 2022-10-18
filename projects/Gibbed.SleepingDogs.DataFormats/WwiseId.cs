﻿/* Copyright (c) 2022 Rick (rick 'at' gibbed 'dot' us)
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
using System.IO;
using Gibbed.IO;

namespace Gibbed.SleepingDogs.DataFormats
{
    public struct WwiseId : IEquatable<WwiseId>
    {
        public readonly uint Id;

        public WwiseId(uint id)
        {
            this.Id = id;
        }

        public static WwiseId Read(Stream input, Endian endian)
        {
            var id = input.ReadValueU32(endian);
            return new WwiseId(id);
        }

        public static void Write(WwiseId instance, Stream output, Endian endian)
        {
            output.WriteValueU32(instance.Id, endian);
        }

        public void Write(Stream output, Endian endian)
        {
            Write(this, output, endian);
        }

        public static explicit operator uint(WwiseId symbol)
        {
            return symbol.Id;
        }

        public bool Equals(WwiseId other)
        {
            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null == true)
            {
                return false;
            }

            return obj is WwiseId id && Equals(id) == true;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(WwiseId a, WwiseId b)
        {
            return a.Equals(b) == true;
        }

        public static bool operator !=(WwiseId a, WwiseId b)
        {
            return a.Equals(b) == false;
        }
    }
}
