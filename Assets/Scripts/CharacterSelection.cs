using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] cars;
	public GameObject levelSelectCanvas;
	public GameObject carSelect;
	public int selected = 0;

	public void NextCharacter()
	{
		cars[selected].SetActive(false);
		selected = (selected + 1) % cars.Length;
		cars[selected].SetActive(true);
	}

	public void PreviousCharacter()
	{
		cars[selected].SetActive(false);
		selected--;
		if (selected < 0)
		{
			selected += cars.Length;
		}
		cars[selected].SetActive(true);
	}

	public void StartGame()
	{
		PlayerPrefs.SetInt("selectedCharacter", selected);
		LevelSelect();
	}

	public void LevelSelect()
	{
		levelSelectCanvas.SetActive(true);
		carSelect.SetActive(false);
	}

    public void Test()
    {
        Scenes.LoadScene(2);
    }

    public void City()
    {
        Scenes.LoadScene(3);
    }
    public void Circuit()
    {
        Scenes.LoadScene(4);
    }
}
