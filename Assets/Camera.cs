using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player;
    Vector3 tempVec3 = new Vector3();
    private float offset = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempVec3.y = player.position.y + offset;
        tempVec3.x = this.transform.position.x;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}
