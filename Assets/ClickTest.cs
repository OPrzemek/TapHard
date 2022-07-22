using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    private GameObject Buttons;
    RaycastHit hit;
    Ray ray;
    GameObject Button;
    public MeshRenderer Number;
    int c1, c2, c3;
    string buttonMaterial;

    void Awake()
    {
        Buttons = GameObject.Find("Buttons");
        Button = gameObject;
        if (Random.Range(1, 5) != 1) Button.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    void OnMouseDown()
    {
        buttonMaterial = Button.GetComponent<MeshRenderer>().sharedMaterial.name;
        c1 = Buttons.GetComponent<ButtonsMechanic>().currCount1;
        c2 = Buttons.GetComponent<ButtonsMechanic>().currCount2;
        c3 = Buttons.GetComponent<ButtonsMechanic>().currCount3;
        if (Number.sharedMaterial.name.Contains(Buttons.GetComponent<ButtonsMechanic>().NMaterials[c1].name) && buttonMaterial.Contains("button1"))
        {
            if (c1 == 9) Buttons.GetComponent<ButtonsMechanic>().currCount1 = 8;
            Buttons.GetComponent<ButtonsMechanic>().currCount1++;
            Button.SetActive(false);
        }
        else if (Number.sharedMaterial.name.Contains(Buttons.GetComponent<ButtonsMechanic>().NMaterials[c2].name) && buttonMaterial.Contains("button2"))
        {
            if (c2 == 9) Buttons.GetComponent<ButtonsMechanic>().currCount2 = 8;
            Buttons.GetComponent<ButtonsMechanic>().currCount2++;
            Button.SetActive(false);
        }
        else if (Number.sharedMaterial.name.Contains(Buttons.GetComponent<ButtonsMechanic>().NMaterials[c3].name) && buttonMaterial.Contains("button3"))
        {
            if (c3 == 9) Buttons.GetComponent<ButtonsMechanic>().currCount3 = 8;
            Buttons.GetComponent<ButtonsMechanic>().currCount3++;
            Button.SetActive(false);
        }
    }
}
