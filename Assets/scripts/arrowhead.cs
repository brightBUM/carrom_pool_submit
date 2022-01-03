using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowhead : MonoBehaviour
{
    public Transform line;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.localPosition - line.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = line.localPosition+offset;
    }
}
