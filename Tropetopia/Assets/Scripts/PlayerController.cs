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
            StartCoroutine(animator.Anim(animator.idle));
	}	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(animator.Anim(animator.idle));
        }
        if(Input.GetKey(KeyCode.S))
        {
            StartCoroutine(animator.Anim(animator.idle));
        }
	}
}
