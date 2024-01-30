using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private Scene thisScene; 
    private GameObject[] roots;

    public void SceneLoad(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void CombatSceneLoad(string sceneName) {
        thisScene = SceneManager.GetActiveScene();
        roots = thisScene.GetRootGameObjects();

        foreach (GameObject root in roots) {
            root.SetActive(true);
        }

        SceneManager.LoadScene(sceneName);
    }

    
}
