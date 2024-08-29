using UnityEngine;

public class BodyTypeChange : MonoBehaviour
{
    public bool type;

    public GameObject t1;
    public GameObject t2;

    void Start()
    {
        OnTypeChange(false);
    }

    public void OnTypeChange(bool t)
    {
        type = t;

        t1.SetActive(!t);
        t2.SetActive(t);
    }
}
