using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Material greenTeam;
    public Material blueTeam;
    public Material noTeam;
    public bool gameStarted;
    public List<Collectable> collectables;
    public int blueScore;
    public int greenScore;
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI greenScoreText;
    public GameObject cylinder;
    public Material getMat(Team team){
        Material mat = noTeam;
        switch(team){
            case Team.Green:
                print("Assigning green team");
                mat = greenTeam;
                break;
            case Team.BLUE:
                print("Assigning blue team");
                mat = blueTeam;
                break;
        }
        return mat;
    }
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        greenScoreText.text = $"Green: {greenScore}";
        blueScoreText.text = $"Blue: {blueScore}";
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ActivateCylinder()=> cylinder.SetActive(true);
    public void ResetLighting(){
        LightInstance[] lightInstances = GameObject.FindObjectsOfType<LightInstance>();
        for(int i =0;i<lightInstances.Length;i++){
            lightInstances[i].RemoveTarget();
            lightInstances[i].ResetPosition();
        }
    }
    

}
