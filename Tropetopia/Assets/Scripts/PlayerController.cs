using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private bool onGround;

    public int health, speed, damage;
    public float jumpHeight;

    enum states {IDLE, RUN, JUMP, CROUCH};
    states currentState;

    public GameObject playerAnimator;
    public GameObject[] healthPoints;

    Animator anim;
    Rigidbody2D rb;

    private Vector3 lastJump;
	// Use this for initialization
	void Start ()
    {
        currentState = states.IDLE;
        anim = playerAnimator.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (onGround)
                currentState = states.RUN;
            else
                currentState = states.JUMP;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (onGround)
                currentState = states.RUN;
            else
                currentState = states.JUMP;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (onGround)
                currentState = states.CROUCH;
        }
        else
        {
            if (onGround)
                currentState = states.IDLE;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            // transform.position += Vector3.up * speed * Time.deltaTime;
            if (onGround && currentState != states.JUMP)
            {
               
                currentState = states.JUMP;
                if(currentState == states.RUN)
                    rb.AddForce(jumpHeight * 1.5f * Vector3.up);
                else
                    rb.AddForce(jumpHeight * Vector3.up);
            }
           
        }
       
    }
    void FixedUpdate()
    {
        CheckGround();
        StateCheck();
    }
    void OnCollisionEnter(Collider other)
    {
        
    }
    void CheckGround()
    {
        int layermask = 1 << 8;
        layermask = ~layermask;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, layermask);
        if (hit)
        {

            onGround = true;
            if (hit.transform.gameObject.tag == "Damage")
            {
                health--;
                if (health <= 0)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                else
                {
                    transform.position = lastJump;
                    healthPoints[health].SetActive(false);
                }
              
            }
            else
                lastJump = transform.position;
        }
        else
            onGround = false;
        Debug.Log(onGround);
    }
    void StateCheck()
    {
        if (currentState == states.CROUCH)
            OnCrouch();
        else if (currentState == states.IDLE)
            OnIdle();
        else if (currentState == states.JUMP)
            OnJump();
        else if (currentState == states.RUN)
            OnRun();
    }
    public void OnIdle() { anim.SetBool("idle", true);
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        anim.SetBool("crouch", false); }

    public void OnRun()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", true);
        anim.SetBool("jump", false);
        anim.SetBool("crouch", false);
    }

    public void OnJump()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", false);
        anim.SetBool("jump", true);
        anim.SetBool("crouch", false);
    }

    public void OnCrouch()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        anim.SetBool("crouch", true);
    }

}
