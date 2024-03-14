using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpotLight : MonoBehaviour
{


    Vector3 offset;
    Vector3 FirstPosition;
    bool Active = false;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Cube;




    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Cube.transform.position;
        FirstPosition = gameObject.transform.position;// to get the first position

    }


    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            transform.position = Ball.transform.position + offset;
        }


    }

    public void ActiveTrue()
    {
        Active = true;
    }

    public void ResetLocation()
    {
        Active = false;
    }
}
