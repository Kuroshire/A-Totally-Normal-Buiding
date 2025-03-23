using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : InteractableItem
{
    [SerializeField] private int hours, minutes;

    [SerializeField] Transform hoursHand, minutesHand;

    void Start()
    {
        SetTime(hours, minutes);
    }

    public void SetTime(int hours, int minutes) {
        if(hours < 0 || hours > 11 || minutes < 0 || minutes > 60) {
            Debug.LogWarning("Hours or minutes are outside of range... Automatically changing this. Hours: " + hours + "Minutes:" + minutes);
        }
        hours = Mathf.Clamp(hours, 0, 11);
        minutes = Mathf.Clamp(minutes, 0, 59);

        this.hours = hours;
        this.minutes = minutes;

        UpdateHands();
    }

    public override void Interact()
    {
        Debug.Log("It is currently : " + hours + ":" + minutes);
    }

    public void UpdateHands() {
        float anglePerDigit = 360 / 12;

        float hoursAngle = hours * anglePerDigit + minutes / 60f * anglePerDigit;
        Debug.Log(hoursAngle);
        Quaternion hoursRotation = Quaternion.Euler(hoursHand.localRotation.eulerAngles.x, hoursAngle, hoursHand.localRotation.eulerAngles.z);
        hoursHand.localRotation = hoursRotation;
        
        float minutesAngle = minutes / 5f * anglePerDigit;
        Debug.Log(minutesAngle);
        Quaternion minutesRotation = Quaternion.Euler(minutesHand.localRotation.eulerAngles.x, minutesAngle, minutesHand.localRotation.eulerAngles.z);
        minutesHand.localRotation = minutesRotation;
    }
}
