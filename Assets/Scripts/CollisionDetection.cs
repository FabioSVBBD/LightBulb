using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public GameObject breakVersion;
    public float bforce;
    

    protected Rigidbody rb;

    private bool active = false;

   // public AudioSource shatterSound;
    [SerializeField] private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (rb.velocity.magnitude > bforce && !active)
        {
            active = true;
            Instantiate(breakVersion, transform.position, transform.rotation);
            rb.AddExplosionForce(5f, Vector3.zero, 2f);
            Invoke("EndGame", 0.01f);
          
        }
    }

    private void EndGame()
    {
       // shatterSound.Play();
        SoundManager.Instance.PlaySound(_clip);
        gameManager.GlowbCollided();
        
    }
}

