using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // public Texture2D pushCursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
        curtainAnimator.SetTrigger("fadein");
    }
    public void LoadDialogScene()
    {
        SceneManager.LoadScene("DialogScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
