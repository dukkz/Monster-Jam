using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour {

	public List<Transform> routeVectors;
	public float targetRange;

	Transform target;
	NavMeshAgent agent;
	int routeIndex;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = this.GetComponent<NavMeshAgent> ();
		if (routeVectors.Count >= 2) {
			routeIndex = 0;
			SetDestination ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((target.transform.position - transform.position).magnitude <= targetRange) {
			//Start tracking and following.
			agent.SetDestination(target.position);
		} else {
			//Just follow route.
			if(agent.remainingDistance <= 1f){
				ChangeRoutePoint ();
				SetDestination ();
			}
		}
	}

	void SetDestination(){
		Vector3 targetVector = routeVectors [routeIndex].transform.position;
		agent.SetDestination (targetVector);
	}

	void ChangeRoutePoint(){
		routeIndex = (routeIndex + 1) % routeVectors.Count;
	}
}
