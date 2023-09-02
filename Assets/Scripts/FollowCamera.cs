using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    BoxCollider2D bound;

    Camera followCam;
    Vector3 minBound;
    Vector3 maxBound;

    float halfWidth;
    float halfHeight;

    Vector3 targetPos;


    private void Start()
    {
        followCam = GetComponent<Camera>();

        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = followCam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        

    }

    void Update()
    {
        if(target != null)
        {
            targetPos.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed*Time.deltaTime);

            float clampedX = Mathf.Clamp(transform.position.x,minBound.x+ halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y,minBound.y+ halfHeight, maxBound.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
