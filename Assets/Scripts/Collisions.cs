using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{

    [SerializeField] AudioClip _crashSound;
    AudioSource audioSource;
    [SerializeField] ParticleSystem crashParticles;

    bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" && IsPlayerDead() == false)
        {
            isDead = true;
            crashParticles.Play();
            IsPlayerDead();
            audioSource.Stop();
            audioSource.PlayOneShot(_crashSound);
            StartCoroutine("CrashSequence");

        }

    }


    IEnumerator CrashSequence()
    {
        gameObject.GetComponent<Move>().enabled = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public bool IsPlayerDead()
    {
        if (isDead == true)
        {
            return true;
        }

        return false;
    }


}
