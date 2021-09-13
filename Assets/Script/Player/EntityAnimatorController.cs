using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EntityAnimatorController : MonoBehaviour
{
    public Animator EntityAnimator;
    public string DeathAnimationName;
    public string SpawnAnimationName;
    public string TeleportAnimationName;
    public string IdleAnimationName;

    private Dictionary<string, float> _nameToLength;

    public enum AnimationAction
    {
        Death,
        Spawn,
        Teleport,
        Idle
    }

    public void Awake()
    {
        _nameToLength = new Dictionary<string, float>();
        foreach (var clip in EntityAnimator.runtimeAnimatorController.animationClips)
        {
            _nameToLength.Add(clip.name, clip.length);
            /*if (clip.name == DeathAnimationName)
            {
                _nameToLength.Add(clip.name, clip.length);
            }
            else if (clip.name == SpawnAnimationName)
            {

            }
            else if (clip.name == TeleportAnimationName)
            {

            }
            else if (clip.name == IdleAnimationName)
            {

            }*/
        }
    }

    public float PlayAnimation(AnimationAction action)
    {
        string currentClipName = "";
        switch(action)
        {
            case AnimationAction.Death:
                EntityAnimator.Play(DeathAnimationName);
                currentClipName = DeathAnimationName;
                break;
            case AnimationAction.Spawn:
                EntityAnimator.Play(SpawnAnimationName);
                currentClipName = SpawnAnimationName;
                break;
            case AnimationAction.Teleport:
                EntityAnimator.Play(TeleportAnimationName);
                currentClipName = TeleportAnimationName;
                break;
            case AnimationAction.Idle:
                EntityAnimator.Play(IdleAnimationName);
                currentClipName = IdleAnimationName;
                break;

        }
        _nameToLength.TryGetValue(currentClipName, out float animationLength);
        return animationLength;
    }
}
