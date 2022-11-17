using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    float timer = 0.5f;
    float iconSize;
    // Start is called before the first frame update
    void Start()
    {
        // đặt kích thước X_icon theo camSize
        iconSize = Camera.main.orthographicSize / 100;
        gameObject.transform.localScale = new Vector3(
            iconSize,
            iconSize,
            1
        );
    }

    // Update is called once per frame
    void Update()
    {
        // destroy icon sau $timer giây
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Destroy(gameObject);
        }

        // scale lại sau mỗi lần update -> icon giữ nguyên size so với màn hình nếu người dùng zoom
        iconSize = Camera.main.orthographicSize / 100;
        gameObject.transform.localScale = new Vector3(
            iconSize,
            iconSize,
            1
        );
    }
}
