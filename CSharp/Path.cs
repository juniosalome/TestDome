/*
    Write a function that provides change directory (cd) function for an abstract file system.

    Notes:
    Root path is '/'.
    Path separator is '/'.
    Parent directory is addressable as "..".
    Directory names consist only of English alphabet letters (A-Z and a-z).
    The function should support both relative and absolute paths.
    The function will not be passed any invalid paths.
    Do not use built-in path-related functions.

    For example:
    Path path = new Path("/a/b/c/d");
    path.Cd("../x");
    Console.WriteLine(path.CurrentPath);
    should display '/a/b/c/x'. 
*/

using System;
using System.Collections.Generic;

public class Path
{
    public string CurrentPath { get; private set; }

    public Path(string path)
    {
        this.CurrentPath = path;
    }

    public void Cd(string newPath)
    {
        if (newPath.StartsWith("/"))
        {
            CurrentPath = newPath;
        }
        else if (newPath.Contains(".."))
        {
            var pathList = new LinkedList<string>(CurrentPath.Split('/')); 
            var newPathList = newPath.Split('/'); 
            foreach (var item in newPathList)
            {
                if (item == "..") 
                {
                    if (pathList.Count > 0)
                        pathList.RemoveLast();
                }
                else
                {
                    
                    pathList.AddLast(item);
                }
            }

            CurrentPath = string.Join("/", pathList); 
            if (!CurrentPath.StartsWith("/"))
                CurrentPath = "/" + CurrentPath; 
        }
        else
        {
            CurrentPath += "/" + newPath;
        }
    }

    public static void Main(string[] args)
    {
        var path = new Path("/a/b/c/d");
        path.Cd("../x");
        Console.WriteLine(path.CurrentPath); 
    }
}