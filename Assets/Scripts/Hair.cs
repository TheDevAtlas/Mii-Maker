using UnityEngine;

public class Hair : Changer
{
    public GameObject[] hairMale;
    public GameObject[] hairFemale;

    override public void Change(int i)
    {
        foreach (GameObject g in hairMale)
        {
            g.SetActive(false);
        }

        hairMale[i].SetActive(true);

        foreach (GameObject g in hairFemale)
        {
            g.SetActive(false);
        }

        hairFemale[i].SetActive(true);
    }
}
