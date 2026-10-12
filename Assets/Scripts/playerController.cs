using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }        
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(rigid2D.velocity.x);
        if(speedx < maxWalkSpeed) rigid2D.AddForce(transform.right * key * walkForce);
        if (key != 0) transform.localScale = new Vector3(key*1.5f, 1.5f, 1.5f);
        animator.speed = speedx / 2.0f;
        if (transform.position.y < -5.8f) SceneManager.LoadScene("ch6_gameScene");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("EndScene");
    }   
}
