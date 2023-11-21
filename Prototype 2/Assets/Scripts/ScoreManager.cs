using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int live;
    private static double score;
    // Start is called before the first frame update
    void Start()
    {
        live = 3;
        score = 0;
        Debug.Log("score : " + score + ", live : " + live);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void addScore()
    {
        if (live != 0)
        {
            ScoreManager.score += 1;
            Debug.Log("score : " + score);
        }
    }
    public static void addScore(int a)
    {
        if (live != 0)
        {
            ScoreManager.score += a;
            Debug.Log("score : " + score);
        }
    }
    public static void looseLive()
    {
        if( live != 0)
        {
            ScoreManager.live--;
            Debug.Log("live : " + live);
            if(live == 0)
            {
                Debug.Log("Game Over ... weh finally!");
            }
        }
        
        
    }
}
