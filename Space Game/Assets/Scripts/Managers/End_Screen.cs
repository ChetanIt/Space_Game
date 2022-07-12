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

    public TextMeshProUGUI scoreDis, scoreAdd;
    public TextMeshProUGUI lev_dis, req_dis;

    int score;

    int cur_level, cur;
    //Score req for next level
    [SerializeField]
    int SRFNL = 50;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GE || !GE)
        {
            score = Player.Instance.cur_Score;
            GameHasEnded();
            scoreDis.text = "Score:" + score.ToString();
            scoreAdd.text = "Score:" + score.ToString();
            lev_dis.text = "Level " + cur_level;
            req_dis.text = score.ToString() + "/" + SRFNL.ToString();
        }

        if (SRFNL == cur ) cur_level += 1;
    }

    public void GameEnded()
    {
        GE = true;
    }

    void GameHasEnded()
    {
        menu.SetActive(GE);
        hud.SetActive(!GE);
        SRFNL = Mathf.FloorToInt(Mathf.Pow(cur_level, SRFNL));
        cur += score;
    }
}
