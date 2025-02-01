using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //如果产生触发


    private void OnTriggerEnter2D (Collider2D collision)
    {
        
       UIControl.Instance.AddScore();
       Destroy(gameObject);

    }
}
