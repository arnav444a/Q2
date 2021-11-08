using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravController : MonoBehaviour
{
    float horizontalAx;
    bool canDash;
    public bool jump, isGrounded, dash, slam, can_jump,qPress;
    Rigidbody2D rb;
    public float speed = 10f, jumpForce = 5f, increasedGrav = 2f, dashForce = 5f, slamForce = 4f, dashCooldown = 2f;
    public Transform groundCheckPos;
    public GameObject death_obj;
    public AudioManager audioManager;
    [HideInInspector]
    public GameObject marker;

    EventControlMobile2 eventController;

    //public LayerMask groundLayer;
   public Vector2 playerVel;

    private void Awake()
    {
        eventController = FindObjectOfType<EventControlMobile2>();
        eventController.changeGrav = GetComponent<ChangeGravController>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        marker = this.gameObject;
        Time.timeScale = 1f;
    }

    void Update()
    {
        playerVel = rb.velocity;

        horizontalAx = Input.GetAxisRaw("Horizontal");


        if (qPress)
        {
            audioManager.Play("GravityChange");

            Physics2D.gravity *= -1;
            qPress = false;
        }

        /*
        slam = Input.GetKeyDown(KeyCode.S);
        
        if (slam && !isGrounded)
        {
            rb.AddForce(Vector2.down * 100 * slamForce);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }/
        if (Input.GetKeyDown(KeyCode.Z) && horizontalAx != 0)
        {
            if (timeEnd - timeStart > dashCooldown || canDash)
            {
                rb.AddForce(new Vector2(horizontalAx, 0) * dashForce);
                timeStart = Time.time;
                canDash = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0, -1) * increasedGrav);
        }
        transform.Translate(Vector2.right * horizontalAx * Time.fixedDeltaTime * speed);

        if (jump && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 100 * jumpForce);
            jump = false;
        }*/
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * horizontalAx * Time.fixedDeltaTime * speed);

    }
    private void OnDestroy()
    {
        GameObject enemyObj = Instantiate(death_obj, transform.position, transform.rotation);
        RandomForce[] enemyObjs = enemyObj.GetComponentsInChildren<RandomForce>();
        foreach (RandomForce enemyScript in enemyObjs)
        {
            enemyScript.playerRbVel = playerVel;
        }
        Time.timeScale = 0.75f;
        new WaitForSeconds(1f);
        Time.timeScale = 1f;
    }

    public void CameraShake()
    {

    }
}

