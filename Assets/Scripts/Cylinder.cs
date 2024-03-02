using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public Material defaultMat;
    private Renderer renderer;
    public float speed= 0.5f;
    public float y = 1f;
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }
    private void Update() {
        if (transform.position.y < y)
        {
            transform.Translate(Vector3.up * speed* Time.deltaTime);
        }
    }

    public void ResetMat() {
        renderer.sharedMaterial = defaultMat;
    }
    public void ChangeMat(Material mat){
        renderer.sharedMaterial = mat;
    }
    private void OnMouseDown(){
        ResetMat();
    }
}
