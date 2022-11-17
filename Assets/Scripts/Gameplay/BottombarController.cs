using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottombarController : MonoBehaviour
{
    bool status;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        status = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ẩn hiện bottombar trong game
    /// </summary>
    public void ChangeStatus()
    {
        if (status)
        {
            gameObject.transform.position -= new Vector3(0, (cam.orthographicSize * 1.65f * 250f) / 1920f, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(0, (cam.orthographicSize * 1.65f * 250f) / 1920f, 0);
        }
        status = !status;
    }
}
