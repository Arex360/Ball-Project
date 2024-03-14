using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int allowedTeam;
    
    public void PickUp(){
        MyManager.instance.cubes.Remove(this);
        if(allowedTeam == 0){
            MyManager.instance.greenScore++;
        }else{
            MyManager.instance.blueScore++;
        }
        if(MyManager.instance.cubes.Count == 0)
            MyManager.instance.ActivateCylinder();
        Destroy(this.gameObject);
    }
    private void Update() {
        this.transform.Rotate(0,30*Time.deltaTime,0);
    }
}
