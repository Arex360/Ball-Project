using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;

public class Player1 : MonoBehaviour
{

    bool active;
    bool jumpup = true;

    float moveHorizontal;
    float moveVertical;
    float speed = 5;
    Rigidbody rb;

    int Gcount = 0;
    int count = 0;

    [SerializeField] Text CountText;
    [SerializeField] GameObject Cylinder;
    [SerializeField] GameObject Spotlight;
    [SerializeField] GameObject Player2;

    public int team;
    private int defaultTeam;
    public Renderer renderer;
    private MySpotLight currentLight;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "Count: " + Gcount;
        if (active)
        {
            GetComponent<Renderer>().material.color = Color.green;
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

        else if (!active)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (active && jumpup && (Input.GetKeyDown(KeyCode.Space)))
        {
            Vector3 jumpForce = new Vector3(0, 5, 0);

            rb.AddForce(jumpForce, ForceMode.Impulse);
            jumpup = false;

}

    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(force * speed);
    }

    public void ActiveTrue()
    {
        Player2.GetComponent<Player2>().ActiveFalse();

        active = true;
    }

    public void ActiveFalse()
    {
        active = false;
    }

    private void OnMouseDown()
    {
        ActiveTrue();
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
        GameObject triggerObject = other.gameObject;

        if(triggerObject.name == "GreenCube" || triggerObject.name == "GreenCube (1)")
        {

            triggerObject.SetActive(false);
            Gcount++;
            Cylinder.GetComponent<Cylinder>().CountIncrease();

        }

        //To reset the scene
        if (triggerObject.name == "CubeReset")
        {
            ResetScene();

        }



        //light code and how to make it follow the ball
        if (triggerObject.name == "greenTrigger")
        {

            Spotlight.GetComponent<GreenSpotLight>().ActiveTrue();

        }

        if (triggerObject.name == "BlueTrigger")
        {

            Spotlight.GetComponent<GreenSpotLight>().ResetLocation();

        }

    }
    private void jumpReset()
    {
        jumpup = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;//Access the object hit
       if (hitObject.name == "flat" || hitObject.name== "wall1" || hitObject.name == "wall2" || hitObject.name == "wall3" || hitObject.name == "wall4")//Will give you the name of the object that it collided with
        {
            jumpReset();
        }

       if (count == 4 )
        
        { 
            Cylinder.gameObject.SetActive(true);
            Cylinder.GetComponent <Cylinder>().TransTrue();
        }
    }

    public void ResetScene()//Make the scene restart
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
