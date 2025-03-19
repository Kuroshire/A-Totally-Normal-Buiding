using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTimeBetweenFloors = 1f;
    [SerializeField] private bool canMoveX, canMoveY, canMoveZ;

    private bool isMoving = false;

    [ShowInInspector] private List<Vector3> targetList = new();

    public Action onArrivedAtFloor;

    public void AddPositionToTargetList(Vector3 target)
    {
        Vector3 targetPosition = new(
            canMoveX ? target.x : transform.position.x,
            canMoveY ? target.y : transform.position.y,
            canMoveZ ? target.z : transform.position.z
        );
        targetList.Add(targetPosition);
    }

    public void GoToNextFloorCalled()
    {
        if (isMoving == false && targetList.Count > 0)
        {
            StartCoroutine(MoveToPositionSmoothly(targetList[0]));
            targetList.RemoveAt(0);
        }
    }

    IEnumerator MoveToPositionSmoothly(Vector3 target)
    {
        isMoving = true;
        while (ComparePosition(transform.position, target) == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTimeBetweenFloors);
        isMoving = false;

        onArrivedAtFloor?.Invoke();
    }

    private bool ComparePosition(Vector3 a, Vector3 b, float tolerance = 0.1f)
    {
        return Vector3.Distance(a, b) < tolerance;
    }
}
