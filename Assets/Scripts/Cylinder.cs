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

    public void ResetColor() {
        renderer.sharedMaterial.color = Color.yellow;
    }
    public void ChangeColor(Color color){
        renderer.sharedMaterial.color = color;
    }
    private void OnMouseDown(){
        ResetColor();
    }
}
