using Computer.Components.Container;

namespace Computer.Components;

public class ProcessorBuilder : ComponentContainer
{
    private string
        Name = "ProcessorName",
        ThreadCount = "ProcessorTreadCount",
        ThreadFrequency = "ProcessorThreadFrequency",
        CashStorage = "ProcessorCashStorage",
        TDP = "ProcessorTDP";

    public ProcessorBuilder(string name)
    {
        AddComponentValue(Name, name);
    }

    public void SetProcessorThreadCount(int threadCount)
    {
        if (threadCount <= 0 & threadCount > 64)
        {
            ErrorMessage(ThreadCount, threadCount.ToString());
            return;
        }
        AddComponentValue(ThreadCount, threadCount.ToString());
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
        if (cashStorage <= 0 & cashStorage > 100)
        {
            ErrorMessage(CashStorage, cashStorage.ToString());
            return;
        }
        AddComponentValue(CashStorage, cashStorage.ToString());
    }
    
    public void SetProcessorTdp(int TDP)
    {
        if (TDP <= 0 & TDP > 300)
        {
            ErrorMessage(this.TDP, TDP.ToString());
            return;
        }
        AddComponentValue(this.TDP, TDP.ToString());
    }

    public void ReplaceProcessor(string name)
    {
        ClearComponentContainer();
        AddComponentValue(Name, name);
    }


    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }

     private void ErrorMessage(string errorItem, string errorValue)
    {
        Console.WriteLine("Error to add "+ errorItem + " Info! Input "+ errorItem +" : " + errorValue +
                          " is not valid!");
    }
}