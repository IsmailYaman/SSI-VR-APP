using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Videoflow : MonoBehaviour
{
    public PhysicsButton PhysicsButton;

    public bool isPlaying = true;

    public VideoPlayer VideoPlane;
    public VideoClip step1Video1;
    public VideoClip step1Video2;

    public VideoClip step2Video;

    public VideoClip step3Video1;
    public VideoClip step3Video2;
    public VideoClip step3Video3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("VideoFlow");
    }

    // Update is called once per frame
    void Update()
    {
        if (VideoPlane.isPlaying)
        {
            isPlaying = true;
        }
        else if (!VideoPlane.isPlaying)
        {
            isPlaying = false;
        }
    }


    IEnumerator VideoFlow()
    {
        yield return new WaitForSeconds(3);

        yield return new WaitUntil(() => !isPlaying);

        yield return new WaitForSeconds(1);

        Debug.Log("pls werk");

        yield return new WaitUntil(() => PhysicsButton.step1);


        if (PhysicsButton.step1Left)
        {
            Debug.Log("pressed button");
            VideoPlane.clip = step1Video1;
            VideoPlane.Play();
        }
        else if (PhysicsButton.step1Right)
        {
            VideoPlane.clip = step1Video2;
            VideoPlane.Play();
        }

        yield return new WaitForSeconds(3);

        yield return new WaitUntil(() => !isPlaying);

        yield return new WaitForSeconds(1);

        PhysicsButton.step2 = true;
        VideoPlane.clip = step2Video;
        VideoPlane.Play();

        yield return new WaitForSeconds(3);

        yield return new WaitUntil(() => !isPlaying);

        yield return new WaitForSeconds(1); 

        yield return new WaitUntil(() => PhysicsButton.step3);

        if (PhysicsButton.step3Left)
        {
            VideoPlane.clip = step3Video1;
            VideoPlane.Play();
        }
        else if (PhysicsButton.step3Middle)
        {
            VideoPlane.clip = step3Video2;
            VideoPlane.Play();
        }

        else if (PhysicsButton.step3Right)
        {
            VideoPlane.clip = step3Video3;
            VideoPlane.Play();
        }

        yield return new WaitForSeconds(3);
        yield return new WaitUntil(() => !isPlaying);
        yield return new WaitForSeconds(1);

    }

}
