using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _smoothTime = 0.3f;
    [SerializeField] private float _yOffset;

    Vector2 velocity = Vector2.zero;
   
    void Update()
    {
        Vector2 targetPos = _target.transform.TransformPoint(new Vector3(0, _yOffset));

        if (targetPos.y < transform.position.y)
            return;

        targetPos = new Vector2(0, targetPos.y);
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, _smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
