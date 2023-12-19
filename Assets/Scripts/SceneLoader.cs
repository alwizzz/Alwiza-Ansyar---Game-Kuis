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
        AudioManager.instance.PlayBGM(0); // main bgm
        SceneManager.LoadScene(nameOfStartMenuScene, LoadSceneMode.Single);
    }
    public void LoadChooseLevelMenuScene()
    {
        AudioManager.instance.PlayBGM(0); // main bgm
        SceneManager.LoadScene(nameOfChooseLevelMenuScene, LoadSceneMode.Single);
    }
    public void LoadGameScene()
    {
        AudioManager.instance.PlayBGM(1); // game bgm
        SceneManager.LoadScene(nameOfGameScene, LoadSceneMode.Single);
    }

}
