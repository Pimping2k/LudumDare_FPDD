using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject peoplePrefab;

    private void Start()
    {
        StartCoroutine(SpawnPeople());
    }

    IEnumerator SpawnPeople()
    {
        while (true)
        {
            Vector3 peoplePosition = new Vector3(Random.Range(-20, 20), Random.Range(30,35), Random.Range(-2, 40));
            
            GameObject spawnedPeople = Instantiate(peoplePrefab, peoplePosition, new Quaternion(90,0,0,0));

            StartCoroutine(CheckAndDestroy(spawnedPeople));

            yield return new WaitForSeconds(Random.Range(3f,4f));
        }
    }

    IEnumerator CheckAndDestroy(GameObject spawnedPeople)
    {
        while (spawnedPeople != null)
        {
            if (spawnedPeople.transform.position.y <= -3)
            {
                Destroy(spawnedPeople);
            }
            yield return null; 
        }
    }
}