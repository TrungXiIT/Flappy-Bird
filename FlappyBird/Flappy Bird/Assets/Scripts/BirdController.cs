using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float upPower;
    public float tiltSmooth;

    public GameObject gameController;

    Rigidbody2D myRigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    public AudioSource dieSound;
    public AudioSource tapSound;
    public AudioSource getScoreSound;

    bool isDead;
    bool isPipe;

    float veloDown;

	void Start () {
        upPower = 1.7f;
        tiltSmooth = 4f;
        myRigidbody = GetComponent<Rigidbody2D>();       

        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 30);

        isDead = false;
        isPipe = false;

        veloDown = -0.6f;
    }

    void Update()
    {
        if (transform.position.y < 1.26 && Input.GetMouseButtonDown(0) && isDead == false)
        {
            tapSound.Play();
            myRigidbody.velocity = Vector2.up * upPower;
        }
        if (myRigidbody.velocity.y > veloDown && GameController.isStart == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, forwardRotation, 20 * Time.deltaTime);
        }
        if (myRigidbody.velocity.y < veloDown)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.gameObject.tag)
        {
            case "DeadZone":
                if (isPipe == false)
                {
                    dieSound.Play();
                }

                GrassMove.grassMoveSpeed = 0;
                PipeController.pipeMoveSpeed = 0;

                isDead = true;
                isPipe = true;
                break;
            case "Grass":
                if (isPipe == false)
                {
                    dieSound.Play();
                }
                isDead = true;
                myRigidbody.simulated = false;
                gameController.GetComponent<GameController>().GameOver();
                break;
            case "ScoreZone":
                if (isDead == false)
                {
                    getScoreSound.Play();
                    gameController.GetComponent<GameController>().GetScore();
                }
                break;
        }
    }
}
