using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMove : MonoBehaviour {

    public static float grassMoveSpeed;
    float maxMove = -0.5f;

    Vector3 oldPosition;
	// Use this for initialization
	void Start () {
        oldPosition = transform.position;
        grassMoveSpeed = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * grassMoveSpeed * Time.deltaTime);
        if(transform.position.x < maxMove)
        {
            transform.position = oldPosition;
        }
    }
}
