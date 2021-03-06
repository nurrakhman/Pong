using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;
    public float randomX;
    public float randomY;
    public float speed;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {

        trajectoryOrigin = transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //// Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        //float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        //// Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        //float randomDirection = Random.Range(0, 2);

        //// Jika nilainya di bawah 1, bola bergerak ke kiri. 
        //// Jika tidak, bola bergerak ke kanan.
        //if (randomDirection < 1.0f)
        //{
        //    // Gunakan gaya untuk menggerakkan bola ini.
        //    rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        //}
        //else
        //{
        //    rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        //}

        randomX = Random.Range(-xInitialForce, xInitialForce);
        randomY = Random.Range(-yInitialForce, yInitialForce);
        rigidBody2D.AddForce(new Vector2(randomX, randomY).normalized * speed);

    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
