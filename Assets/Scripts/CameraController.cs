using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    // Start is called before the first frame update
    public float zoomSpeed = 5;
    private Vector3 offset;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;

        //滚轮放大缩小视野
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll*zoomSpeed;

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 50, 95);
    }
}
