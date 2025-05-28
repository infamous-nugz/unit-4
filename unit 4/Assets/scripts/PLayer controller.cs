using System.Collections;
using UnityEngine;

public class PLayercontroller : MonoBehaviour
{
    public bool haspowerup = false;
    private Rigidbody playerRB;
    private float powerUpStrength = 10.0f;
    public float speed = 3;
    private GameObject focalPoint;
    public GameObject powerupIndictor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndictor.transform.position = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power up"))
        {
            haspowerup = true;
            powerupIndictor.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        haspowerup = false;
        powerupIndictor.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + haspowerup);
        }
    }
}
