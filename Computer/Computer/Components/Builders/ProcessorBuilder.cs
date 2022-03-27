using Computer.Components.Container;

namespace Computer.Components.Builders;

public class ProcessorBuilder : AbstractComponentContainer
{
    private const string
        Name = "ProcessorName",
        IntegratedVideo = "IntegratedVideo",
        ThreadCount = "ProcessorTreadCount",
        ThreadFrequency = "ProcessorThreadFrequency",
        CashStorage = "ProcessorCashStorage",
        Tdp = "ProcessorTDP",
        Socket = "ProcessorSocket",
        ComponentTypeName = "Processor";

    public ProcessorBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
        AddComponentValue(IntegratedVideo, "false");
    }

    public void SetIntegratedVideo(bool isHave)
    {
        RemoveComponentValue(IntegratedVideo);
        AddComponentValue(IntegratedVideo, isHave.ToString());
    }

    public void SetProcessorThreadCount(int threadCount)
    {
        if (threadCount <= 0 | threadCount > 64)
        {
            ErrorMessage(ThreadCount, threadCount.ToString());
            return;
        }

        AddComponentValue(ThreadCount, threadCount.ToString());
    }

    public void SetProcessorSocket(string socketType)
    {
        foreach (var socket in Sockets)
        {
            if (socket.Equals(socketType))
            {
                AddComponentValue(Socket, socketType);
                return;
            }
        }

        ErrorMessage(Socket, socketType);
    }

    public void SetProcessorThreadFrequency(int threadFrequency)
    {
        if (threadFrequency <= 0 | threadFrequency > 5000)
        {
            ErrorMessage(ThreadFrequency, threadFrequency.ToString());
            return;
        }

        AddComponentValue(ThreadFrequency, threadFrequency.ToString());
    }

    public void SetProcessorCashStorage(int cashStorage)
    {
        if (cashStorage <= 0 | cashStorage > 100)
        {
            ErrorMessage(CashStorage, cashStorage.ToString());
            return;
        }

        AddComponentValue(CashStorage, cashStorage.ToString());
    }

    public void SetProcessorTdp(int tdp)
    {
        if (tdp <= 0 & tdp > 300)
        {
            ErrorMessage(Tdp, tdp.ToString());
            return;
        }

        AddComponentValue(Tdp, tdp.ToString());
    }

    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}