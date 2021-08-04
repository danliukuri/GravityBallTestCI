using UnityEngine;

public class GameoverHandler : MonoBehaviour
{
    [SerializeField] float lowerBoundOfPlayerDeath;
    [SerializeField] float upperBoundOfPlayerDeath;

    bool isGameover;
    void LateUpdate()
    {
        if(!isGameover)
            if (transform.position.y < lowerBoundOfPlayerDeath || transform.position.y > upperBoundOfPlayerDeath)
            {
                CanvasButtons.Gameover();
                ScoreCounter.TryToSaveScore();
                isGameover = true;
            } 
    }
}