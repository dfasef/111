using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBgControl : MonoBehaviour
{
    public float speed = 0.2f;

    void Update()
    {
        if (PlayerControl.Instance.Die)
        {
            return;
        }
       
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
