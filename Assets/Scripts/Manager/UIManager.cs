using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] disableOnMenuObjects;
    public InputField inputFieldDigRadius;
    public InputField inputFieldDigLevel;
    public GameObject menuPanel;

    public void SaveSettings()
    {
        GameManager.instance.meshDeformerInput.digRadius = int.Parse(inputFieldDigRadius.text);
        inputFieldDigRadius.text = "";
        GameManager.instance.meshDeformerInput.digLevel = int.Parse(inputFieldDigLevel.text);
        inputFieldDigLevel.text = "";
        GameManager.instance.meshDeformer.changedVertices = new List<int>();
        OpenCloseMenu();
    }

    public void OpenCloseMenu()
    {
        for (int i = 0; i < disableOnMenuObjects.Length; i++)
        {
            disableOnMenuObjects[i].SetActive(!disableOnMenuObjects[i].activeSelf);
        }

        menuPanel.SetActive(!menuPanel.activeSelf);
    }
}
