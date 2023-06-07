using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    private string hitobject;
    public int score=0;

    public TMP_Text txt;

    public GameObject obj;

    public static PlayerDeath Instance;

    void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(obj.gameObject);
        }
        else if(Instance!=this)
        {
            Destroy(obj.gameObject);
        }
    }


    void Start()
    {
    }

    void OnTriggerEnter(UnityEngine.Collider hit)
    {
        hitobject = hit.gameObject.tag;

        if(hitobject == "Food")
        {
            Destroy(hit.gameObject);
            score+=5;
            txt.text="Score: "+score.ToString();
            FindObjectOfType<AudioManager>().Play("food");
        }
        if(hit.name == "Door 1")
        {
            transform.position=new Vector3(-76.3f,3.57f,-66.3f);
        }
        if(hit.name == "Door 2")
        {
            transform.position=new Vector3(67.9f,3.57f,-66.3f);
        }
    }

    void OnCollisionEnter(UnityEngine.Collision hit)
    {
        hitobject = hit.gameObject.tag;
        
        if(hitobject == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

}

