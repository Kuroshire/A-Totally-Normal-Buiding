using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "Items/Note")]
public class NoteItem : Item
{
    public string content;

    private bool isShowed = false;

    public override void Use() {
        Debug.Log("La note dit: " + content);
        isShowed = !isShowed;
        if(isShowed) {
            UIManager.NoteDisplayer.ShowNote(this);
        } else {
            UIManager.NoteDisplayer.HideNote();
        }
    }
}
