using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BuildAssetRefFile : MonoBehaviour
{
    private static List<string> pathsCache = new List<string>();
    private static List<string> filesCache = new List<string>();
    private static List<string> abNames = new List<string>();





    /// <summary>
    /// 遍历一个路径下的所有子路径，并将文件加入文件名缓存列表，将路径加入路径名缓存列表
    /// </summary>
    /// <param name="parentPath"></param>
    private static void RecursePaths(string parentPath)
    {
        string[] names = Directory.GetFiles(parentPath);
        string[] dirs = Directory.GetDirectories(parentPath);
        foreach (string fileName in names)
        {
            if (fileName.EndsWith(".meta"))
                continue;


            filesCache.Add(fileName.Replace('\\', '/'));
        }

        foreach (string dir in dirs)
        {
            pathsCache.Add(dir.Replace('\\', '/'));
            //递归
            RecursePaths(dir);
        }
    }
}
