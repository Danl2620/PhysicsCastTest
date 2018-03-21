using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour 
{

    public float radius;
    public float distance;
    public LayerMask layerMask;
    public float maxDistance;

    public GameObject currentGameObject;
    public float currentHitDistance;
    public Vector3 currentHitPoint;

    private Vector3 start;
    private Vector3 direction;

	// Use this for initialization
	//void Start () 
 //   {
		
	//}
	
	// Update is called once per frame
	void Update () 
    {
        start = transform.position;
        direction = transform.forward;

        //RaycastHit[] hit;
        //hit = Physics.SphereCastAll(transform.position, radius, transform.position + transform.forward * distance, maxDistance, layerMask, QueryTriggerInteraction.Collide);
        //bool hits = hit.Length > 0;


        RaycastHit hit;
        bool hits = Physics.SphereCast(start, radius, start + direction * distance, out hit, maxDistance, layerMask);
        //bool hits = Physics.Raycast(start, direction, out hit, maxDistance, layerMask);
        if (hits)
        {
            
            currentGameObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            currentHitPoint = hit.point;
        }
        else
        {
            currentGameObject = null;
            currentHitDistance = maxDistance;
            currentHitPoint = Vector3.zero;
        }
	}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //var xform = transform;
        //var pos = xform.position;
        //var dir = Vector3.down;
        //var dir = xform.forward;

        //Debug.DrawRay(pos, xform.right, Color.red);
        //Debug.DrawRay(pos, xform.forward, Color.blue);
        //Debug.DrawRay(pos, xform.up, Color.green);

        Debug.DrawLine(start, start + direction * currentHitDistance, Color.blue);
        Gizmos.DrawWireSphere(start + direction * currentHitDistance, radius);
        //Gizmos.DrawWireSphere(currentHitPoint, radius);
    }
}
