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

    public AudioSource shatterSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!active)
        {
            active = true;
            Instantiate(breakVersion, transform.position, transform.rotation);
            rb.AddExplosionForce(5f, Vector3.zero, 2f);
            Invoke("EndGame", 0.01f);
          
        }
    }

    private void EndGame()
    {
        shatterSound.Play();
        gameManager.GlowbCollided();
        
    }
}

