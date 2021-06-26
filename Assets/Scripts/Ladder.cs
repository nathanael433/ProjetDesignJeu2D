using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topcollider;
    public Text interactUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            // descendre de l'echelle
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topcollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
