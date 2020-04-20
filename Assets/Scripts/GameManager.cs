using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSetting {
    public List<DialogPhrase> introPhrases;
    public GameObject foodGenerator;
}

public class GameManager : MonoBehaviour
{
    public bool englishVersion;
    public int currentLevel = 0;
    public List<LevelSetting> levels;
    public List<DialogPhrase> lastWords;
    public bool failed = false;
    public List<DialogPhrase> failWords;

    void Awake()
    {
        foreach ( var manager in GameObject.FindObjectsOfType<GameManager>() )
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnEnglishVersion(bool on)
    {
        englishVersion = on;
    }
    public void TurnRussianVersion(bool on)
    {
        englishVersion = !on;
    }
}
