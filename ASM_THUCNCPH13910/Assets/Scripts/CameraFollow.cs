using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
			//temp.y = player.position.y + 0.5f;
			if (temp.x < minX) {
                temp.x = minX;
			}else if (temp.x > maxX) {
                temp.x = maxX;
			}
            transform.position = temp;
		}
    }
}
