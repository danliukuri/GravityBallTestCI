using UnityEngine;

public static class InputHandler
{
    public static bool IsPlayerJump()
    {
        bool isPlayerJump = false;
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                if (touch.position.x < Screen.width  * 0.9f && touch.position.x > Screen.width  * 0.1f &&
                    touch.position.y < Screen.height * 0.9f && touch.position.y > Screen.height * 0.1f)
                {
                    isPlayerJump = true;
                }     
        }            
#elif UNITY_STANDALONE || UNITY_WEBGL
        if (Input.GetButtonDown("Jump"))
            isPlayerJump = true;
#endif
        return isPlayerJump;
    }
}