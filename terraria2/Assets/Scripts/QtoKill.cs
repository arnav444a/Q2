using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class QtoKill : MonoBehaviour
{
    public float respawnWaitTime=1f;
    public GameObject playerObj, targetObj,deathObj;
    GameObject spawnedObj;
    public CinemachineVirtualCamera vrcam;
    Rigidbody2D rb;

    public AudioManager audioManager;
    [HideInInspector]
    public BoxCollider2D boxCol;
    [HideInInspector]
    public SpriteRenderer sprite;
    public bool deathQ;
    private void Awake()
    {
        EventControlMobile eventMobile = FindObjectOfType<EventControlMobile>();
        eventMobile.death = GetComponent<QtoKill>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();
 

    }
    private void Update()
    {
        if (deathQ)
        {
            sprite.enabled = false;
            GameObject enemyObj = Instantiate(deathObj, transform.position, transform.rotation);
            RandomForce[] enemyObjs = enemyObj.GetComponentsInChildren<RandomForce>();
            foreach (RandomForce enemyScript in enemyObjs)
            {
                enemyScript.playerRbVel = rb.velocity;
            }
            Time.timeScale = 0.75f;
            StartCoroutine(WaitRespawn());
            deathQ = false;
        }
    }
    public IEnumerator WaitRespawn()
    {
        audioManager.Play("Death");
        yield return new WaitForSeconds(respawnWaitTime);

        spawnedObj = Instantiate(playerObj, targetObj.transform.position, targetObj.transform.rotation);
        Vector3 targetPos = spawnedObj.transform.position;
        targetPos.z = 0;
        spawnedObj.transform.position = targetPos;
        QtoKill newPlayerScript = spawnedObj.GetComponent<QtoKill>();
        newPlayerScript.vrcam = vrcam;
        newPlayerScript.targetObj = targetObj;
        newPlayerScript.deathObj = deathObj;
        newPlayerScript.playerObj = playerObj;
        vrcam.Follow = spawnedObj.transform;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
