using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class SpriteList
{
    public string name;
    public Sprite[] sprites;
}

[ExecuteInEditMode]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteList[] spriteLists = new SpriteList[0];
    public int currentListIndex;
    public float animationProgress;

    private SpriteRenderer spriteRenderer;
    private Image uiImage;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiImage = GetComponent<Image>();

        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentListIndex >= spriteLists.Length) {
            return;
        }
        int spriteIndex = (int)(animationProgress * spriteLists[currentListIndex].sprites.Length);
        if (spriteIndex >= spriteLists[currentListIndex].sprites.Length)
        {
            // Debug.Log(string.Format("index {0} {1} {2}", currentListIndex, animationProgress, spriteIndex));
            return;
        }
        if (spriteRenderer)
        {
            spriteRenderer.sprite = spriteLists[currentListIndex].sprites[spriteIndex];
        }
        if (uiImage)
        {
            uiImage.sprite = spriteLists[currentListIndex].sprites[spriteIndex];
        }
    }
}
