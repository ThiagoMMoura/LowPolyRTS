using UnityEngine;
using System.Collections;

public class Villager : MobileUnit {

    public new VillagerProperties properties;

    internal override void Start()
    {
        base.Start();
        properties = new VillagerProperties();
        properties.resourceCapacity = 15;
        properties.unitGatheredPerSecond = 2;
        properties.hpBuiltPerSecond = 10;
    }

    private IEnumerator Gather(ResourceRoot source)
    {
        properties.currentResource = source.resource;
        while (!source.IsEmpty)
        {
            yield return StartCoroutine(MoveTo(new Vector3[1] { source.transform.position }));
            while (!properties.IsFull)
            {
                int unitsThatWillBeGathered = Mathf.Min(properties.unitGatheredPerSecond, (properties.resourceCapacity - properties.currentResourceAmount));
                properties.currentResourceAmount += source.GatherFromHere(unitsThatWillBeGathered);
                yield return new WaitForSeconds(1);
            }
            IResourceReceiver resourceReceiver = UnitController.GetClosestResourceReceiver(source.resource, transform.position);
            if(resourceReceiver != null) {
                yield return StartCoroutine(MoveTo(new Vector3[1] { (resourceReceiver as StorageBuild).transform.position }));
                properties.GiveResources(resourceReceiver);
            }
            else
            {
                StopAllCoroutines();
            }
        }
    }

    private IEnumerator Build(Construction c)
    {
        yield return StartCoroutine(MoveTo(new Vector3[1] { c.transform.position }));
        while(!c.IsDone)
        {
            c.Build(properties.hpBuiltPerSecond);
            yield return new WaitForSeconds(1);
        }
    }
    public override void ActionCallback(ResourceRoot target)
    {
        StopAllCoroutines();
        StartCoroutine(Gather(target));
    }

    public override void ActionCallback(Construction target)
    {
        StopAllCoroutines();
        StartCoroutine(Build(target));
    }
}
