using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GroundControl : MonoBehaviour
{
    //速度
    public static float speed = 5f;
    //要随机的地面数组
    public GameObject GroundPrefabs;

    void Update()
    {

        //遍历背景，子物体
        foreach (Transform tran in transform)
        {
            //获取子物体的位置
            Vector3 pos = tran.position;
            //按照速度向左侧移动
            pos.x -= speed * Time.deltaTime;
            //判断是否超出屏幕
            if (pos.x < -10f)
            {
                //把图片移到最右侧
                pos.x += 114f;
            }
            //位置赋给子物体
            tran.position = pos;
        }

    }
    

   
}