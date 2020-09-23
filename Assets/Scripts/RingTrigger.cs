using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public GameControl gameController;

    public bool levelComplete = false;
    public bool crashed = false;
    public bool pointAreaNotTouched;

    public int pointAreaTouchCount;

    Animation explodeAnim;

    private void Awake()
    {
        explodeAnim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            gameController.point++;
        }

        if (other.CompareTag("Finish"))
        {
            levelComplete = true;
        }

        if (other.CompareTag("CrashCheck"))
        {
            crashed = true;
            explodeAnim.Play("RingExplosion");
        }

        if (other.CompareTag("PointArea"))
        {
            pointAreaTouchCount++;
            pointAreaNotTouched = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            pointAreaNotTouched = true;
            other.gameObject.transform.parent.gameObject.SetActive(false);
            other.gameObject.transform.parent.transform.position = new Vector3(100, 0, 100);
        }
    }
}
