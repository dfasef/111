using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform pointA;  // 起点
    public Transform pointB;  // 终点
    public float speed = 1.0f; // 移动速度

    [SerializeField]private float RotateSpeed = 1f; // 旋转速度
    void Update()
    {
        // 使用PingPong在0到1之间循环
        float time = Mathf.PingPong(Time.time * speed, 1);
        // 线性插值计算当前位置
        transform.position = Vector2.Lerp(pointA.position, pointB.position, time);
        transform.Rotate(0, 0, 360 * RotateSpeed * Time.deltaTime); 
    }
}
