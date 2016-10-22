using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapUtils : MonoBehaviour,IEventListener
{
    [SerializeField]
    private Transform mapRoot;

    private Dictionary<int, Transform> mapNodes = new Dictionary<int, Transform>();

    private string currentMapName = "";

    void Start()
    {
        if (mapRoot == null)
        {
            mapRoot = GameObject.FindGameObjectWithTag("mapRoot").transform;
            if (mapRoot == null)
            {
                Debug.Log("场景中没有Map Root存在！");
            }
        }
    }

    public void BuildMapHierachyOfMapName(string mapName)
    {
        RecurseAllMapElements(mapRoot, mapName);
    }

    private void RecurseAllMapElements(Transform root, string mapName)
    {
        int childCount = root.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = root.GetChild(i);
            if (child.GetComponent<InfoNode>() == null)
            {
                Debug.Log("map元素:" + child.name + "没有挂载InfoNode脚本！");
            }
            else
            {
                InfoNode node = child.GetComponent<InfoNode>();
                if (!mapNodes.ContainsKey(node.GetNodeIdOfName(mapName)))
                {
                    mapNodes.Add(node.GetNodeIdOfName(mapName), child);
                }
                else
                {
                    Debug.Log("存在重复的MapNode,重复序号为：" + node.GetNodeIdOfName(mapName) + ",名字为：" + child.name);
                }
            }
            RecurseAllMapElements(child, mapName);
        }
    }
    /// <summary>
    /// 异步加载一个Map元素
    /// </summary>
    /// <param name="name"></param>
    public void LoadMapElement(string name, string mapName)
    {
        currentMapName = mapName;
        ResourceMgr.Instance.LoadAsync(name, this, null, false);
    }
    /// <summary>
    /// 同步加载一个map元素
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Object LoadMapElementSync(string name, string mapName)
    {
        currentMapName = mapName;
        return ResourceMgr.Instance.LoadSync(name, null, false);
    }
    /// <summary>
    /// 利用传入的map元素信息新建一个map元素，并根据信息对其初始化，再加入节点字典
    /// </summary>
    /// <param name="info"></param>
    public GameObject NewMapElement(Object obj)
    {
        GameObject go = (GameObject)Instantiate(obj);
        InfoNode node = go.GetComponent<InfoNode>();
        if (node == null)
        {
            Debug.Log("Map元素预设未挂载GameObjNodeInfo脚本,实例化失败！");
            Destroy(go);
            return null;
        }


        int parentId = node.GetParentIdOfName(currentMapName);
        if (parentId == 0)
        {
            go.transform.parent = mapRoot;
        }
        else
        {
            if (mapNodes.ContainsKey(parentId))
            {
                go.transform.parent = mapNodes[parentId];
            }
            else
            {
                Debug.Log("没有找到Map元素:" + go.name + "的父节点:" + parentId);
                Destroy(go);
                return null;
            }
        }

        if (!mapNodes.ContainsKey(node.GetNodeIdOfName(currentMapName)))
        {
            mapNodes.Add(node.GetNodeIdOfName(currentMapName), go.transform);
        }
        else
        {
            Debug.Log("Map中已存在相同的元素：" + go.name + "，请检查重复调用！");
            Destroy(go);
            return null;
        }

        RecurseAllMapElements(go.transform, currentMapName);

        GameObjInfo[] goInfos = go.GetComponents<GameObjInfo>();
        foreach (GameObjInfo info in goInfos)
        {
            if (info.IndexName == currentMapName)
            {
                info.SetGameObj();
                break;
            }
        }

        return go;
    }

    public int HandlePriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, params object[] args)
    {
        switch (id)
        {
            case EventDef.LoadAssetFinished:
                AssetInfo info = args[0] as AssetInfo;
                GameObject element = NewMapElement(info.asset);
                LuaScriptMgr.Instance.CallLuaFunction("mapElement_loaded", element);
                return false;
        }
        return false;
    }

}
