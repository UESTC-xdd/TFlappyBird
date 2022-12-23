using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public GameManager GM;
    public AudioClip PointClip;

    [SerializeField]
    private AudioSource m_AudioSource;

    private void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GM.AddScore(1);
            m_AudioSource.PlayOneShot(PointClip);
        }
    }
}
