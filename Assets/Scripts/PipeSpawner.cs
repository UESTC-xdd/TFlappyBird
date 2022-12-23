using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePrefab;
    public float SpawnRate = 2;
    public float HeightOffset;

    private float m_Timer = 0;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if(m_Timer<SpawnRate)
        {
            m_Timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
        }

    }

    private void SpawnPipe()
    {
        float lowestY = transform.position.y - HeightOffset;
        float highestY = transform.position.y + HeightOffset;

        Instantiate(PipePrefab, new Vector3(transform.position.x, Random.Range(lowestY, highestY), transform.position.z), transform.rotation);
        m_Timer = 0;
    }
}
