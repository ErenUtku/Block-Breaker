/*using System; */
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float RandomVelocity = 0.2f;


    Vector2 paddleToBallVector;
    bool hasStarted = false;
    // cached
    AudioSource myaudiosource;
    Rigidbody2D myrigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position-paddle1.transform.position;
        myaudiosource = GetComponent<AudioSource>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myrigidbody2D.velocity = new Vector2(xPush,yPush);
          
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
           /*x*/ (Random.Range(0f,RandomVelocity),
           /*y*/ Random.Range(0f,RandomVelocity));
   
        if (hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0,ballsounds.Length)];
            myaudiosource.PlayOneShot(clip);
            myrigidbody2D.velocity += velocityTweak;
        }
    }

}
