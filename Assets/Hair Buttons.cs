using Michsky.MUIP;
using UnityEngine;

public class HairButtons : MonoBehaviour
{
    //public Sprite[] hair;

    //public GameObject buttonPrefab;

    public GameObject[] buttons;
    public HairSelector selector;

    void Start()
    {
        //for(int i = 0; i < 131; i++)
        //{
        //    GameObject g = Instantiate(buttonPrefab);
        //    g.transform.SetParent(gameObject.transform);

        //    g.GetComponent<ButtonManager>().buttonIcon = hair[i+1];
        //    //g.GetComponent<ButtonManager>().buttonScale = 1.4f;
        //}

        for (int i = 0; i < buttons.Length; i++)
        {  
            buttons[i].GetComponent<ButtonManager>().onClick.AddListener(() => selector.SwitchPart(i));
        }
    }
}
