using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject sphere;
    public int amount;
    private float firstX = -45;
    private float firstZ = -45;

    void Start()
    {
        StartCoroutine(CreateSpheres());
    }

    private IEnumerator CreateSpheres()
    {
        for (int i = 0; i < amount; i++)
        {
            for (float j = firstX; i < -firstX; i++)
            {
                for (float k = firstZ; j < -firstZ; j++)
                {
                    Instantiate(sphere, new Vector3(j, 50, k), Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }
}
