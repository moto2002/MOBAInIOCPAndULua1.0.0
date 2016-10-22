//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ResMgr
// FileName : ResBuilder
//
// Created by : maxiao (398117200@qq.com) at 2016/6/20 2:06:02
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 把Resource下的资源打包成AssetBundle并和lua文件一起输出到StreamingAssets目录下
/// </summary>
public class ResBuilder : MonoBehaviour
{
    private static Dictionary<string, int> assetReferenceDic = new Dictionary<string, int>();
    public static string resourcePath = Application.dataPath + "/Resources";
    private static string resourcesInfoFileName = "/resourcesInfo";
    static string AssetBundlesOutputPath = Application.streamingAssetsPath;
    private static TextAsset resourceInfo;
    private static List<string> pathsCache = new List<string>();
    private static List<string> filesCache = new List<string>();

    [MenuItem("AssetBundle/Build Current Platform Resources", false, 13)]
    public static void BuildAssetBundleByCurrentPlatform()
    {
        BuildAssetBundleByTarget(EditorUserBuildSettings.activeBuildTarget);
    }

    [MenuItem("AssetBundle/Build iOS Resources", false, 13)]
    public static void BuildIOSAssetBundle()
    {
        BuildAssetBundleByTarget(BuildTarget.iOS);
    }

    [MenuItem("AssetBundle/Build Android Resources", false, 13)]
    public static void BuildAndroidAssetBundle()
    {
        BuildAssetBundleByTarget(BuildTarget.Android);
    }

    [MenuItem("AssetBundle/Build Windows AssetBundle", false, 13)]
    public static void BuildWindowsAssetBundle()
    {
        BuildAssetBundleByTarget(BuildTarget.StandaloneWindows);
    }

    /// <summary>
    /// 根据不同的目标平台来打包
    /// </summary>
    /// <param name="buildTarget"></param>
    public static void BuildAssetBundleByTarget(BuildTarget buildTarget)
    {
        CreateAIncreaseVersionFile();

        string outputPath = Path.Combine(AssetBundlesOutputPath, Platform.GetPlatformFolder(buildTarget));
        if (Directory.Exists(outputPath))
        {
            Directory.Delete(outputPath, true);
        }
        Directory.CreateDirectory(outputPath);
        AssetDatabase.Refresh();



        //根据BuildSetting里面所激活的平台进行打包
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);


        //---------------复制lua文件---------------
        string luaBuildPath = outputPath + "/lua/";

        CopyFilesToDirectory(AppConst.luaSourcePath, luaBuildPath);
        Debug.Log("复制Lua文件完成");
        AssetDatabase.Refresh();
        //------------------------写AssetBundle映射文件------------
        GetAllAssetBundleNames();
        //------------------------创建文件列表----------------------
        CreateFileListForAPath(outputPath, AppConst.fileListTxtName);
        Debug.Log("创建文件列表完成");
        Debug.Log("打包完成");
    }

    /// <summary>
    /// 将所有AssetBundle和它们对应的assets写入一个索引文件
    /// 并将所有AssetBundle的依赖写入一个索引文件
    /// </summary>
    private static void GetAllAssetBundleNames()
    {
        //manifest的路径，注意不同平台的路径前缀是不一样的
        string url = AppConst.StreamingAssetPath + '/' + AppConst.platformFolderName + '/' + AppConst.platformFolderName;
        AssetBundle ab = AssetBundle.LoadFromFile(url);

        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        Debug.Log(manifest.name + "");
        string[] abs = manifest.GetAllAssetBundles();
        ab.Unload(false);

        string path = AppConst.StreamingAssetPath + '/' + AppConst.platformFolderName + "/Assets.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        FileStream fs = new FileStream(path, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (string str in abs)
        {
            Debug.Log(str);
            string abUrl = AppConst.StreamingAssetPath + '/' + AppConst.platformFolderName + '/' + str;
            AssetBundle subBundle = AssetBundle.LoadFromFile(abUrl);
            string[] assetNames = subBundle.GetAllAssetNames();
            foreach (string s in assetNames)
            {
                Debug.Log("assetName:" + s);
                sw.WriteLine(s + '|' + str);
            }
        }
        sw.Close();
        fs.Close();
        Debug.Log("创建asset和bundle之间的索引完成");

        string dependencyPath = AppConst.StreamingAssetPath + '/' + AppConst.platformFolderName + AppConst.assetBundleDependenciesFileName;
        if (File.Exists(dependencyPath))
        {
            File.Delete(dependencyPath);
        }
        FileStream fs2 = new FileStream(dependencyPath, FileMode.CreateNew);
        StreamWriter sw2 = new StreamWriter(fs2, Encoding.UTF8);

        foreach (string str in abs)
        {
            string[] dependencies = manifest.GetAllDependencies(str);
            string l = str;
            if (dependencies.Length > 0)
            {
                foreach (string s in dependencies)
                {
                    l = l + "|" + s;
                }
                sw2.WriteLine(l);
            }
        }
        sw2.Close();
        fs2.Close();
        Debug.Log("创建ab之间的依赖索引完成");
    }

    /// <summary>
    /// 创建一个递增的版本号
    /// </summary>
    private static void CreateAIncreaseVersionFile()
    {
        string versionFilePath = AssetBundlesOutputPath + AppConst.versionFileName;
        int mainVersion = 1;
        int subVersion = 0;
        int buildVersion = 0;
        int revisionVersion = 0;
        string fileListName = AppConst.fileListTxtName;
        if (File.Exists(versionFilePath))
        {
            FileStream vf = File.Open(versionFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(vf);
            string version = sr.ReadLine();
            string[] versions = version.Split('.');
            if (versions.Length == 4)
            {
                mainVersion = Convert.ToInt32(versions[0]);
                subVersion = Convert.ToInt32(versions[1]);
                buildVersion = Convert.ToInt32(versions[2]) + 1;
                revisionVersion = Convert.ToInt32(versions[3]);
            }
            else
            {
                Debug.Log("Some errors existed in Version File.");
            }

            sr.Close();
            vf.Close();

            File.Delete(versionFilePath);
        }

        FileStream fs = new FileStream(versionFilePath, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        string versionString = mainVersion.ToString() + '.' + subVersion + '.' + buildVersion + '.' + revisionVersion;
        sw.WriteLine(versionString);
        sw.WriteLine(fileListName);
        sw.Close();
        sw.Close();
        Debug.Log("Build a new version:" + versionString);
    }

    /// <summary>
    /// 为一个文件夹下的所有文件创建一个文件列表，存放每个文件的文件名和md5校验码，并将assetbundle放入一个列表
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="listName"></param>
    private static void CreateFileListForAPath(string filePath, string listName)
    {
        string newFilePath = filePath + listName;
        if (File.Exists(newFilePath))
            File.Delete(newFilePath);

        pathsCache.Clear();
        filesCache.Clear();
        RecursePaths(filePath);

        FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);


        for (int i = 0; i < filesCache.Count; i++)
        {
            string file = filesCache[i];
            if (file.EndsWith(".meta") || file.Contains(".DS_Store"))
                continue;

            string md5 = Util.md5file(file);
            string value = file.Replace(filePath.Replace('\\', '/') + '/', string.Empty);
            sw.WriteLine(value + "|" + md5);
        }

        sw.Close();
        fs.Close();
    }




    /// <summary>
    /// 将源文件夹的文件复制到目标文件夹 .meta文件除外
    /// </summary>
    /// <param name="sourcePath"></param>
    /// <param name="desPath"></param>
    private static void CopyFilesToDirectory(string sourcePath, string desPath)
    {
        if (!Directory.Exists(sourcePath))
        {
            Debug.Log("Resource path is not existed.");
            return;
        }
        if (Directory.Exists(desPath))
        {
            Directory.Delete(desPath, true);
        }
        Directory.CreateDirectory(desPath);

        pathsCache.Clear();
        filesCache.Clear();
        RecursePaths(sourcePath);

        foreach (string f in filesCache)
        {
            if (f.EndsWith(".meta"))
                continue;

            string newFileName = f.Replace(sourcePath, "");
            string newPath = desPath + newFileName;
            //得到此文件名的目录
            string path = Path.GetDirectoryName(newPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            File.Copy(f, newPath, true);
        }
    }

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

