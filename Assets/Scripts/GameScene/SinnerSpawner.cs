using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SinnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sinnerPrefab;
    [SerializeField] private SinnersCounterController _sinnersCounterController;
    [SerializeField] private SatanPleasureComponent _satanPleasureComponent;
    
    private int maxSinner = 5;

    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(SpawnSinner());
    }

    IEnumerator SpawnSinner()
    {
        while (Container.sinnerCounter < maxSinner)
        {
            targetPosition = new Vector3(Random.Range(-15, 0), 17, 5);
            GameObject sinner = Instantiate(sinnerPrefab, targetPosition, Quaternion.identity);
            _sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter);
            Container.sinnerCounter++;
            StartCoroutine(CheckAndDestroy(sinner));
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator CheckAndDestroy(GameObject sinner)
    {
        while (sinner != null)
        {
            if (sinner.transform.position.y < -3)
            {
                _satanPleasureComponent.TakeDamage(0.2f);
                Container.sinnerCounter--;
                _sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter);
                Destroy(sinner); 
            }
            yield return null;
        }
    }
}