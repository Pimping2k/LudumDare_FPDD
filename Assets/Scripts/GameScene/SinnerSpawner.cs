using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SinnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sinnerPrefab;
    [SerializeField] private SinnersCounterController _sinnersCounterController;
    private int maxSinner = 5;

    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(SpawnSinner());
    }

    IEnumerator SpawnSinner()
    {
        while (Container.sinnerCounter < 5)
        {
            targetPosition = new Vector3(Random.Range(-15, 0), 17, 5);
            Instantiate(sinnerPrefab, targetPosition, Quaternion.identity);
            _sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter+1);
            Container.sinnerCounter++;
            yield return new WaitForSeconds(5f);
        }
    }
}