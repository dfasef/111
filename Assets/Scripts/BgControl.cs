using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //速度
    public float speed = 0.2f;


    void Update()
    {
        if (PlayerControl.Instance.Die)
        {
            return;
        }
        
        //遍历背景，子物体
        foreach (Transform tran in transform)
        {
            //获取子物体的位置
            Vector3 pos = tran.position;
            //按照速度向左侧移动
            pos.x -= speed * Time.deltaTime;
            //判断是否超出屏幕
            if(pos.x < -8.32f)
            {
                //把图片移到最右侧
                pos.x +=64.81f;
            }
            //位置赋给子物体
            tran.position = pos;
        }
    }
}
