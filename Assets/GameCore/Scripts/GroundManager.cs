using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] List<Transform> grounds = new List<Transform>();
    [SerializeField] float speed = 3;
    [SerializeField] float length = 10.5f;

    private void Start()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        float timeToMove = length / speed;
        var wait = new WaitForSeconds(timeToMove);
        while (true)
        {
            yield return wait;
            if(GameStateManager.CurrentState == GameState.Play)
                Swarp();
        }
    }

    private void Swarp()
    {
        var first = grounds[0];
        var last = grounds[2];
        grounds.RemoveAt(0);

        first.position = last.position + Vector3.right * length;
        grounds.Add(first);
    }
}
