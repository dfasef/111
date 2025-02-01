using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GroundControl : MonoBehaviour
{
    //�ٶ�
    public static float speed = 5f;
    //Ҫ����ĵ�������
    public GameObject GroundPrefabs;

    void Update()
    {

        //����������������
        foreach (Transform tran in transform)
        {
            //��ȡ�������λ��
            Vector3 pos = tran.position;
            //�����ٶ�������ƶ�
            pos.x -= speed * Time.deltaTime;
            //�ж��Ƿ񳬳���Ļ
            if (pos.x < -10f)
            {
                //��ͼƬ�Ƶ����Ҳ�
                pos.x += 114f;
            }
            //λ�ø���������
            tran.position = pos;
        }

    }
    

   
}