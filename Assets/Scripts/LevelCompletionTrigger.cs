using UnityEngine;

public class LevelCompletionTrigger : MonoBehaviour
{
    public GameObject levelCompletionPanel;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            Invoke("ShowLevelCompletionPanel", 3f);
        }
    }

    private void ShowLevelCompletionPanel()
    {
        if (levelCompletionPanel != null)
        {
            levelCompletionPanel.SetActive(true);
        }
    }
}
