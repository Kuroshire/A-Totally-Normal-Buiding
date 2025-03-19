using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class SubtitlesHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitlesText;

    private bool isUsed = false;

    private float timeUntilDisappear;

    void Awake()
    {
        if(!isUsed) {
            HideSubtitles();
        }
    }

    void Update()
    {
        if(isUsed) {
            timeUntilDisappear -= Time.deltaTime;

            if(timeUntilDisappear <= 0) {
                HideSubtitles();
            }
        }
    }

    public void CallSubtitles(string content, float uptime = 3.5f) {
        subtitlesText.text = content;

        isUsed = true;
        gameObject.SetActive(true);

        timeUntilDisappear = uptime;
    }

    public void HideSubtitles() {
        isUsed = false;
        gameObject.SetActive(false);
        timeUntilDisappear = 0;
    }
}
