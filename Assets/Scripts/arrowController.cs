using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);
        //掉出畫面消失
        if (transform.position.y < -5.6f)
        {
            Destroy(gameObject);
        }

        //箭頭撞到貓咪消失
        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1f;
        if(d < r1 + r2)
        {
            Destroy(gameObject);
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<gameDirector>().DecreaseHP();
        }
    }
}
