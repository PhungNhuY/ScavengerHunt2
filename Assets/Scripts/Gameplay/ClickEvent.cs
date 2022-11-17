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
        if (Input.GetMouseButtonUp(0))
        {
            //get touch position
            touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray straight down.
            // tạo một tia chiếu thẳng đứng ở vị trí chạm
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(touchPosition.x, touchPosition.y), -Vector2.up);
            // tia sẽ bắt vật đầu tiên chạm phải( gameobject cần có collider)
            // nếu tia không chạm vật -> hiện dấu X
            if(hit.collider == null)
            {
                // create a new x icon
                GameObject x_icon_clone = Instantiate(
                    x_icon,
                    new Vector3(touchPosition.x, touchPosition.y, 0),
                    x_icon.transform.rotation
                );
            }
            // nếu tia chạm vật
            else
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
