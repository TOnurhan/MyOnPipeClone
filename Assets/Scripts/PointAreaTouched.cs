using UnityEngine;

public class PointAreaTouched : MonoBehaviour
{
    RingTrigger RingTrigger;
    Collider pointArea;

    private void Awake()
    {
        RingTrigger = GameObject.Find("Ring").GetComponent<RingTrigger>();
        pointArea = GetComponent<Collider>();
    }
    private void Update()
    {
        if (!RingTrigger.pointAreaNotTouched)
        {
            pointArea.enabled = false;
        }
        else
        {
            pointArea.enabled = true;
        }
    }
}