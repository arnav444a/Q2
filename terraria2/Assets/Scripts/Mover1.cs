using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mover1 : MonoBehaviour
{
    float horizontalAx,timeStart,timeEnd;
    bool canDash,shakeCam;
    public bool jump,isGrounded,dash,slam,can_jump,canMove,SwitchMoveStyles;
    Rigidbody2D rb;
    public float speed = 10f,jumpForce = 5f,increasedGrav=2f,dashForce=5f,slamForce=4f,dashCooldown = 2f,timeJumpStart;
    public Transform groundCheckPos,topGroundCheck;
    public GameObject death_obj;

    [HideInInspector]
    public GameObject marker;

    public LayerMask groundLayer;
    public Vector2 playerVel;

    public AudioManager audioManager;
    public GameObject DashParticle,JumpParticle,LandParticle;
    [Header("Shaker")]
    public float shakeTime = 2f, fadeCamShake = 2f,maxAmplitude = 4f,minAmplitude = 0f;
    CameraShake shaker;
    float starter,ender;

    public Joystick joystick;
    public EventControlMobile1 eventController;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        joystick = FindObjectOfType<FixedJoystick>();
        eventController = FindObjectOfType<EventControlMobile1>();
        eventController.playerScript = GetComponent<Mover1>();

    }
    void Start()
    {
        shaker = FindObjectOfType<CameraShake>();
        rb = GetComponent<Rigidbody2D>();
        timeStart = Time.time;
        marker = this.gameObject;
        Time.timeScale = 1f;
    }

    void Update()
    {

        timeEnd = Time.time;
        playerVel = rb.velocity;

        bool negativeGrav = Physics2D.gravity.y <0f;
        if ((Physics2D.OverlapCircle(groundCheckPos.position, 0.3f, groundLayer) && negativeGrav) || (Physics2D.OverlapCircle(topGroundCheck.position, 0.3f, groundLayer) && !negativeGrav))
        {
            starter = Time.time;
            isGrounded = true;
            canDash = true;
            canMove = true;
            if (shakeCam)
            {
                Instantiate(LandParticle, transform.position, transform.rotation);

                shaker.CameraShaker(fadeCamShake,maxAmplitude,minAmplitude);
                shakeCam = false;
            }
        }
        else
        {
            ender = Time.time;
            isGrounded = false;
            if (SwitchMoveStyles)
            {
                canMove = false;
            }
        }

        if ((ender - starter) > shakeTime)
        {
            shakeCam = true;
        }
        if (joystick.Horizontal >= 0.4f)
        {
            horizontalAx = 1f;
        }
        else if (joystick.Horizontal <= -0.4f)
        {
            horizontalAx = -1f;
        }
        else
        {
            horizontalAx = 0f;
        }

        float verticalJoystick = joystick.Vertical;
        if (verticalJoystick >= 0.8f)
        {
            jump = true;
            timeJumpStart = Time.time;
        }


        slam = Input.GetKeyDown(KeyCode.S);
        if(slam && !isGrounded)
        {
            rb.AddForce(Vector2.down * 100 * slamForce);
        }

       /* if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            timeJumpStart = Time.time;
        }
       */
        if (dash && (Mathf.Abs(horizontalAx)>0))
        {
            if (timeEnd - timeStart > dashCooldown || canDash)
            {
                rb.AddForce(new Vector2(horizontalAx, 0) * dashForce);
                audioManager.Play("Dash");
                if(horizontalAx >0.01f)
                {
                    GameObject particleDash = Instantiate(DashParticle, transform.position, transform.rotation);
                    particleDash.transform.localScale = new Vector3(-1,1,1);
                }
                else if(horizontalAx<0.01f)
                {
                    Instantiate(DashParticle, transform.position, transform.rotation);
                }
                shaker.CameraShaker(5f , 6f, 0f);
                timeStart = Time.time;
                canDash = false;
            }
            dash = false;
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0 && Physics2D.gravity.y==-9.81f && !isGrounded)
        {
            rb.AddForce(new Vector2(0, -1)*increasedGrav);
        }
        else if(rb.velocity.y > 0 && Physics2D.gravity.y == 9.81f && !isGrounded)
        {
            rb.AddForce(new Vector2(0, 1) * increasedGrav);
        }
        transform.Translate(Vector2.right * horizontalAx * Time.fixedDeltaTime * speed);

        if (jump && isGrounded && Time.time - timeJumpStart<=0.2f)
        {
            audioManager.Play("Jump");
            shaker.CameraShaker(5f, 6f, 0f);

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 100 * jumpForce * -Mathf.Clamp(Physics2D.gravity.y, -1f, 1f));
            Debug.Log(-Mathf.Clamp(Physics2D.gravity.y, -1f, 1f));
            if (Physics2D.gravity.y == -9.81f)
            {
                Instantiate(JumpParticle, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(JumpParticle, transform.position, transform.rotation).transform.localScale*=-1f;
            }

            jump = false;
        }
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

}
