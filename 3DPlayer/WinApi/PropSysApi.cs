﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf3DPlayer.WinApi
{
    public class PropSys
    {
        internal enum PROPDESC_RELATIVEDESCRIPTION_TYPE
        {
            PDRDT_GENERAL,
            PDRDT_DATE,
            PDRDT_SIZE,
            PDRDT_COUNT,
            PDRDT_REVISION,
            PDRDT_LENGTH,
            PDRDT_DURATION,
            PDRDT_SPEED,
            PDRDT_RATE,
            PDRDT_RATING,
            PDRDT_PRIORITY
        }

        //[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //internal static extern int PSGetNameFromPropertyKey(
        //     ref PropertyKey propkey,
        //     [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCanonicalName
        // );

        //[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //internal static extern HRESULT PSGetPropertyDescription(
        //    ref PropertyKey propkey,
        //    ref Guid riid,
        //    [Out, MarshalAs(UnmanagedType.Interface)] out IPropertyDescription ppv
        //);

        //[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //internal static extern int PSGetPropertyKeyFromName(
        //    [In, MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName,
        //    out PropertyKey propkey
        //);

    }
}
