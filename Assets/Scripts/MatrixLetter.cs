using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixLetter : MonoBehaviour
{
    SpriteRenderer rend;
    public Sprite[] characters;

    float lerpTime = 3.0f;
    List<Color> colors;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = characters[Random.Range(0, 25)];
        colors = new List<Color>() { new Color(0.458f, 1, 0.4198f), Color.green, Color.black };
        StartCoroutine(ColorLerp());    // Start color cycle
        Destroy(gameObject, 3.5f);      // Kill this in 3.5 seconds
    }

    // Cycle thru the colors specified
    IEnumerator ColorLerp()
    {
        for (int i = 1; i < colors.Count; i++)
        {
            float startTime = Time.time;
            float percentageComplete = 0;

            while (percentageComplete < 1)
            {
                float elapsedTime = Time.time - startTime;
                percentageComplete = elapsedTime / (lerpTime / (colors.Count - 1));
                rend.color = Color.Lerp(colors[i - 1], colors[i], percentageComplete);

                yield return null;
            }
        }
    }
}
