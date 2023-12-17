using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    /*
     * NOTE: saya prefer menyimpan nama scene dalam cache variables
     * daripada harus memasukkan nama scene setiap kali akan melakukan
     * Load Scene karna terlalu hardcoded dan redundant
     */

    [SerializeField] string nameOfStartMenuScene;
    [SerializeField] string nameOfChooseLevelMenuScene;
    [SerializeField] string nameOfGameScene;


    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene(nameOfStartMenuScene);
    }
    public void LoadChooseLevelMenuScene()
    {
        SceneManager.LoadScene(nameOfChooseLevelMenuScene);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(nameOfGameScene);
    }
}
