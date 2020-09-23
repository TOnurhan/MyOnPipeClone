using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public RingTrigger ringTrigger;
    public Transform playerRing;

    public float distanceToCam;
    public Vector3 cameraPos, ringPos;


    void FixedUpdate()
    {
        if (!ringTrigger.levelComplete && !ringTrigger.crashed)
        {
            PlayerFollow();
        }
    }

    void PlayerFollow()
    {
        ringPos = playerRing.transform.position;
        cameraPos.z = ringPos.z - distanceToCam;
        transform.position = new Vector3(transform.position.x, transform.position.y, cameraPos.z);
    }
}
