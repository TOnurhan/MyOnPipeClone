using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public RingTrigger RingTrigger;
    public RingMovement ring;

    public List<GameObject> levelParts;

    public GameObject startPart, finishPart;
    GameObject selectedLevelPart;

    Vector3 spawnPosition;
    Vector3 poolPosition;

    public float playerDistance = 5f;
    public int pointAreaForLevel;

    bool spawnFinishPart = true;

    private void Awake()
    {
        poolPosition = new Vector3(100, 0, 100);
    }
    void Start()
    {

        for (int i = 0; i < levelParts.Count; i++)
        {
            levelParts[i] = Instantiate(levelParts[i], poolPosition, Quaternion.identity);
            levelParts[i].SetActive(false);
        }

        spawnPosition = startPart.transform.GetChild(0).position;
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, ring.GetPosition()) < playerDistance)
        {
            if (RingTrigger.pointAreaTouchCount < pointAreaForLevel)
            {
                SpawnLevelPart();
            }
            else if(spawnFinishPart)
            {
                Instantiate(finishPart, spawnPosition + new Vector3(0, 0, 15), Quaternion.identity);
                spawnFinishPart = false;
            }
        }
    }

    public void SpawnLevelPart()
    {
        selectedLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        if (!selectedLevelPart.activeInHierarchy)
        {
            selectedLevelPart.transform.position = spawnPosition + new Vector3(0, 0, 10);
            selectedLevelPart.SetActive(true);
            spawnPosition = selectedLevelPart.transform.GetChild(0).position;
        }
    }
}
