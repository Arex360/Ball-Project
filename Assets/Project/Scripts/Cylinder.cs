using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4 && transform.position.y<1)
        {
            transform.Translate(0, 0.5f * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        

        if(hitObject.name == "player1")
        {
            GetComponent<Renderer>().material.color = Color.green;

        }
        else if (hitObject.name == "player2")
        {
            GetComponent<Renderer>().material.color = Color.blue;

        }

    }
    private void OnMouseDown()
    {
        GetComponent<Renderer>().material.color = Color.yellow;

    }
    public void CountIncrease()
    {
        count++;
    }

    public void TransTrue()
    {

    }

}
