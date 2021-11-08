using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject particleObj,targetParticle;
    public GameObject[] objectsToDisable,objectsToEnable;
    public GameObject[] portalObjsToMove;
    public GameObject newPortalTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            foreach (GameObject obj in objectsToDisable)
            {
                Destroy(obj);

            }
            foreach (GameObject portalObj in portalObjsToMove)
            {
                MovePortal(portalObj);
            }
            foreach (GameObject enableObj in objectsToEnable)
            {
                enableObj.SetActive(true);
            }

            Instantiate(particleObj, targetParticle.transform.position, targetParticle.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void MovePortal(GameObject ObjToMove)
    {
        Vector3 newPos = ObjToMove.transform.position;
        newPos.x = newPortalTarget.transform.position.x;
        ObjToMove.transform.position = newPos;
    }
}
