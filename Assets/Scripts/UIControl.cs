using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIControl : MonoBehaviour
{
    public Text Exit;
    public TextMeshProUGUI txtScore;
    private int score;
    public GameObject LeftTop;
    public GameObject Middle;
    public GameObject Middle2;
    public TextMeshProUGUI txtLastScore;
    public TextMeshProUGUI txtPauseScore;

    public static UIControl Instance;


    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        LeftTop.SetActive(true);
        Middle.SetActive(false);
        Middle2.SetActive(false);

        score = 0;
        txtScore.text = string.Format("{0}", score);
    }

    // Update is called once per frame
    void Update()
    {
        MiddleUI();
        if (PlayerControl.Instance.Die)
        {
            Middle.SetActive(true);
        }
        
    }
   
    void MiddleUI()
    {
        txtPauseScore.text = string.Format("{0}", score);
        txtLastScore.text = string.Format("{0}", score);
    }
   public void ButExit()
    {
        Application.Quit();
    }

    public void AddScore()
    {
        score++;
        txtScore.text = string.Format("{0}", score);
        
       
    }
    public void AgainBtn()
    {
        PlayerControl.Instance.Die = false;
        LeftTop.SetActive(true);
        Middle.SetActive(false);
        score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
