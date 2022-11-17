using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    Camera cam;
    float camWidth;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camWidth = cam.orthographicSize * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// dùng để chuyển tab ở màn Home
    /// </summary>
    /// <param name="pageName"></param>
    public void MoveTo(string pageName)
    {
        Debug.Log(pageName);
        float pos = 0f;
        if (pageName == "Store")
        {
            pos = camWidth * 2 * 2;
        }
        else if (pageName == "Events")
        {
            pos = camWidth * 2;
        }
        else if (pageName == "Home")
        {
            pos = 0f;
        }
        else if (pageName == "Challenges")
        {
            pos = -camWidth * 2;
        }
        else if (pageName == "Daily")
        {
            pos = -camWidth * 2 * 2;
        }

        StartCoroutine(SmoothMove(
            transform.position,
            new Vector3(pos, transform.position.y, transform.position.z),
            0.2f
        ));
    }

    /// <summary>
    /// hiệu ứng chuyển màn
    /// </summary>
    /// <param name="pos1"> vị trí bắt đầu</param>
    /// <param name="pos2"> vị trí kết thúc</param>
    /// <param name="duration"> thời gian của hiệu ứng (giây)</param>
    /// <returns></returns>
    IEnumerator SmoothMove(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.position = pos2;
    }
}
