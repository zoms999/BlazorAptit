#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit
{
    public static class FileUtil
    {
        public async static Task SaveAs(IJSRuntime js, string data)
        {
#pragma warning disable CA1305 // Specify IFormatProvider
            _ = await js.InvokeAsync<object>("sfBlazorSB.saveDiagram", Convert.ToString(data)).ConfigureAwait(false);
#pragma warning restore CA1305 // Specify IFormatProvider
        }
        public async static Task Click(IJSRuntime js)
        {
            await js.InvokeAsync<object>("sfBlazorSB.uploadFilesClick").ConfigureAwait(false);
        }
        public async static Task<string> LoadFile(IJSRuntime js, object data)
        {
            return await js.InvokeAsync<string>("sfBlazorSB.loadFile", data).ConfigureAwait(false);
        }
    }
}
