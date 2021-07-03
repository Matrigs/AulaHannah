using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public bool followOnlyHorizontal;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (!followOnlyHorizontal)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = new Vector3(
                                                                player.transform.position.x + offset.x,
                                                                transform.position.y,
                                                                transform.position.z);
        }
    }
}
