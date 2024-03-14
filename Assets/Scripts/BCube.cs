using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Renderer>().material.color = Color.blue;

        transform.Rotate(0, 30 * Time.deltaTime, 0);
    }
}
