using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextScene + 1);
    }






}
