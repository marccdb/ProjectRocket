using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody _rocketBody;
    AudioSource audioSource;
    Collisions collisions;

    [SerializeField] float _rotationSpeed = 100;
    [SerializeField] float _forceSpeed = 1000;
    [SerializeField] ParticleSystem mainThruster;

    [SerializeField] AudioClip _mainEngine;

    // Start is called before the first frame update
    void Start()
    {
        _rocketBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisions = GetComponent<Collisions>();

    }

    // Update is called once per frame
    void Update()
    {
        FlightSystem();

    }


    void FlightSystem()
    {
        float rotationMovement = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotationMovement);



        if (Input.GetKey(KeyCode.Space))
        {

            _rocketBody.AddRelativeForce(Vector3.up * _forceSpeed * Time.deltaTime);

            if (!audioSource.isPlaying && collisions.IsPlayerDead() == false)
            {
                audioSource.PlayOneShot(_mainEngine);
                mainThruster.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainThruster.Stop();
        }

    }


}
