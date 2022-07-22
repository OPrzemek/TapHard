using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMechanic : MonoBehaviour
{
    List<GameObject> Buttons = new List<GameObject>();
    List<GameObject> Numbers = new List<GameObject>();
    public Text winText;
    public Material m1, m2, m3; //Materiały pudełek do kliknięcia
    private Material n0, n1, n2, n3, n4, n5, n6, n7, n8, n9; //Materiały numerów
    private int clrCount1, clrCount2, clrCount3;
    public int currCount1, currCount2, currCount3;
    public List<Material> NMaterials = new List<Material>();
    void Awake()
    {
        clrCount1 = 0;
        clrCount2 = 0;
        clrCount3 = 0;
        currCount1 = 0;
        currCount2 = 0;
        currCount3 = 0;
        m1 = Resources.Load<Material>("Materials/button1");
        m2 = Resources.Load<Material>("Materials/button2");
        m3 = Resources.Load<Material>("Materials/button3");
        n0 = Resources.Load<Material>("Numbers/0");
        n1 = Resources.Load<Material>("Numbers/1");
        n2 = Resources.Load<Material>("Numbers/2");
        n3 = Resources.Load<Material>("Numbers/3");
        n4 = Resources.Load<Material>("Numbers/4");
        n5 = Resources.Load<Material>("Numbers/5");
        n6 = Resources.Load<Material>("Numbers/6");
        n7 = Resources.Load<Material>("Numbers/7");
        n8 = Resources.Load<Material>("Numbers/8");
        n9 = Resources.Load<Material>("Numbers/9");
        NMaterials.Add(n0);
        NMaterials.Add(n1);
        NMaterials.Add(n2);
        NMaterials.Add(n3);
        NMaterials.Add(n4);
        NMaterials.Add(n5);
        NMaterials.Add(n6);
        NMaterials.Add(n7);
        NMaterials.Add(n8);
        NMaterials.Add(n9);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
        {
            if(button.activeSelf) Buttons.Add(button);
        }
        foreach (GameObject number in GameObject.FindGameObjectsWithTag("Number"))
        {
            Numbers.Add(number);
        }
        for (int i = 0; i < Buttons.Count; i++)
        {
            int min = 1;
            int max = 4;
            if (clrCount1 >= 10) { clrCount1 = 9; min++; }
            if (clrCount2 >= 10) clrCount2 = 9;
            if (clrCount3 >= 10) { clrCount3 = 9; max--; }
            switch (Random.Range(min, max))
            {
                case 1:
                    Buttons[i].GetComponent<MeshRenderer>().sharedMaterial = m1;
                    Numbers[i].GetComponent<MeshRenderer>().sharedMaterial = NMaterials[clrCount1++];
                    break;
                case 2:
                    Buttons[i].GetComponent<MeshRenderer>().sharedMaterial = m2;
                    Numbers[i].GetComponent<MeshRenderer>().sharedMaterial = NMaterials[clrCount2++];
                    break;
                case 3:
                    Buttons[i].GetComponent<MeshRenderer>().sharedMaterial = m3;
                    Numbers[i].GetComponent<MeshRenderer>().sharedMaterial = NMaterials[clrCount3++];
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Main");
        foreach(GameObject button in Buttons.ToArray())
        {
            if (!button.activeSelf) Buttons.Remove(button);
        }
        if (Buttons.Count == 0) winText.gameObject.SetActive(true);
    }
}
