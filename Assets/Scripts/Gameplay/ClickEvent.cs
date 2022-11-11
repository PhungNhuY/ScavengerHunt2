using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    Vector3 touchPosition;
    [SerializeField] Camera cam;
    [SerializeField] GameObject x_icon;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //get touch position
            touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            // create a new x icon
            GameObject x_icon_clone = Instantiate(
                x_icon,
                new Vector3(touchPosition.x, touchPosition.y, 0),
                x_icon.transform.rotation
            );
        }
    }
}
