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

    public ChatBox chatBox;
    public FadeToBlackImage fadeToBlack;
    public InventoryUI inventoryUI;
    public NoteDisplayer noteDipslayer;
    [SerializeField] SubtitlesHandler subtitles;
    public static SubtitlesHandler Subtitles => Instance.subtitles;
}
