using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonPause;
    public GameObject menuPause;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
