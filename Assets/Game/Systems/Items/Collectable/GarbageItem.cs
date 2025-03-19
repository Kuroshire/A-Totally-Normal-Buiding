using UnityEngine;

[CreateAssetMenu(fileName = "Garbage", menuName = "Items/Garbage")]
public class GarbageItem : Item
{
    public override void Use() {
        UIManager.Subtitles.CallSubtitles("I need to throw this out...");
    }
}

