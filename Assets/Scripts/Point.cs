using UnityEngine;

public class Point : MonoBehaviour
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("PointCollect");
        }
    }
}
