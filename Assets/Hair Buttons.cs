using Michsky.MUIP;
using UnityEngine;

public class HairButtons : MonoBehaviour
{
    public Sprite[] hair;

    public GameObject buttonPrefab;

    void Start()
    {
        for(int i = 0; i < 131; i++)
        {
            GameObject g = Instantiate(buttonPrefab);
            g.transform.SetParent(gameObject.transform);

            g.GetComponent<ButtonManager>().buttonIcon = hair[i+1];
            //g.GetComponent<ButtonManager>().buttonScale = 1.4f;
        }
    }
}
