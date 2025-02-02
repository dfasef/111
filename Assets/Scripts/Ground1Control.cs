using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class Ground1Control : MonoBehaviour
{
    public float defaultSpeed = 2f; // Ĭ���ٶ�
    public float currentSpeed ; // �����ƶ����ٶ�
    public float boostedSpeed = 4f; // ���ٺ���ٶ�

    public GameObject GroundPrefabs;

    void Start()
    {
        currentSpeed=defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //����������������
        foreach (Transform tran in transform)
        {
            //��ȡ�������λ��
            Vector3 pos = tran.position;
            //�����ٶ�������ƶ�
            pos.x -= currentSpeed * Time.deltaTime;
            //�ж��Ƿ񳬳���Ļ
            if (pos.x < -200f)
            {
                //��ͼƬ�Ƶ����Ҳ�
                pos.x += 351.9f;
            }
            //λ�ø���������
            tran.position = pos;
        }


    }
    public void BoostSpeed()
    {
        currentSpeed = boostedSpeed;
    }

    // �ָ�Ĭ���ٶȷ���
    public void ResetSpeed()
    {
        currentSpeed = defaultSpeed;
    }

}  
   
   



