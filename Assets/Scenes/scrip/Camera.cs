using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;    
    public Vector3 minValues, maxValues;


    void FixedUpdate()
    {
        Follow();
    }

    
    void Follow()
    {
        Vector3 targetposition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetposition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetposition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetposition.z, minValues.z, maxValues.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
