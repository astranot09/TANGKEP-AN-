using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StuffSpawnRate
{
    public GameObject stuff;
    public float rateGacha;
}

public class StuffSpawner : MonoBehaviour
{
    public List<StuffSpawnRate> stuffList;
    public float time = 1f;
    public Transform spawnPivot;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            StuffSpawnRate chosen = ChooseSpawnItem();
            if (chosen != null)
            {
                Instantiate(chosen.stuff, spawnPivot.position, Quaternion.identity);
            }
        }
    }

    private StuffSpawnRate ChooseSpawnItem()
    {
        float allRate = 0;
        foreach (var x in stuffList)
        {
            allRate += x.rateGacha;
        }
        float randomValue = Random.Range(0f, allRate);

        foreach (var x in stuffList)
        {
            randomValue -= x.rateGacha;
            if (randomValue <= 0f)
            {
                return x;
            }
        }

        return null; // fallback safety
    }
}
