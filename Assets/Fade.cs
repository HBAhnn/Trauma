using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoFade(float time)
    {
        StartCoroutine("FadeOut", time);
    }

    public void StopFade(float time)
    {
        StartCoroutine("FadeIn", time);
    }

    public IEnumerator FadeIn(float time)
    {
        Color color = sprite.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            sprite.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        Color color = sprite.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            sprite.color = color;
            yield return null;
        }
    }
}
