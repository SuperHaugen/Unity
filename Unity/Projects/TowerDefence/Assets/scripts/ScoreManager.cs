using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;

    public Text moneyText;
    public Text livesText;

    public void LoseLife()
    {
        lives -=1;
        if (lives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!");
        SceneManager.LoadScene("GameOver_scene");
    }


    // Update is called once per frame
	void Update ()
	{
	    moneyText.text = "Money: $" + money;
	    livesText.text = "Lives: " + lives;
	}
}