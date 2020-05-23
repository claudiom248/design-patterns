﻿using Microsoft.Extensions.FileProviders;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility
{
    public static class FileProviderExtensions
    {
        public static string GetCombinedPath(this IFileProvider fileProvider, string path) => fileProvider.GetFileInfo(path).PhysicalPath;
    }
}
