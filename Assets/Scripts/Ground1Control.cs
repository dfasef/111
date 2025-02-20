using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Ground1Control : MonoBehaviour
{

    public float defaultSpeed = 2f; // Ĭ���ٶ�
    public float currentSpeed ; // �����ƶ����ٶ�
    public float boostedSpeed = 4f; // ���ٺ���ٶ�

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
        //����������������
        foreach (Transform tran in transform)
        {
            //��ȡ�������λ��
            Vector3 pos = tran.position;
            //�����ٶ�������ƶ�
            pos.x -= currentSpeed * Time.deltaTime;
            //�ж��Ƿ񳬳���Ļ
            if (pos.x < zbj)
            {
                //��ͼƬ�Ƶ����Ҳ�
                pos.x += xyy;
            }
            //λ�ø���������
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

    // �ָ�Ĭ���ٶȷ���
    public void ResetSpeed()
    {
        currentSpeed = defaultSpeed;
    }

}  
   
   



