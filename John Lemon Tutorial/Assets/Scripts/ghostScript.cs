using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ghostScript : MonoBehaviour {

private NavMeshAgent Mob;
public GameObject Player;
public float MobDistanceRun = 4.0f;

	void Start () {
        Mob = GetComponent<NavMeshAgent>();
        if (Player == null)
            Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //this is for updating the target location
        Mob.destination = Player.transform.position;
	}

    //function to detect when the ghost gets the player
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene("menu");
    }
}