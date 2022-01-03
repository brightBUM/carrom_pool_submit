using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class strikerbar : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public bool strikebaractive = true;
    [SerializeField]public Slider strikeslider;
    [SerializeField] StrikerController _sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (strikebaractive && !_sc.overlapping)
        {
            _sc.transform.position = new Vector3(strikeslider.value, _sc.transform.position.y, 0);
        }
    }
    IEnumerator makebaractive()
    {
        yield return new WaitForSeconds(0.3f);
        _sc.overlapping = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(makebaractive());
        _sc.c2d.isTrigger = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _sc.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        _sc.c2d.isTrigger = true;
    }
}
