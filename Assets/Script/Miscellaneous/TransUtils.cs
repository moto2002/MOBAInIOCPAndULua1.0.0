using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransUtils : MonoBehaviour {

    /// <summary>
    /// 获取传入对象的子物体
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject[] GetObjectChild(GameObject parent)
    {
        Transform tran = parent.transform;
        if (tran.childCount == 0)
            return null;
        GameObject[] objs = new GameObject[tran.childCount];
        for (int i = 0, L = tran.childCount; i < L; i++)
        {
            objs[i] = tran.GetChild(i).gameObject;
        }
        return objs;
    }
    /// <summary>
    /// 获取传入的对象名获取所有对象
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="names"></param>
    /// <returns></returns>
    public static Transform[] GetNameTransforms(GameObject parent, string[] names)
    {
        Transform t = parent.transform;
        List<Transform> trans = new List<Transform>();
        Transform[] AllClides = t.GetComponentsInChildren<Transform>(true);
        List<string> nameList = new List<string>();
        nameList.AddRange(names);
        for (int i = 0; i < AllClides.Length; i++)
        {
            for (int y = 0; y < nameList.Count; y++)
            {
                if (AllClides[i].name == nameList[y])
                {
                    trans.Add(AllClides[i]);
                    nameList.RemoveAt(y);
                    break;
                }
            }
            if (nameList.Count == 0)
                break;
        }
        return trans.ToArray();
    }
    /// <summary>
    /// 将两个trans的索引连接起来
    /// </summary>
    /// <param name="toSetTrans"></param>
    /// <param name="trans"></param>
    public static void SetTransform(Transform toSetTrans, Transform trans)
    {
        toSetTrans = trans;
    }
}
