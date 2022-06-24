// Description: Continuously changes the twitter feed in the disinfect rooms
//
// made by: Ben

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_SocialMediaHasOCD : MonoBehaviour
{
    // Array of tweets and editable change timer
    [SerializeField] Material[] Tweets;
    [SerializeField] int SecondsTilChange = 3;
    int TweetIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize TweetIndex
        TweetIndex = 0;

        // Start the coroutine to change the tweet
        StartCoroutine(ChangeTweet(TweetIndex));
    }

    // Changes the tweet image
    IEnumerator ChangeTweet(int TweetIndex)
    {
        // Set the tweet to TweetIndex
        GetComponentInChildren<MeshRenderer>().material = Tweets[TweetIndex];

        // Waits
        yield return new WaitForSeconds(SecondsTilChange);

        // Cycles through indices
        TweetIndex++;
        if (TweetIndex >= (Tweets.Length - 1))
        {
            TweetIndex = 0;
        }

        // Loops
        StartCoroutine(ChangeTweet(TweetIndex));
    }
}
