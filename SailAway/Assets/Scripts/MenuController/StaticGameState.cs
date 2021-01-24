using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticGameState
{
    public static int gameState = 0;

    public static void changeState(int i)
    {
        gameState = i;
    }

    public static void winGame()
    {
        gameState = 1;
    }

    public static void loseGame()
    {
        gameState = 2;
    }

}
