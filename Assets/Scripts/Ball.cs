using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;

    Rigidbody rb;

    [SerializeField] float speed = 5;
    [SerializeField] GameObject EndCyliner;
    public int team;
    private int defaultTeam;
    public Renderer renderer;
    private MySpotLight currentLight;
    public bool stop;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();   
        renderer = this.GetComponent<Renderer>();  
        defaultTeam = team;
        if(stop){
            team = -1;
        }
        if(team == 0){
            renderer.sharedMaterial.color = Color.green;
        }else if(team == 1){
            renderer.sharedMaterial.color = Color.blue;            
        }else{
            renderer.sharedMaterial.color = Color.red;            
        }
    }

    void Update()
    {
        if(team == -1) return;
        moveHorizontal = -Input.GetAxis("Horizontal");
        moveVertical = -Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpForce = new Vector3(0, 5, 0);
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(team == -1){
            rb.isKinematic = true;
        }
        Vector3 force = new Vector3(-moveHorizontal, 0, -moveVertical);
        
        rb.AddForce(force*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Light")){
            MySpotLight light= other.GetComponent<MySpotLight>();
            if(team == light.allowedTeam){
                light.AddTarget(transform);
                currentLight = light;
            }else if(team != light.allowedTeam && currentLight){
                currentLight.RemoveTarget();
                currentLight.ResetPosition();
                currentLight = null;
            }
        }
        else if(other.CompareTag("Box")){
            Cube collectable = other.GetComponent<Cube>();
            if(team == collectable.allowedTeam){
                collectable.PickUp();
            }
        }
        else if(other.CompareTag("reset")){
            MyManager.instance.ResetScene();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("cylinder")){
            Cylinder cylinder = other.transform.GetComponent<Cylinder>();          
        }
    }
    private void OnMouseDown() {
        Ball[] Balls = GameObject.FindObjectsOfType<Ball>();
        foreach(Ball Ball in Balls){
            Ball.team = -1;
            Ball.renderer.sharedMaterial.color = Color.red;
        }
        team = defaultTeam;
        if(team == 1)
            renderer.sharedMaterial.color = Color.blue;
        else {
            renderer.sharedMaterial.color = Color.green;
        }
        rb.isKinematic = false;
    }
}
