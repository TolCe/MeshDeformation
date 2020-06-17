using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;
    //Vector3[] vertexVelocities;
    List<int> vertexIndex;
    internal List<int> changedVertices;

    private void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        changedVertices = new List<int>();
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        //vertexVelocities = new Vector3[originalVertices.Length];
        displacedVertices = originalVertices;
    }

    void Update()
    {
        /*for (int i = 0; i < displacedVertices.Length; i++)
        {
            UpdateVertex(i);
        }

        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < vertexVelocities.Length; i++)
            {
                vertexVelocities[i] = Vector3.zero;
            }
        }

        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();*/
    }

    /*public void AddDeformingForce(Vector3 point, float deformRadius, float deformPower)
    {
        point = transform.InverseTransformPoint(point);

        for (int i = 0; i < displacedVertices.Length; i++)
        {
            AddForceToVertex(i, point, deformRadius, deformPower);
        }
    }

    void AddForceToVertex(int i, Vector3 point, float deformRadius, float deformPower)
    {
        Vector3 pointToVertex = displacedVertices[i] - point;
        float attenuatedForce = deformRadius / (1f + pointToVertex.sqrMagnitude);
        float velocity = deformPower * attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;
    }

    void UpdateVertex(int i)
    {
        Vector3 velocity = vertexVelocities[i];
        velocity *= 0.1f;
        vertexVelocities[i] = velocity;
        displacedVertices[i] += velocity * Time.deltaTime;
    }*/

    public void SelectClosestVertices(Vector3 point, float digRadius, float digLevel)
    {
        vertexIndex = new List<int>();

        for (int i = 0; i < displacedVertices.Length; i++)
        {
            if (Vector3.Distance(point, displacedVertices[i]) < digRadius)
            {
                vertexIndex.Add(i);
            }
        }

        ChangeLevelOfVertices(digLevel);
    }

    private void ChangeLevelOfVertices(float digLevel)
    {
        for (int i = 0; i < vertexIndex.Count; i++)
        {
            if (!changedVertices.Contains(vertexIndex[i]))
            {
                displacedVertices[vertexIndex[i]] = new Vector3(displacedVertices[vertexIndex[i]].x, digLevel, displacedVertices[vertexIndex[i]].z);
                changedVertices.Add(vertexIndex[i]);
            }
        }

        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();
    }
}
