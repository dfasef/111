using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    //对象池


    //集合
    public List<GameObject> list = new List<GameObject>();
    //游戏预制体
    public GameObject FirePrefab;
    //对象池容量
    public int capacity = 10;

    //对象保存到对象池
    public void Push(GameObject fire)
    {
        if (list.Count < capacity)
        {
            list.Add(fire);
        }
        else
        {
            Destroy(fire);
        }
    }
    //从对象池取出一个对象
    public GameObject Pop()
    {
        if (list.Count > 0)
        {
            GameObject fire = list[0];
            list.RemoveAt(0);
            return fire;
        }
        return Instantiate(FirePrefab);
    }

    //清空对象池
    public void Clear()
    {
        list.Clear();
    }
}
