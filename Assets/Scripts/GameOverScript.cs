using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject counter;
    public GameObject healthBar;

    public GameObject finished;
    public GameObject died;
    public GameObject pos;
    public GameObject time;
    public GameObject currPos;

    public void Die()
    {
        gameObject.SetActive(true);
        counter.SetActive(false);
        healthBar.SetActive(false);
        died.SetActive(true);
    }
    public void Finish()
    {
        counter.GetComponent<Counter>().playing = false;
        string finishTime = counter.GetComponent<TMP_Text>().text;
        string finishPos = currPos.GetComponent<TMP_Text>().text;
        counter.SetActive(false);
        healthBar.SetActive(false);
        gameObject.SetActive(true);
        time.SetActive(true);
        time.GetComponent<TMP_Text>().text = "Time: " + finishTime;
        pos.SetActive(true);
        pos.GetComponent<TMP_Text>().text = "Position: " + finishPos;
    }
    public void RestartButton()
    {
        Scenes.RestartScene();
    }
    public void MenuButton()
    {
        Scenes.LoadScene(0);
    }
}
