using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;


public class Player2 : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    bool active;
    bool jumpup = true;
    float moveHorizontal;
    float moveVertical;
    float speed = 5;
    Rigidbody rb;
    int Bcount = 0;
    [SerializeField] Text CountText;    
    [SerializeField] GameObject Cylinder;
    [SerializeField] GameObject Spotlight;

    public int team;
    private int defaultTeam;
    public Renderer renderer;
    private MySpotLight currentLight;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "Count: " + Bcount;

        if (active)
        {
            GetComponent<Renderer>().material.color = Color.blue;
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
        Player1.GetComponent<Player1>().ActiveFalse();

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

        if (triggerObject.name == "BlueCube" || triggerObject.name == "BlueCube (1)")
        {

            triggerObject.SetActive(false);
            Bcount++;
            Cylinder.GetComponent<Cylinder>().CountIncrease();

        }
        if (triggerObject.name == "CubeReset")
        {
            ResetScene();

        }


       if (triggerObject.name == "BlueTrigger")
        {

            Spotlight.GetComponent<BlueSpotLight>().ActiveTrue();

        }
        if(triggerObject.name == "greenTrigger")
        {

            Spotlight.GetComponent<BlueSpotLight>().ResetLocation();

        }

    }









    private void jumpReset()
    {
        jumpup = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name == "flat" || hitObject.name == "wall1" || hitObject.name == "wall2" || hitObject.name == "wall3" || hitObject.name == "wall4")
        {
            jumpReset();
        }
    }
    public void ResetScene()//Make the scene restart
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}