using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject HowtoTab;
    // Start is called before the first frame update
    void Start()
    {
        HowtoTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPlay()
    {
        SceneManager.LoadScene("Game_Level");
    }

    public void OnButtonHowTo()
    {
        HowtoTab.SetActive(true);
    }

    public void CloseHowTo()
    {
        HowtoTab.SetActive(false);
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }



}
