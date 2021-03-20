using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This is only needed so we can use C# 9.0 records on .NET Core 3.1. It can be removed when we upgrade to .NET 5.0 or (more likely) 6.0
/// TODO: When the time is right, delete this file.
/// </summary>
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}
