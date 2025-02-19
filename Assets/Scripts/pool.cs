using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    //�����


    //����
    public List<GameObject> list = new List<GameObject>();
    //��ϷԤ����
    public GameObject FirePrefab;
    //���������
    public int capacity = 10;

    //���󱣴浽�����
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
    //�Ӷ����ȡ��һ������
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

    //��ն����
    public void Clear()
    {
        list.Clear();
    }
}
