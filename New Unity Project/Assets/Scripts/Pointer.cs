using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject arrow;
    public int rank = 1;

    //define possible positions for the arrow
    private Vector3 mid = new Vector3(-5.0f, 0.0f, 0.0f);
    private Vector3 btm = new Vector3(-5.0f, -4.5f, 0.0f);
    private Vector3 top = new Vector3(-5.0f, 4.5f, 0.0f);

    //define the LERP function
    public Vector3 Lerp(Vector3 p0, Vector3 p1, float t)
    {
        t = Mathf.Clamp01(t);

        return new Vector3(
            p0.x + (p1.x - p0.x) * t,
            p0.y + (p1.y - p0.y) * t,
            p0.z + (p1.z - p0.z) * t
            );
    }

    // Start is called before the first frame update
    void Start()
    {
        arrow.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        //make pointer move up and down correctly
        if (Input.GetKeyDown(KeyCode.DownArrow) && rank == 1)
        {
            arrow.transform.position = Lerp(mid, btm, 1);
            rank = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && rank == 2)
        {
            arrow.transform.position = Lerp(top, mid, 1);
            rank = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && rank == 1)
        {
            arrow.transform.position = Lerp(mid, top, 1);
            rank = 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && rank == 0)
        {
            arrow.transform.position = Lerp(btm, mid, 1);
            rank = 1;
        }
    }
}
