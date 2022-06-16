using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SocialMediaHasOCD : MonoBehaviour
{
    [SerializeField] Material[] Tweets;
    [SerializeField] int SecondsTilChange = 3;
    int TweetIndex;

    // Start is called before the first frame update
    void Start()
    {
        TweetIndex = 0;
        StartCoroutine(ChangeTweet(TweetIndex));
    }

    IEnumerator ChangeTweet(int TweetIndex)
    {
        GetComponentInChildren<MeshRenderer>().material = Tweets[TweetIndex];
        yield return new WaitForSeconds(SecondsTilChange);

        TweetIndex++;
        if (TweetIndex >= (Tweets.Length - 1))
        {
            TweetIndex = 0;
        }
        StartCoroutine(ChangeTweet(TweetIndex));
    }
}
