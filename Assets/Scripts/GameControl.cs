using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public RingTrigger ringTrigger;

    public Text pointText;
    public Text textClickStart;
    public Text textLevelEnd;

    public float point;
    float timer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            textClickStart.enabled = false;
        }

        pointText.text = "Score " + point;
        if(ringTrigger.levelComplete || ringTrigger.crashed)
        {
            BackToMenu();
        }

    }

    public void BackToMenu()
    {
        pointText.text = "";
        if (ringTrigger.levelComplete)
        {
            textLevelEnd.text = "Congratulations! \n Your Point : " + point;
        }
        else if (ringTrigger.crashed)
        {
            textLevelEnd.text = "Nice Try! \n Your Point : " + point;
        }
        timer += Time.deltaTime;
        if (timer > 3)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}