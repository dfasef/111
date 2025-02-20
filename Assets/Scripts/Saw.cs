using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform pointA;  // ���
    public Transform pointB;  // �յ�
    public float speed = 1.0f; // �ƶ��ٶ�

    [SerializeField]private float RotateSpeed = 1f; // ��ת�ٶ�
    void Update()
    {
        // ʹ��PingPong��0��1֮��ѭ��
        float time = Mathf.PingPong(Time.time * speed, 1);
        // ���Բ�ֵ���㵱ǰλ��
        transform.position = Vector2.Lerp(pointA.position, pointB.position, time);
        transform.Rotate(0, 0, 360 * RotateSpeed * Time.deltaTime); 
    }
}
