using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    [SerializeField] Slider strikeslider;
    [SerializeField]LineRenderer lr;
    public bool strikerselected = false;
    public bool strikebaractive = true;
    Camera cam;
    [SerializeField]Transform dragstartpos;
    [SerializeField]Vector3 draggingpos;
    Vector3 dragreleasepos;
    Touch touchS;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(strikebaractive)
        {
            transform.position = new Vector3(strikeslider.value,transform.position.y,0);
        }
        //{
        //    touchS = Input.GetTouch(0);

            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            //{
            //    touchS = Input.GetTouch(0);
            //    Ray ray = Camera.main.ScreenPointToRay(touchS.position);
            //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //    if (hit  && hit.transform.CompareTag("Striker"))
            //    {
            //        //Debug.Log("striker slected");
            //        strikerselected = true;
            //        strikebaractive = false;

            //    }
            //    else
            //    {
            //        strikebaractive = true;
            //        strikerselected = false;
            //    }
            //}
            //if (touchS.phase == TouchPhase.Began && strikerselected)
            //{
            //    Debug.Log("began");
            //    dragstarted();
            //}
            //if (touchS.phase == TouchPhase.Moved)
            //{
            //    Debug.Log("moved0");
            //    dragging();
            //}
            //if (touchS.phase == TouchPhase.Ended)
            //{
            //    Debug.Log("released");
            //    dragreleased();
            //}
    }
    private void OnMouseDown()
    {
        Debug.Log("down");
        //dragstartpos = cam.ScreenToWorldPoint(Input.mousePosition);
        //dragstartpos = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragstartpos.position);
    }
    private void OnMouseDrag()
    {
        Debug.Log("drag");
        draggingpos = cam.ScreenToWorldPoint(Input.mousePosition);
        draggingpos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, -draggingpos);
    }
    //void dragstarted()
    //{
    //    dragstartpos = cam.ScreenToWorldPoint(touchS.position);
    //    dragstartpos.z = -1f;
    //    lr.positionCount = 1;
    //    lr.SetPosition(0, dragstartpos);

    //}
    void dragging()
    {
        draggingpos = cam.ScreenToWorldPoint(touchS.position);
        draggingpos.z = -1f;
        lr.positionCount = 2;
        lr.SetPosition(1, -draggingpos);
    }
    void dragreleased()
    {
        
    }
}
