using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Team supportedTeam;
    
    public void Consume(){
        GameManager.instance.collectables.Remove(this);
        if(supportedTeam == Team.Green){
            GameManager.instance.greenScore++;
        }else{
            GameManager.instance.blueScore++;
        }
        if(GameManager.instance.collectables.Count == 0)
            GameManager.instance.ActivateCylinder();
        Destroy(this.gameObject);
    }
    private void Update() {
        this.transform.Rotate(0,30*Time.deltaTime,0);
    }
}
