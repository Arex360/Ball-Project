using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpotLight : MonoBehaviour
{
    public Transform target;
    private Vector3 defaultPosition;
    public int allowedTeam;
    void Start()
    {
        defaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            Vector3 pos = target.position;
            pos.y = this.transform.position.y;
            this.transform.position = pos;
            
        }
    }
    public void AddTarget(Transform target){
        this.target = target;
    }
    public void RemoveTarget() {
        target = null;
    }
    public void ResetPosition(){
        this.transform.position = defaultPosition;
    }
}
