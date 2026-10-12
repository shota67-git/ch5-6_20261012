using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour
{
    GameObject hp;
    public TextMeshProUGUI showtext;
    float countTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("HP");
        Time.timeScale = 1;
    }
    public void DecreaseHP()
    {
        hp.GetComponent<Image>().fillAmount -= 0.1f;
    }
    public void ch5()
    {
        SceneManager.LoadScene("ch5");
    }
    public void ch6()
    {
        SceneManager.LoadScene("ch6_gameScene");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        countTime += Time.deltaTime;
        showtext.text = (30-countTime).ToString("F0");
        if(countTime >= 5)
        {
            Time.timeScale = 0;
            if (hp.GetComponent<Image>().fillAmount >= 0.6f)
            {
                showtext.text = "Pass!"; 
                if(Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("ch6_gameScene");
                }
            }
            else
            {
                showtext.text = "Fail!";
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("ch5");
                }
            }
        }          

    }
}
