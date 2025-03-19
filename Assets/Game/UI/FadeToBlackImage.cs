using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeToBlackImage : MonoBehaviour
{
    [SerializeField] private Image fadeToBlackImage;

    public bool isFading = false;

    private void Awake()
    {
        fadeToBlackImage = GetComponent<Image>();
        fadeToBlackImage.color = new Color(0, 0, 0, 0);
    }

    public void BlackScreenTransition(Action whileTransitioning)
    {
        FadeToBlack(() =>
        {
            Debug.Log("Transitioning");
            whileTransitioning?.Invoke();
            Invoke(nameof(FadeToClear), .5f);
        });
    }

    private void FadeToBlack(Action callback)
    {
        Debug.Log("Fading to black");
        StartCoroutine(FadeToBlackCoroutine(.5f, callback));

    }

    private void FadeToClear()
    {
        Debug.Log("Fading to clear");
        StartCoroutine(FadeToClearCoroutine(.5f, () => Debug.Log("fade to clear")));
    }

    public IEnumerator FadeToBlackCoroutine(float duration, Action callback)
    {
        fadeToBlackImage.color = new Color(0, 0, 0, 0);
        while (fadeToBlackImage.color.a < 1)
        {
            float alpha = fadeToBlackImage.color.a + Time.deltaTime / duration;
            fadeToBlackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeToBlackImage.color = new Color(0, 0, 0, 1);

        callback?.Invoke();
    }

    public IEnumerator FadeToClearCoroutine(float duration, Action callback) {
        while (fadeToBlackImage.color.a > 0)
        {
            float alpha = fadeToBlackImage.color.a - Time.deltaTime / duration;
            fadeToBlackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeToBlackImage.color = new Color(0, 0, 0, 0);

        callback?.Invoke();
    }
}
