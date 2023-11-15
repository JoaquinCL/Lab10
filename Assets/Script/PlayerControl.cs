using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private NodeControl currentNode;
    private float currentEnergy;
    private Vector2 refVelocity;
    public float timeToMove;
    public Text energyDisplay;
    private bool isResting;
    private float restDuration = 5f;
    private float restTimer;
    public float energy = 100f;

    void Start()
    {
        currentEnergy = energy;
        UpdateEnergyDisplay();
    }

    void Update()
    {
        if (isResting)
        {
            restTimer += Time.deltaTime;
            currentEnergy += (energy / restDuration) * Time.deltaTime;
            UpdateEnergyDisplay();

            if (currentEnergy >= energy)
            {
                currentEnergy = energy;
                isResting = false;
                restTimer = 0f;
            }
        }
        else if (currentNode != null)
        {
            if (!HasReachedNode())
            {
                MoveToNode();
            }
            else
            {
                CheckEnergy();
            }
        }
    }

    private void MoveToNode()
    {
        transform.position = Vector2.SmoothDamp(transform.position, currentNode.transform.position, ref refVelocity, timeToMove);
    }

    private bool HasReachedNode()
    {
        return Vector2.Distance(transform.position, currentNode.transform.position) < 0.1f;
    }

    public void SetCurrentNode(NodeControl newNode)
    {
        currentNode = newNode;
        UpdateEnergyDisplay();
    }

    void CheckEnergy()
    {
        if (currentNode == null)
            return;

        float cost;
        NodeControl nextNode = currentNode.GetNextNode(out cost);

        if (currentEnergy >= cost)
        {
            currentNode = nextNode;
            currentEnergy -= cost;
            UpdateEnergyDisplay();
        }
        else
        {
            isResting = true;
            restTimer = 0f;
        }
    }

    void UpdateEnergyDisplay()
    {
        if (energyDisplay != null)
            energyDisplay.text = "Energía: " + Mathf.RoundToInt(currentEnergy);
    }
}
