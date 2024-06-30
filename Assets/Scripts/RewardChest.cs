using UnityEngine;

public class RewardChest : MonoBehaviour
{
    public Animator animator;
    public GameObject chestTop;
    public Transform coinsParent;

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator not assigned on RewardChest script.");
            animator = GetComponent<Animator>();
        }

        if (chestTop == null)
            Debug.LogError("ChestTop not assigned on RewardChest script.");

        if (coinsParent == null)
            Debug.LogError("CoinsParent not assigned on RewardChest script.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player has triggered the chest.");
            OpenChest();
        }
    }

    private void OpenChest()
    {
        Debug.Log("Opening chest.");
        animator.SetBool("IsOpen", true);

        // Set the chestTop's local rotation to 10 degrees on the X axis
        chestTop.transform.localRotation = Quaternion.Euler(180, chestTop.transform.localEulerAngles.y, chestTop.transform.localEulerAngles.z);

        Debug.Log("Chest top should now be at 10 degrees on the X axis.");

        // Make the coins jump out
        if (coinsParent != null)
        {
            foreach (Transform coin in coinsParent)
            {
                Rigidbody coinRb = coin.GetComponent<Rigidbody>();
                if (coinRb != null)
                {
                    coinRb.isKinematic = false;
                    coinRb.AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
                    Debug.Log($"Coin {coin.gameObject.name} should jump.");
                }
            }
        }
    }

}
