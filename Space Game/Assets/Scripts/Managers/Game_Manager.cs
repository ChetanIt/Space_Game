using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public float galaxy_Rad;
    public int segments;
    LineRenderer line;

    private void Awake()
    {
        gameObject.transform.localScale = new Vector2(galaxy_Rad * 2, galaxy_Rad * 2);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        gameObject.AddComponent<PolygonCollider2D>();
        Vector2[] pol_points = GetComponent<PolygonCollider2D>().points;
        Destroy(sr);
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<EdgeCollider2D>().points = pol_points;
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
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * galaxy_Rad;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * galaxy_Rad;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, galaxy_Rad);
    }

}
