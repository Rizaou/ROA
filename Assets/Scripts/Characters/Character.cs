using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float duration = 1f;

    private AnimationCurve toWaterCurve;
    private AnimationCurve toPathCurve;
    private Animator animator;


    private const string animatorConditionName = "condition";
    private const string triggerStartName = "Start";
    private const string triggerEndName = "Finish";


    [SerializeField] private enum AnimationConditon
    {
        idle,
        run,
        jumpToSea,
        swim,
        jumpToPath

    };

    private void Awake()
    {
        animator = (Animator)GetComponent("Animator");
    }

    private void Start()
    {
        toWaterCurve = GameManager.instance.characters.toSwimCurve;
        toPathCurve = GameManager.instance.characters.toPathCurve;
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerScript triggerScript = other.transform.parent.GetComponent<TriggerScript>();

        if (!triggerScript) return;
        if(other.gameObject.name == triggerStartName && triggerScript.triggerMode == TriggerScript.TriggerMode.swimTrigger)
        {
            StartCoroutine(JumpToWater());
        }
        else if(other.gameObject.name == triggerEndName && triggerScript.triggerMode == TriggerScript.TriggerMode.swimTrigger)
        {
            StartCoroutine(JumpToPath());
        }
    }


    IEnumerator JumpToWater()
    {
        float time = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + (5f * Vector3.left);

        animator.SetInteger(animatorConditionName, ((int)AnimationConditon.jumpToSea));

        while (time <= duration)
        {
            float t = (time / duration);
            transform.position = Vector3.Lerp(startPos, endPos, t) + (toWaterCurve.Evaluate(t) * Vector3.up * 9 );
            time += Time.deltaTime;
            yield return null;

        }
            animator.SetInteger(animatorConditionName, ((int)AnimationConditon.swim));

    }
    IEnumerator JumpToPath()
    {
        float time = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + (5f * Vector3.left);

        animator.SetInteger(animatorConditionName, ((int)AnimationConditon.jumpToPath));

        while (time <= duration)
        {
            float t = (time / duration);
            transform.position = Vector3.Lerp(startPos, endPos, t) + (toPathCurve.Evaluate(t) * Vector3.up * 8);
            time += Time.deltaTime;
            yield return null;

        }
       // transform.position += startPos + (Vector3.up * 8); 
        animator.SetInteger(animatorConditionName, ((int)AnimationConditon.run));
    }
}
