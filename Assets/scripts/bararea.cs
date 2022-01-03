using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bararea : MonoBehaviour
{
    [SerializeField]  public List<token> tokens;
    // Start is called before the first frame update
    void Start()
    {
        tokens = new List<token>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Token"))
        {
            tokens.Add(other.gameObject.GetComponent<token>());
            other.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Token"))
        {
            tokens.Remove(other.gameObject.GetComponent<token>());
        }
    }
    
}
