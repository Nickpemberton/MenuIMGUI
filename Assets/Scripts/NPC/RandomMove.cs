using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_agent.destination, transform.position) < 2f)
        {
            //int x = Random.Range(0, 10); inclusive of first number but second num exclusive

            float randomX = Random.Range(-5f, 5f);
            float randomZ = Random.Range(-5f, 5f); // inclusive of both first number and second with float

            Vector3 randomPosition = new Vector3(transform.position.x + randomX,
                                                 transform.position.y,
                                                 transform.position.z + randomZ);

            _agent.destination = randomPosition;
        }
    }
}
