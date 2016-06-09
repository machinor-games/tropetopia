using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    PlayerAnimator animator;
	// Use this for initialization
    void Awake ()
    {
        animator = gameObject.GetComponent<PlayerAnimator>();
    }
	void Start ()
    {
        if (animator != null)
            StartCoroutine(animator.IdleAnim());
	}	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(animator.IdleAnim());
        }
        if(Input.GetKey(KeyCode.S))
        {
            StartCoroutine(animator.IdleAnim());
        }
	}
}
