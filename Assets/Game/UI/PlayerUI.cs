using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] ChatBox chatBox;
    [SerializeField] FadeToBlackImage fadeToBlack;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] NoteDisplayer noteDisplayer;
    [SerializeField] SubtitlesHandler subtitles;

    public ChatBox ChatBox => chatBox;
    public FadeToBlackImage FadeToBlack => fadeToBlack;
    public InventoryUI InventoryUI => inventoryUI;
    public NoteDisplayer NoteDisplayer => noteDisplayer;
    public SubtitlesHandler Subtitles => subtitles;
}