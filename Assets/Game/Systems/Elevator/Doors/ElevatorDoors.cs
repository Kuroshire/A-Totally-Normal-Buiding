using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    [SerializeField] private Transform rightDoor, leftDoor;
    public float openScaleZ = 0.1f; // Taille Z lorsque la porte est ouverte
    public float closedScaleZ = 1f; // Taille Z lorsque la porte est fermée
    public float openSpeed = 2f; // Vitesse d'ouverture/fermeture
    public float closeDelay = 2f; // Temps avant fermeture automatique

    private bool isMoving = false;

    public event Action OnDoorsOpened;
    public event Action OnDoorsClosed;

    void Start()
    {
        // Assurer que la porte commence fermée
        rightDoor.localScale = leftDoor.localScale = new Vector3(transform.localScale.x, transform.localScale.y, closedScaleZ);
    }

    public void OpenDoors()
    {
        if (!isMoving)
        {
            StartCoroutine(ChangeScaleZ(openScaleZ, OnDoorsOpened));
        }
    }

    public void CloseDoors()
    {
        if (!isMoving)
        {
            StartCoroutine(ChangeScaleZ(closedScaleZ, OnDoorsClosed));
        }
    }


    private IEnumerator ChangeScaleZ(float targetScaleZ, Action onComplete)
    {
        isMoving = true;
        Vector3 startScale = rightDoor.localScale;
        Vector3 targetScale = new(startScale.x, startScale.y, targetScaleZ);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            rightDoor.localScale = leftDoor.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        rightDoor.localScale = leftDoor.localScale = targetScale; // Assurer la valeur finale exacte
        isMoving = false;
        onComplete?.Invoke();
    }

    private float timerSinceOpened = 0f;
    void FixedUpdate()
    {
        if(rightDoor.localScale.z == openScaleZ) {
            timerSinceOpened += Time.fixedDeltaTime;
            if(timerSinceOpened >= closeDelay) {
                CloseDoors();
                timerSinceOpened = 0f;
            }
        } else {
            timerSinceOpened = 0f;
        }
    }
}
