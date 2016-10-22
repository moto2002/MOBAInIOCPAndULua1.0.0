using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 此脚本用于非友方单位的可视处理
/// 默认挂载，初始化数据的时候　友方单位移除
/// </summary>
public class EnemyEye : MonoBehaviour {
    private List<GameObject> list = new List<GameObject>();

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "enemyHero" || other.gameObject.tag == "enemySoldier" || other.gameObject.tag == "enemyBuild")
        {
            SetGameObjToVisible(other.gameObject);
            list.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other) {
        if (list.Contains(other.gameObject))
        {
            SetGameObjToInvisible(other.gameObject);
            list.Remove(other.gameObject);
        }
    }

    void SetGameObjToVisible(GameObject o)
    {
        if (o.layer != LayerMask.NameToLayer("visible"))
        {
            o.layer = LayerMask.NameToLayer("visible");
        }
    }

    void SetGameObjToInvisible(GameObject o)
    {
        if (o.layer != LayerMask.NameToLayer("invisible"))
        {
            o.layer = LayerMask.NameToLayer("invisible");
        }
    }

    void OnDestroy()
    {
        list.Clear();
    }

    public Transform GetNearestFrontTarget()
    {
        List<Transform> frontTransforms = new List<Transform>();

        for (int i = 0; i < list.Count; i++)
        {
            if (IsInFront(list[i].transform, transform))
            {
                frontTransforms.Add(list[i].transform);
            }
        }

        Transform t = null;
        float distane = 0;
        for (int j = 0; j < frontTransforms.Count; j++)
        {
            float d = Vector3.Distance(transform.position, frontTransforms[j].position);
            if (d > distane)
            {
                distane = d;
                t = frontTransforms[j];
            }
        }

        return t;
    }

    bool IsInFront(Transform testGo, Transform target)
    {
        return Vector3.Dot(testGo.forward, target.position - testGo.position) > 0;
    }
}
