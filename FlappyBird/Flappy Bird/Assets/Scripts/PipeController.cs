using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    public static float pipeMoveSpeed;

    float maxY = -0.27f;
    float minY = -1.311f;
    const float respawnPos = 2.4f;

    void Start()
    {
        pipeMoveSpeed = 0.5f;

    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * pipeMoveSpeed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RespawnZone")
        {
            transform.position = new Vector2(respawnPos, Random.Range(minY, maxY));
        }
    }
}
