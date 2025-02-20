using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Ground1Control : MonoBehaviour
{

    public float defaultSpeed = 2f; // 默认速度
    public float currentSpeed ; // 地面移动的速度
    public float boostedSpeed = 4f; // 加速后的速度

    public float zbj;
    public float xyy;

    

    public static Ground1Control Instance;
    void Awake()
    {
       Instance = this;
    }
    void Start()
    {
        currentSpeed=defaultSpeed;
    }
    
    
    void Update()
    {
        //if (PlayerControl.Instance.Die)
        //{
        //    return;
        //}
        //遍历背景，子物体
        foreach (Transform tran in transform)
        {
            //获取子物体的位置
            Vector3 pos = tran.position;
            //按照速度向左侧移动
            pos.x -= currentSpeed * Time.deltaTime;
            //判断是否超出屏幕
            if (pos.x < zbj)
            {
                //把图片移到最右侧
                pos.x += xyy;
            }
            //位置赋给子物体
            tran.position = pos;
        }


    }
    public void DataUpdate(float zb,float xy)
    {
        
        zbj = zb;
        xyy = xy;
    }
    
    public void BoostSpeed()
    {
        currentSpeed = boostedSpeed;
    }
    public void Boost2Speed()
    {
        currentSpeed = 1.5f*boostedSpeed;
    }

    // 恢复默认速度方法
    public void ResetSpeed()
    {
        currentSpeed = defaultSpeed;
    }

}  
   
   



