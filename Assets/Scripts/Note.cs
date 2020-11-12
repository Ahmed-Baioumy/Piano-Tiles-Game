using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public GameObject Notes;
    public GameObject CurrentNote;

    public Stack<GameObject> TopNote = new Stack<GameObject>();

    private static Note instance;
    public static Note Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Note>();
            }
            return instance;
        }
    }

    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;

    // Start is called before the first frame update
    void Start()
    {
        CreatNote(100);
        SpawnNote(20);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CreatNote(int NoteAmount)
    {
        for (int i = 0; i <= NoteAmount; i++)
        {
            TopNote.Push(Instantiate(Notes));
            TopNote.Peek().name = "Note_Tail";
            TopNote.Peek().SetActive(false);
        }

    }
    public void SpawnNote(int x)
    {
        int RandomIndex;
        GameObject temp1 = null;
        for (int i = 0; i < x; i++)
        {
            RandomIndex = UnityEngine.Random.Range(0, 4);

            temp1 = TopNote.Pop();
            temp1.SetActive(true);
            temp1.transform.position = CurrentNote.transform.GetChild(0).position;
            
            if (RandomIndex == 0)
            {
                temp1.transform.position = new Vector3(-1.8f, temp1.transform.position.y, temp1.transform.position.z);
                temp1.gameObject.tag = "A";
                temp1.GetComponent<MeshRenderer>().material = Material1;
            }
            else if (RandomIndex == 1)
            {
                temp1.transform.position = new Vector3(-0.6f, temp1.transform.position.y, temp1.transform.position.z);
                temp1.gameObject.tag = "B";
                temp1.GetComponent<MeshRenderer>().material = Material2;
            }
            else if (RandomIndex == 2)
            {
                temp1.transform.position = new Vector3(0.6f, temp1.transform.position.y, temp1.transform.position.z);
                temp1.gameObject.tag = "C";
                temp1.GetComponent<MeshRenderer>().material = Material3;
            }
            else if (RandomIndex == 3)
            {
                temp1.transform.position = new Vector3(1.8f, temp1.transform.position.y, temp1.transform.position.z);
                temp1.gameObject.tag = "D";
                temp1.GetComponent<MeshRenderer>().material = Material4;
            }
            CurrentNote = temp1;
        }
    }
}
