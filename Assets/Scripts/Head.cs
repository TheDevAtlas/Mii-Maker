using UnityEngine;

public class Changer : MonoBehaviour
{
    virtual public void Change(int i) { }
}

public class Head : Changer
{
    public GameObject[] headsMale;
    public GameObject[] headsFemale;

    override public void Change(int i)
    {
        foreach(GameObject g in headsMale)
        {
            g.SetActive(false);
        }

        headsMale[i].SetActive(true);

        foreach (GameObject g in headsFemale)
        {
            g.SetActive(false);
        }

        headsFemale[i].SetActive(true);
    }
}
