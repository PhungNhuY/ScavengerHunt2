using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    [SerializeField] Camera cam;
    [SerializeField] SpriteRenderer mapRenderer;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;
    [SerializeField] Vector3 camPos = new Vector3(0, 0, -10);
    private float minCamSize, maxCamSize;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;
    bool zooming;

    // Start is called before the first frame update
    void Start()
    {
        // tính toán kích thước map
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;

        // set maxCamSize and minCamSize
        float mapSize = mapRenderer.bounds.size.y / 2f;
        maxCamSize = mapSize / minZoom;
        minCamSize = mapSize / maxZoom;

        // set first camera size
        cam.orthographicSize = maxCamSize;

        // first camera pos
        cam.transform.position = ClampCamera(camPos);

        zooming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
            zooming = false;
        }

        if (Input.touchCount == 2)
        {
            zooming = true;
            // chạm 2 ngón tay
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            zoom(difference * 0.01f);
        }
        // chỉ cham một ngón tay
        else if (Input.GetMouseButton(0) && !zooming)
        {
            Vector3 difference = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }

        // this for PC, use scroll
        zoom(Input.GetAxis("Mouse ScrollWheel")*5);
    }

    void zoom(float increment)
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    // This function keeps the camera from going out of the map
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    //public void moveTo(int pos)
    //{
    //    // cam.orthographicSize = maxCamSize / 4f;
    //    StartCoroutine(smoothCamScale(
    //        cam.orthographicSize, 
    //        maxCamSize / 4f, 
    //        1f
    //    ));
    //    if (pos == 1)
    //    {
    //        // cam.transform.position = new Vector3(mapMinX / 2f, mapMaxY / 2f, cam.transform.position.z);
    //        StartCoroutine(smoothCamTrans(
    //            cam.transform.position,
    //            new Vector3(mapMinX / 2f, mapMaxY / 2f, cam.transform.position.z),
    //            1f
    //        ));
    //    }
    //    else if (pos == 2)
    //    {
    //        // cam.transform.position = new Vector3(mapMaxX / 2f, mapMaxY / 2f, cam.transform.position.z);
    //        StartCoroutine(smoothCamTrans(
    //            cam.transform.position,
    //            new Vector3(mapMaxX / 2f, mapMaxY / 2f, cam.transform.position.z),
    //            1f
    //        ));
    //    }
    //    else if (pos == 3)
    //    {
    //        // cam.transform.position = new Vector3(mapMaxX / 2f, mapMinY / 2f, cam.transform.position.z);
    //        StartCoroutine(smoothCamTrans(
    //            cam.transform.position,
    //            new Vector3(mapMaxX / 2f, mapMinY / 2f, cam.transform.position.z),
    //            1f
    //        ));
    //    }
    //    else if (pos == 4)
    //    {
    //        // cam.transform.position = new Vector3(mapMinX / 2f, mapMinY / 2f, cam.transform.position.z);
    //        StartCoroutine(smoothCamTrans(
    //            cam.transform.position,
    //            new Vector3(mapMinX / 2f, mapMinY / 2f, cam.transform.position.z),
    //            1f
    //        ));
    //    }
    //}

    //IEnumerator smoothCamTrans(Vector3 pos1, Vector3 pos2, float duration)
    //{
    //    for (float t = 0f; t < duration; t += Time.deltaTime)
    //    {
    //        transform.position = Vector3.Lerp(pos1, pos2, t / duration);
    //        yield return 0;
    //    }
    //    cam.transform.position = pos2;
    //}

    //IEnumerator smoothCamScale(float size1, float size2, float duration)
    //{
    //    for (float t = 0f; t < duration; t += Time.deltaTime)
    //    {
    //        cam.orthographicSize = Mathf.Lerp(size1, size2, t / duration);
    //        yield return 0;
    //    }
    //    cam.orthographicSize = size2;
    //}
}