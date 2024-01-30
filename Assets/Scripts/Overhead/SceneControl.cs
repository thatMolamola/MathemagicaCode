using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private Scene thisScene; 
    private GameObject[] roots;
    private GameObject combatRootContain;

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
            root.SetActive(false);
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void CombatSceneUnload() {
        //tag'd object of other scene to delete
        combatRootContain = GameObject.FindWithTag("CombatRoot");
        Destroy(combatRootContain);
        thisScene = SceneManager.GetActiveScene();
        roots = thisScene.GetRootGameObjects();

        foreach (GameObject root in roots) {
            root.SetActive(true);
        }
    }
}
