using UnityEngine;
using UnityEngine.UI;

public class MiiBody : MonoBehaviour
{
    public GameObject typeOne;
    public GameObject typeTwo;

    public Transform[] height;
    public Transform[] width;

    public float bodyHeight;
    public float bodyWidth;

    private void UpdateModel()
    {
        foreach(Transform t in height)
        {
            t.localScale = Vector3.one * (bodyHeight * 0.5f + 0.75f);
        }

        foreach(Transform t in width)
        {
            t.localScale = Vector3.one * (bodyWidth * 0.5f + 0.75f);
        }
    }

    public void SetHeight(float height)
    {
        bodyHeight = height;
        UpdateModel();
    }

    public void SetWidth(float width)
    {
        bodyWidth = width;
        UpdateModel();
    }

    public void changeType(bool type)
    {
        if (type)
        {
            typeOne.SetActive(false);
            typeTwo.SetActive(true);
        }
        else
        {
            typeOne.SetActive(true);
            typeTwo.SetActive(false);
        }
    }
}
