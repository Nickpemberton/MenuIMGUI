using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public rotMode camMove;
    
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (camMove == rotMode.LockedN)
        {
            transform.position = new Vector3(playerPos.position.x,transform.position.y,playerPos.position.z);
            transform.rotation = Quaternion.Euler(90, 0, 0);

        }
        if (camMove == rotMode.playerRot)
        {
            transform.position = new Vector3(playerPos.position.x,transform.position.y,playerPos.position.z);
            transform.rotation = Quaternion.Euler(90, playerPos.eulerAngles.y, 0);
        }
        if (camMove == rotMode.playerRotOffset)
        {
            transform.position = new Vector3(playerPos.position.x,playerPos.position.y + 50f,playerPos.position.z);
            transform.rotation = Quaternion.Euler(90, playerPos.eulerAngles.y, 0);
        }
        if (camMove == rotMode.LockedNOffset)
        {
            transform.position = new Vector3(playerPos.position.x,playerPos.position.y + 50f,playerPos.position.z);
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

    public enum rotMode
    {
        playerRot,
        LockedN,
        LockedNOffset,
        playerRotOffset
        
    }
    
}
