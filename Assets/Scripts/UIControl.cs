using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIControl : MonoBehaviour
{
    public Text Exit;
    public GameObject Middle;
    public GameObject Middle2;
   

    public static UIControl Instance;

    
    private void Awake()
   
    { 
        Instance = this;


    }

    void Start()
    {
        Middle.SetActive(false);
        Middle2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PlayerControl.Instance.Die)
        {
            Middle.SetActive(true);
        }
        
    }
   
    
   public void ButExit()
    {
        Application.Quit();
    }

    
    public void AgainBtn()
    {
        PlayerControl.Instance.Die = false;
        Middle.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        PlayerControl.Instance.can2jump = false;
        AudioManager.Instance.PlayAgain();
    }
    public void  Pause()
    {
        Time.timeScale = 0f;
        Middle2.SetActive(true);
        AudioManager.Instance.msPlayer.Pause();
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        Middle2.SetActive(false);
        AudioManager.Instance.msPlayer.UnPause();
        
    }
   
}
