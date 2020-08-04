using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hit()
    {
        gameObject.SetActive(false);
        GameController.instance.PlatformHide();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameController.instance.GetMoveSpeed();
        Vector3 newPosition = transform.position;
        newPosition.x -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
