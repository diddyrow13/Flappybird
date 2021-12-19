using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 * https://videlais.com/2021/02/24/using-binaryformatter-in-unity-to-save-and-load-game-data/
 * used as reference to save data
 * 
 * https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
 * located in: %userprofile%\AppData\LocalLow\<companyname>\<productname>
 * 
 * 
 * POINT OF SCRIPT
 * ---------------------
 * Save the score so it is persistent upon game loads
 * 
 */


public static class SaveSystem
{
    public static void saveScore(int highScore)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/FlappyBirdSaveData.User"; //Goto path
        var stream = new FileStream(path, FileMode.Create); //Make file

        formatter.Serialize(stream, highScore); // Should be fine for integers
        stream.Close();
    }

    public static int LoadScore()
    {
        var path = Application.persistentDataPath + "/FlappyBirdSaveData.User"; //Goto path
        

        //Check if there is file in desired path
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open); //open file

            var highScore = (int)formatter.Deserialize(stream); // MUST BE CAST TO INT

            stream.Close();
            return highScore;
        }
        else //Player hasn't had a high score, so it'll be 0
        {
            return 0; // Default
        }
    }
}
