using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StrikerController : MonoBehaviour
{
    
    [SerializeField] GameObject mouseptB;
    [SerializeField] float currentdistance;
    [SerializeField] Slider strikeslider;
    [SerializeField] strikerbar _strikerbar;
    float safeSpace;
    [SerializeField] float maxDistance = 3f;
    Vector3 shootdirection;
    [SerializeField] float power;
    [SerializeField] public Rigidbody2D rb;

    [SerializeField]public  Collider2D c2d;
    [SerializeField] Collider2D tokencd;
    [SerializeField] TextMeshProUGUI tmrpo;
    [SerializeField] Vector2 tokendis = Vector2.zero;
    [SerializeField] bararea _bararea;
    [SerializeField] GameObject glow;
    
    Vector2 mypos, mousepos2d;
    Vector3 dimxy;
    [SerializeField]public bool overlapping;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
        mouseptB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnMouseDown()
    {
        foreach(token item in _bararea.tokens)
        {
            item.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        _bararea.gameObject.SetActive(false);
    }
    private void OnMouseDrag()
    {
        if(!overlapping)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            glow.SetActive(false);
            mouseptB.SetActive(true);
            _strikerbar.strikebaractive = false;
            _strikerbar.strikeslider.interactable = false;
            

            Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouspos2d = new Vector2(temp.x, temp.y);
            currentdistance = Vector2.Distance(transform.position, mouspos2d);


            //arrow direction

            dimxy = mouspos2d - mypos;

            if (currentdistance <= maxDistance)
            {
                safeSpace = currentdistance;
                mouseptB.transform.position = transform.position + (new Vector3(dimxy.x, dimxy.y, 0) * -1);
            }
            else
            {
                safeSpace = maxDistance;
                mouseptB.transform.position = transform.position + ((new Vector3(dimxy.x, dimxy.y, 0) * -1 * (maxDistance / dimxy.magnitude)));
            }
            shootdirection = dimxy.normalized;
        }
    }
    private void OnMouseUp()
    {
        foreach (token item in _bararea.tokens)
        {
            item.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        _bararea.gameObject.SetActive(false);
        mouseptB.SetActive(false);

        Vector3 push = shootdirection * Mathf.Abs(safeSpace) * power*-1;
        rb.AddForce(push, ForceMode2D.Impulse);
    }
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            overlapping = true;
            tmrpo.text = "striker overlaps token";
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            overlapping = false;
            tmrpo.text = " ";
        }
    }
    
}
