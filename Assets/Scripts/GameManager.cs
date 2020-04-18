using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSetting {
    public List<string> introPhrases;
    public GameObject foodGenerator;
}

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0;
    public List<LevelSetting> levels;
    public List<string> lastWords;
    public bool failed = false;
    public List<string> failWords;

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
}
