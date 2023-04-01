using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Transform playerPositionInWorld;
    public RawImage compassScrollImage;


    private void Start()
    {
        playerPositionInWorld = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        compassScrollImage = this.GetComponent<RawImage>();
    }
    
    // Update is called once per frame
    void Update()
    {
        compassScrollImage.uvRect = new Rect(playerPositionInWorld.localEulerAngles.y / 360,0,1,1);
    }
}
