using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Football : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;

    Rigidbody rb;

    [SerializeField] float speed = 5;

    int countGold = 0;

    [SerializeField] GameObject EndCyliner;
    public Team team;
    private Team defaultTeam;
    public MeshRenderer meshRenderer;
    private LightInstance currentInstance;
    public bool preActivate;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //access the Rigidbody component      
        meshRenderer = this.GetComponent<MeshRenderer>();  
        defaultTeam = team;
        if(!preActivate){
            team = Team.NoTeam;
        }
        meshRenderer.sharedMaterial = GameManager.instance.getMat(team);
    }

    // Update is called once per frame
    void Update()
    {
        if(team == Team.NoTeam) return;
        moveHorizontal = -Input.GetAxis("Horizontal");
        moveVertical = -Input.GetAxis("Vertical");

        print("Horizontal (x): " + moveHorizontal);
        print("Vertical (y): " + moveVertical);

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpForce = new Vector3(0, 5, 0);
            //Apply an impulse force in the y axis
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.isKinematic = team == Team.NoTeam;
        Vector3 force = new Vector3(-moveHorizontal, 0, -moveVertical);
        
        rb.AddForce(force*speed); //add the force vector to the Rigidbody
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Light")){
            LightInstance instance = other.GetComponent<LightInstance>();
            if(team == instance.supportedTeam){
                instance.AddTarget(this.transform);
                currentInstance = instance;
            }else if(team != instance.supportedTeam && currentInstance){
                currentInstance.RemoveTarget();
                currentInstance.ResetPosition();
                currentInstance = null;
            }
        }
        else if(other.CompareTag("Collectable")){
            Collectable collectable = other.GetComponent<Collectable>();
            if(team == collectable.supportedTeam){
                collectable.Consume();
            }
        }
        else if(other.CompareTag("DeadZone")){
            GameManager.instance.ResetScene();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("cylinder")){
            Cylinder cylinder = other.transform.GetComponent<Cylinder>();
            cylinder.ChangeMat(meshRenderer.sharedMaterial);            
        }
    }
    public void JumpBall()
    {
        Vector3 jumpForce = new Vector3(0, 5, 0);
        //Apply an impulse force in the y axis
        rb.AddForce(jumpForce, ForceMode.Impulse);
    }


    private void OnMouseDown() {
        Football[] footballs = GameObject.FindObjectsOfType<Football>();
        foreach(Football football in footballs){
            football.team = Team.NoTeam;
            football.meshRenderer.sharedMaterial = GameManager.instance.getMat(team);
        }
        team = defaultTeam;
        meshRenderer.sharedMaterial = GameManager.instance.getMat(team);
    }
}
