using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class NoteTriger : MonoBehaviour
{
    private static NoteTriger instance;
    public static NoteTriger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<NoteTriger>();
            }
            return instance;
        }
    }

    private float del = 0.5f;

    [SerializeField]
    KeyCode keypos1;
    [SerializeField]
    KeyCode keypos2;
    [SerializeField]
    KeyCode keypos3;
    [SerializeField]
    KeyCode keypos4;

    public AudioClip A;
    public AudioClip B;
    public AudioClip C;
    public AudioClip D;
    private AudioSource audioSource;

    //public int Speed = 3;
    float YStart = 4f;
    float YEnd = -4f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < YStart && transform.position.y > YEnd && gameObject.tag == "A")
        {
            if (Input.GetKeyDown(keypos1))
            {
                audioSource.clip = A;
                audioSource.Play(0);
                Note.Instance.SpawnNote(1);
                GameController.Instance.Score += 1;
                StartCoroutine(Recycle());
            }
            
        }
        else if ( transform.position.y < YStart && transform.position.y > YEnd && gameObject.tag == "B")
        {
            if (Input.GetKeyDown(keypos2))
            {
                audioSource.clip = B;
                audioSource.Play(0);
                Note.Instance.SpawnNote(1);
                GameController.Instance.Score += 1;
                StartCoroutine(Recycle());
                
            }

        }
        else if (transform.position.y < YStart && transform.position.y > YEnd && gameObject.tag == "C")
        {
            if (Input.GetKeyDown(keypos3))
            {
                audioSource.clip = C;
                audioSource.Play(0);
                Note.Instance.SpawnNote(1);
                GameController.Instance.Score += 1;
                StartCoroutine(Recycle());
                
            }

        }
        else if (transform.position.y < YStart && transform.position.y > YEnd && gameObject.tag == "D")
        {
            if (Input.GetKeyDown(keypos4))
            {
                audioSource.clip = D;
                audioSource.Play(0);
                Note.Instance.SpawnNote(1);
                GameController.Instance.Score += 1;
                StartCoroutine(Recycle());
                
            }

        }
        if (transform.position.y < -5f)
        {
            GameController.Instance.IsDead = true; 
        }
    }
    public void EndGame()
    {
        
    }
        
    IEnumerator Recycle()
    {
        
        yield return new WaitForSeconds(del);
        UnityEngine.Debug.Log("RECYCLING...");

        switch (gameObject.name)
        {
            case "Note_Tail":
                Note.Instance.TopNote.Push(gameObject);
                gameObject.SetActive(false);
                break;
        }
    }
}
