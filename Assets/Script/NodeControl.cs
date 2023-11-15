using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listAllAdjacentes;
    public List<float> edgeCosts;
    private NodeControl lastNode;

    void Awake()
    {
        edgeCosts = new List<float>();
        for (int i = 0; i < listAllAdjacentes.Count; i++)
        {
            edgeCosts.Add(UnityEngine.Random.Range(5f, 21f));
        }
    }

    public NodeControl GetNextNode(out float cost)
    {
        cost = 0;
        if (listAllAdjacentes.Count == 0)
        {
            return null; 
        }

        List<int> possibleIndices = new List<int>();
        for (int i = 0; i < listAllAdjacentes.Count; i++)
        {
            
            if (listAllAdjacentes.Count == 1 || listAllAdjacentes[i] != lastNode)
            {
                possibleIndices.Add(i);
            }
        }

        int randomIndex = possibleIndices[UnityEngine.Random.Range(0, possibleIndices.Count)];
        cost = edgeCosts[randomIndex];
        lastNode = listAllAdjacentes[randomIndex];
        return listAllAdjacentes[randomIndex];
    }
}
