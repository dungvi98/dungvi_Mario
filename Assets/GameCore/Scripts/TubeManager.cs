using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeManager : MonoBehaviour
{
    [SerializeField] TubeController tubePrefab;
    [SerializeField] Transform beginSpawnPoint;
    [SerializeField] float distancePerTube = 5;


    [SerializeField] Transform playerTf = null;
    [SerializeField] float distanceToDestroy = 10;
    [SerializeField] float distanceToSpawn = 10;

    List<TubeController> tubes = new List<TubeController>();

    private Vector3 beginPosition;
    void Start()
    {
        beginPosition = beginSpawnPoint.localPosition;
        StartCoroutine(DoSpawn());
        StartCoroutine(DoDestroy());
    }
    IEnumerator DoDestroy()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            CheckToDestroy();
            yield return wait;
        }
    }
    private void CheckToDestroy()
    {
        if (tubes.Count <= 0)
            return;
        var first = tubes[0];
        var distance = playerTf.position.x - first.transform.position.x;
        if (distance >= distanceToDestroy)
        {
            Destroy(first.gameObject);
            tubes.RemoveAt(0);
        }

    }
    IEnumerator DoSpawn()
    {
        var wait = new WaitForSeconds(1);
        while (true)
        {
            CheckToSpawn();
            yield return wait;
        }
    }
    private void CheckToSpawn()
    {
        if (tubes.Count <= 0)
        {
            SpawnTube();
            return;
        }
        var last = tubes[tubes.Count - 1];
        var distance = last.transform.position.x - playerTf.position.x;
        if (distance < distanceToSpawn)
        {
            SpawnTube();
        }
    }
    private void SpawnTube()
    {
        beginPosition.y = Random.Range(-2, 5);
        var tube = Instantiate<TubeController>(tubePrefab, transform);
        tube.transform.localPosition = beginPosition;
        tube.Init(4);

        beginPosition += Vector3.right * distancePerTube;

        tubes.Add(tube);
    }
}
