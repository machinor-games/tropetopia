using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = 
                new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
	}
}
