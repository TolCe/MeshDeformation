using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal MeshDeformerInput meshDeformerInput;
    public MeshDeformer meshDeformer;

    private void Awake()
    {
        instance = this;

        meshDeformerInput = GetComponent<MeshDeformerInput>();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
