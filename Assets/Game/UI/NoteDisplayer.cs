using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class NoteDisplayer: MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI noteText;

    public NoteItem currentNote = null;

    void Awake()
    {
        if(currentNote == null) {
            HideNote();
        }
    }

    public void SetNote(string text) {
        noteText.text = text;
    }

    public void ShowNote(NoteItem note) {
        SetNote(note.content);

        if(currentNote != null) {
            HideNote();
        }
        currentNote = note;

        //animation then turn off
        gameObject.SetActive(true);
    }

    public void HideNote() {
        currentNote = null;
        gameObject.SetActive(false);
    }
}