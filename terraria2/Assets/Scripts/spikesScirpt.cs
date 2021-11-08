using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class spikesScirpt : MonoBehaviour
{
    public GameObject playerObj,target;
    public float respawnWaitTime=1.5f;
    public bool level1,fallKill;
    public bool gravityInvert,gravityWillChange;
    AudioManager audioManager;
    public GameObject deathParitcle;
    public CinemachineVirtualCamera vrcam;
    GameObject spawnedObj;
    public bool extraLevel;
    DeathAdController deathAdController;
    private CameraShake shaker;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        deathAdController = FindObjectOfType<DeathAdController>();
    }
    private void Start()
    {
        shaker = FindObjectOfType<CameraShake>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            shaker.CameraShaker(5f, 8f, 0f);

            deathAdController.AddDeath();
            Time.timeScale = 0.75f;
            if (!fallKill)
            {
                Instantiate(deathParitcle, collision.transform.position, transform.rotation);
            }
            audioManager.Play("Death");
            Destroy(collision.gameObject);

 

            StartCoroutine(WaitRespawn());
        }
    }
    public IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(respawnWaitTime);
        spawnedObj = Instantiate(playerObj, target.transform.position, target.transform.rotation);
        if (gravityInvert)
        {
            spawnedObj.GetComponent<ChangeGravController>().audioManager = audioManager;
        }
        if (extraLevel)
        {
            //
        }
        else
        {
            spawnedObj.GetComponent<Mover>().audioManager = audioManager;

        }
        if (gravityWillChange)
        {
            Physics2D.gravity = new Vector2(0, -9.81f);

        }
        if (!level1)
        {
            QtoKill newPlayerScript = spawnedObj.GetComponent<QtoKill>();
            newPlayerScript.targetObj = target;
            newPlayerScript.vrcam = vrcam;
            newPlayerScript.playerObj = playerObj;
        }
        Vector3 SettingZ = spawnedObj.transform.position;
        SettingZ.z = 0;
        spawnedObj.transform.position = SettingZ;
        vrcam.Follow = spawnedObj.transform;

        Time.timeScale = 1f;
    }
}
