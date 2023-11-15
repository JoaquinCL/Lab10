
using UnityEngine;

public class GraphContainer : MonoBehaviour

{
    public NodeControl currentNode;
    public PlayerControl player;

    void Start()
    {
        player.SetCurrentNode(currentNode);
    }
}
