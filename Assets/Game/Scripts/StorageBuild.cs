using UnityEngine;
using System.Collections;
using System;

public class StorageBuild : StaticUnit, IResourceReceiver
{
    [SerializeField]
    private ResourceType[] _acceptedResources;

    public ResourceType[] AcceptedResources
    {
        get { return _acceptedResources; }
    }

    public void ReceiveResource(int amount, ResourceType resource)
    {
        //envia os recursos para o GameManager
    }

    public bool AcceptResource(ResourceType resource)
    {
        foreach(ResourceType acceptedResource in _acceptedResources)
        {
            if(resource == acceptedResource)
            {
                return true;
            }
        }
        return false;
    }

    public override void OnCreated(string[] arguments)
    {
        _acceptedResources = new ResourceType[arguments.Length];
        for(int i =0;i< _acceptedResources.Length; i++)
        {
            _acceptedResources[i] = (ResourceType)System.Enum.Parse(typeof(ResourceType), arguments[i]);
        }
    }
}
