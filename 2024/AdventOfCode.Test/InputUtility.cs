using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode.Test;

public static class InputUtility
{
    public static Stream ReadInput(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        if (assembly == null)
        {
            throw new InvalidOperationException("Cannot get executing assembly");
        }

        var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            throw new InvalidOperationException($"Could not find resource of name '{resourceName}'");
        }

        return stream;
    }
}
