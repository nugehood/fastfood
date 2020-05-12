using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeScript : MonoBehaviour
{
    [TextArea(5,2)]
    public string[] dialogue;
    int i;
    public GameObject[] endObj;
    public bool destroy;
    public GameObject[] desObj;

    public Text dialoguetxt, hint;
    

    bool isEnd;



    // Start is called before the first frame update
    void Start()
    {
        isEnd = true;   
        i = 0;
        dialoguetxt.text = dialogue[i].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isEnd)
        {
            Next();
        }
    }

    public void Next()
    {
        hint.text = null;
        i += 1;
        dialoguetxt.text = "";
        isEnd = false;
        StartCoroutine(dialog());
        if(i >= dialogue.Length)
        {
            for(int i = 0;i < endObj.Length; i++)
            {
                endObj[i].SetActive(true);
            }
            if (destroy)
            {
                for(int i =0;i< desObj.Length; i++)
                {
                    Destroy(desObj[i]); 
                }
            }
            Destroy(gameObject);
        }
    }

    public IEnumerator dialog()
    {
        foreach(char c in dialogue[i])
        {
            dialoguetxt.text += c.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        isEnd = true;
        hint.text = "SPACE";
        
    }
}
