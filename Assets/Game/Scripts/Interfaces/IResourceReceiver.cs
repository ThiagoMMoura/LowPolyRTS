public interface IResourceReceiver {
    ResourceType[] AcceptedResources
    {
        get;
    }
    void ReceiveResource(int amount, ResourceType resource);
    bool AcceptResource(ResourceType resource);
}
