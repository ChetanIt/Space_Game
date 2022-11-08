using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public float galaxy_Rad;
    public int segments;
    LineRenderer line;
<<<<<<< HEAD

    public GameObject main_menu, end_menu, pause_menu;
    public enum gameState { Playing, Paused, InMainMenu, InEndScreen}
    public gameState cur_game_state;

    public static Game_Manager instance;

    

    private void Awake()
    {
        instance = this;
    }
=======
>>>>>>> parent of 8ce7235 (P1j)

    private void Start()
    {
        gameObject.transform.localScale = new Vector2(galaxy_Rad * 2, galaxy_Rad * 2);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        PolygonCollider2D poly = gameObject.AddComponent<PolygonCollider2D>();
        Vector2[] pol_points = poly.points;
        Destroy(sr);
        Destroy(poly);
        EdgeCollider2D e = this.GetComponent<EdgeCollider2D>();
        pol_points[39] = pol_points[0];
        e.points = pol_points;
        Destroy(sr);
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = true;
        CreatePoints();
    }

    //To further comprehend code:https://forum.unity.com/threads/linerenderer-to-create-an-ellipse.74028/
    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * (galaxy_Rad + .1f);
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * (galaxy_Rad + .1f);

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, galaxy_Rad);
    }

<<<<<<< HEAD
    private void Update()
    {
        if (cur_game_state == gameState.Paused || cur_game_state == gameState.InEndScreen || cur_game_state == gameState.InMainMenu) Player.Instance.enabled = false;
        else if (cur_game_state == gameState.Playing) Player.Instance.enabled = true;
        if (main_menu.activeSelf) cur_game_state = gameState.InMainMenu;
        if (end_menu.activeSelf) cur_game_state = gameState.InEndScreen;
        else if (cur_game_state == gameState.InEndScreen) end_menu.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cur_game_state = gameState.Paused;
            pause_menu.SetActive(true);
        }

       
    }


    public void BtnClked(int btnId)
    {
        //MainMenu Buttons

        if (btnId == 1)
        {
            Debug.Log("Play Button was Clicked");
            cur_game_state = gameState.Playing;
            main_menu.SetActive(false);
            end_menu.SetActive(false);
        }

        if (btnId == 2)
        {
            Debug.Log("Settings Button was Clicked");
            cur_game_state = gameState.Paused;
        }

        if (btnId == 3)
        {
            Debug.Log("About Button was Clicked");
            cur_game_state = gameState.Paused;
        }

        if (btnId == 4)
        {
            Debug.Log("Quit Button was Clicked");
            Application.Quit();
        }

        //EndScreenButtons
        if (btnId == 5)
        {
            Debug.Log("Play Button was Clicked");
            cur_game_state = gameState.Playing;
            main_menu.SetActive(false);
            end_menu.SetActive(false);
        }

        if (btnId == 6)
        {
            Debug.Log("Settings Button was Clicked");
            cur_game_state = gameState.Paused;
        }
        if (btnId == 7)
        {
            Debug.Log("About Button was Clicked");
            cur_game_state = gameState.Paused;
        }

        if (btnId == 8)
        {
            Debug.Log("Quit Button was Clicked");
            Application.Quit();
        }

    }

=======
>>>>>>> parent of 8ce7235 (P1j)
}
