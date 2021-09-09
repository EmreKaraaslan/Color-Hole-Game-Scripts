using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI winText;
    [SerializeField] TMPro.TextMeshProUGUI loseText;
    [SerializeField] TMPro.TextMeshProUGUI restartText;

    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject startAgainButton;

    [SerializeField] Image fillBarPlane1;
    [SerializeField] Image fillBarPlane2;

    CubeCollisions collisionInfo;
    DecideSituations decideSituations;

    Scene scene;
    int activeSceneIndex;
    int nextSceneIndex;
    int totalNumberofScenes;
    
    void Start()
    {
        collisionInfo = GetComponent<CubeCollisions>();
        decideSituations = GetComponent<DecideSituations>();

        InitialTexts();
        ScaleButtons();
        SceneInfo();
    }

    void Update()
    {
        FillBars();
        SuccessfulLevel();
    }

    private void InitialTexts()
    {
        winText.text = "";
        loseText.text = "";
        restartText.text = "";
    }

    private void ScaleButtons()
    {
        nextLevelButton.transform.DOScale(Vector3.zero, 0);
        restartButton.transform.DOScale(Vector3.zero, 0);
        startAgainButton.transform.DOScale(Vector3.zero, 0);
    }

    private void SceneInfo()
    {
        scene = SceneManager.GetActiveScene();
        activeSceneIndex = scene.buildIndex;
        nextSceneIndex = scene.buildIndex + 1;
        totalNumberofScenes = SceneManager.sceneCountInBuildSettings;
    }

   

    public void SuccessfulLevel()
    {
        if (collisionInfo.collidedCube == (decideSituations.firstPlanePositiveCubes + decideSituations.secondPlanePositiveCubes))
        {
         
            if (activeSceneIndex + 1 < totalNumberofScenes)
            {
                winText.text = "Level is Completed!";
                nextLevelButton.transform.DOScale(new Vector3(1, 1, 1), 1).SetDelay(1f);
            }
            else
            {
                winText.text = "Game is Over!";
                startAgainButton.transform.DOScale(new Vector3(1, 1, 1), 1).SetDelay(1f);
            }
        }
    }

    public void UnsuccessfulLevel()
    
    {
        loseText.text = "You Lost!";
        restartButton.transform.DOScale(new Vector3(1, 1, 1), 1).SetDelay(1f);

    }

    void FillBars()
    {
        float secondPlaneCollidedCube = collisionInfo.collidedCube - decideSituations.firstPlanePositiveCubes;
        fillBarPlane1.fillAmount = collisionInfo.collidedCube / decideSituations.firstPlanePositiveCubes;
        fillBarPlane2.fillAmount = secondPlaneCollidedCube / decideSituations.secondPlanePositiveCubes;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadSameLevel()
    {
        if(activeSceneIndex+1<totalNumberofScenes)
        {
            SceneManager.LoadScene(activeSceneIndex); 
        }       
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }

}
