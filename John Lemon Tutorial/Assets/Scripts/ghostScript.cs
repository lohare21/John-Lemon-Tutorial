using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ghostScript : MonoBehaviour {

private NavMeshAgent Mob;
public GameObject Player;

public float MobDistanceRun = 4.0f;

void Start()
{
    Mob = GetComponent<NavMeshAgent>();
}
void Update()
{
    float distance = Vector3.Distance(transform.position, Player.transform.position);
    if (distance < MobDistanceRun)
    {
        Vector3 dirToPlayer = transform.position - Player.transform.position;
        Vector3 newPos = transform.position = dirToPlayer;
        Mob.SetDestination(newPos);
    }
}
}