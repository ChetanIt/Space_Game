using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class End_Screen : MonoBehaviour
{
    //Game Ended
    bool GE;
    public static End_Screen instance;

    public GameObject menu, hud;

    public TextMeshProUGUI scoreDis,high_score_dis, scoreAdd;
    public TextMeshProUGUI lev_dis, req_dis, newt;

    int score;
    int cur_level, cur;

    bool done = false;
    //Score req for next level
   // [SerializeField]
   // int SRFNL = 50;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
       if(!done)  
        EndProcess();
    }

    void EndProcess()
    {
        score = Player.Instance.cur_Score;

        //Player has beaten his highscore
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            newt.gameObject.SetActive(true);
        }

        else newt.gameObject.SetActive(false);
                 
        high_score_dis.text = "highscore: " + PlayerPrefs.GetInt("Highscore", 0);

        done = true;
    }
}
