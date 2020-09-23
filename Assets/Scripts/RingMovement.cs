using UnityEngine;

public class RingMovement : MonoBehaviour
{
    public GameControl gameController;
    RingTrigger ringTrigger;

    public float speed, scaleSpeed;

    public Vector3 scaleChange;
    private Vector3 stayStill, startScaling;

    void Awake()
    {
        ringTrigger = GetComponent<RingTrigger>();
        stayStill = new Vector3(0, 0, 0);
        startScaling = new Vector3(0.005f, 0.005f, 0f);
        scaleChange = startScaling;
    }

    void FixedUpdate()
    {
        if (!ringTrigger.crashed)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Mouse0) && !ringTrigger.levelComplete)
            {
                transform.localScale -= scaleChange * scaleSpeed;
            }

            else if (transform.localScale.x < 1)
            {
                scaleChange = startScaling;
                transform.localScale += scaleChange * scaleSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cylinder"))
        {
            scaleChange = stayStill;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       if (collision.collider.CompareTag("Cylinder"))
       {
            scaleChange = startScaling;
       }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
