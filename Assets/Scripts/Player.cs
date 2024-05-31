using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject targetGameObject;

    public float speed = 50.0f;

    void Update()
    {

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = targetGameObject.transform.position;


        float newX = Mathf.MoveTowards(currentPosition.x, targetPosition.x, speed * Time.deltaTime);
        float newY = Mathf.MoveTowards(currentPosition.y, targetPosition.y, speed * Time.deltaTime);
        float newZ = Mathf.MoveTowards(currentPosition.z, targetPosition.z, speed * Time.deltaTime);

        transform.position = new Vector3(newX, newY, newZ);

        Vector3 directionToTarget = targetPosition - transform.position;

        var target = ((Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg) + 360) % 360;

        transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.Lerp(transform.eulerAngles.z, target, 500 * Time.deltaTime));
    }
}
