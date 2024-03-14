using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MyManager : MonoBehaviour
{
    public static MyManager instance;


    public List<Cube> cubes;
    public int blueScore;
    public int greenScore;
    public Text blueScoreText;
    public Text greenScoreText;
    public GameObject cylinder;
    private void Awake() {
        instance = this;
    }
 

    // Update is called once per frame
    void Update()
    {
        greenScoreText.text = "Green: " +greenScore.ToString();
        blueScoreText.text = "Blue: " + blueScore.ToString();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ActivateCylinder()=> cylinder.SetActive(true);
    public void ResetLighting(){
        MySpotLight[] mySpotLights = GameObject.FindObjectsOfType<MySpotLight>();
        for(int i =0;i<mySpotLights.Length;i++){
            mySpotLights[i].RemoveTarget();
            mySpotLights[i].ResetPosition();
        }
    }
    

}
