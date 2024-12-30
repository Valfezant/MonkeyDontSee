using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float timeOffset;
    [SerializeField] Vector2 posOffset;

    private Vector3 velocity;

    //Limits1
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;

    // Update is called once per frame
    void Update()
    {
        /*
        //Camera's current position
        Vector3 startPos = transform.position;
        //Player's current position
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
        */
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);        
        
    }

    void OnDrawGizmos()
    {
        //Boundary lines color
        Gizmos.color = Color.red;
        
        //Boundary square1
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
