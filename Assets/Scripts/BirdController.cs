using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float FlatStrength;
    public float MaxFlyHeight = 25;
    public float MinFlyHeight = -25;
    public Rigidbody2D m_Rigidbody;

    public GameManager GM;
    public bool birdIsAlive = true;

    [SerializeField]
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive && transform.position.y < MaxFlyHeight)
        {
            m_Rigidbody.velocity = Vector2.up * FlatStrength;
            m_AudioSource.Play();
        }

        if (transform.position.y < MinFlyHeight)
        {
            BirdCrash();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdCrash();
    }

    private void BirdCrash()
    {
        GM.GameOver();
        birdIsAlive = false;
    }
}
