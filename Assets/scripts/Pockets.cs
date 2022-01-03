using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other!=null)
        {
            if (other.transform.CompareTag("Token"))
            {
                Destroy(other.gameObject, 0.3f);
            }
        }

    }
}
