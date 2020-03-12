using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{

    public SpriteRenderer background1;
    public SpriteRenderer background2;
    float timer = 0;
    int spriteIndex = 0;
    public List<Sprite> spriteList;
    Sprite oldSprite;
    private YieldInstruction fadeInstruction = new YieldInstruction();
    public float backgroundChangeTime = 20;
    public float fadeTime = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < backgroundChangeTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spriteIndex = spriteIndex > spriteList.Count - 1 ? 0 : spriteIndex + 1;
            background2.color = new Color(255, 255, 255, 255);
            background1.sprite = spriteList[spriteIndex];
            oldSprite = spriteList[spriteIndex];

            StartCoroutine(FadeOut(background2));
        }
    }

    IEnumerator FadeOut(SpriteRenderer image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
        background2.sprite = oldSprite;
    }
}
