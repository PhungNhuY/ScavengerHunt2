using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tabbar : MonoBehaviour
{
    [SerializeField] List<TabButton> tabButtons;
    [SerializeField] Transform tabbarText, blackBlock;
    [SerializeField] TabButton selectedTab;

    float camHeight, camWidth;
    Camera cam;
    int numberOfButton;

    private void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = cam.orthographicSize * cam.aspect;
        numberOfButton = tabButtons.Count;


        // selected tab
        tabbarText.GetComponent<Text>().text = selectedTab.gameObject.name;
        tabbarText.transform.position = new Vector3(
            selectedTab.transform.position.x,
            tabbarText.transform.position.y,
            tabbarText.transform.position.z
        );
        blackBlock.transform.position = new Vector3(
            selectedTab.transform.position.x,
            blackBlock.transform.position.y,
            blackBlock.transform.position.z
        );
    }

    public void OnTapExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTapSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();

        // set tabbarText by tab name
        tabbarText.GetComponent<Text>().text = selectedTab.gameObject.name;

        // move black block and text to selected button
        StartCoroutine(smoothChangePos(
            tabbarText.transform.position,
            new Vector3(
                selectedTab.transform.position.x,
                tabbarText.transform.position.y,
                tabbarText.transform.position.z
            ),
            0.1f
        ));
    }

    public void ResetTabs()
    {

    }

    // use to move black block and text to new pos smoothy
    IEnumerator smoothChangePos(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            tabbarText.transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            blackBlock.transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        tabbarText.transform.position = pos2;
        blackBlock.transform.position = pos2;
    }
}
