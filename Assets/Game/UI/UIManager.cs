using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] PlayerUI playerUI;

    public static SubtitlesHandler Subtitles => Instance.playerUI.Subtitles;
    public static NoteDisplayer NoteDisplayer => Instance.playerUI.NoteDisplayer;

    void Start()
    {
        playerUI.gameObject.SetActive(true);
    }
}
