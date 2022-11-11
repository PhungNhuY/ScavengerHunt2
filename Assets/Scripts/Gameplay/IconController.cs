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
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Destroy(gameObject);
        }

        iconSize = Camera.main.orthographicSize / 100;
        gameObject.transform.localScale = new Vector3(
            iconSize,
            iconSize,
            1
        );
    }
}
