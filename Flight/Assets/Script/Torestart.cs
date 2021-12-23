using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Torestart : MonoBehaviour{
public int Score;
public Text ScoreText;
  void Start(){
    Debug.Log("hello");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="end")
        {
        SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Score++;
            ScoreText.text="Score- "+Score.ToString();
        }
    }
}


