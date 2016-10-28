// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Internal.Cryptography
{
    internal static class SecureStringHelpers
    {
        internal static IntPtr PasswordToGlobalAllocUnicode(object password)
        {
            if (password != null)
            {
                string pwd = password as string;
                if (pwd != null)
                    return Marshal.StringToHGlobalUni(pwd);

                SecureString secureString = password as SecureString;
                if (secureString != null)
                    return SecureStringMarshal.SecureStringToGlobalAllocUnicode(secureString);
            }
            return IntPtr.Zero;
        }
    }
}
