using Computer.Components.Container;

namespace Computer.Components.Builders;

public class ProcessorBuilder
{
    private Processor Processor;

    public ProcessorBuilder()
    {
        Processor = new Processor();
    }

    public ProcessorBuilder SetProcessorName(string name)
    {
        Processor.Name = name;
        return this;
    }

    public ProcessorBuilder SetProcessorSocket(string socket)
    {
        Processor.Socket = socket;
        return this;
    }

    public ProcessorBuilder SetProcessorIntegratedVideo(bool isIntegratedVideo)
    {
        Processor.IntegratedVideo = isIntegratedVideo;
        return this;
    }

    public ProcessorBuilder SetProcessorThreadCount(int threadCount)
    {
        if (threadCount <= 0 | threadCount > 64)
        {
            throw new ArgumentException(threadCount + " - argument is not valid");
        }

        Processor.ThreadCount = threadCount;
        return this;
    }

    public ProcessorBuilder SetProcessorThreadFrequency(int coreFrequency)
    {
        if (coreFrequency <= 0 | coreFrequency > 5000)
        {
            throw new ArgumentException(coreFrequency + " - argument is not valid");
        }

        Processor.CoreFrequency = coreFrequency;
        return this;
    }

    public Processor Build()
    {
        CheckReadyToBuild();
        return Processor;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (Processor.Name == null)
        {
            softAssert += "ProcessorName ";
        }

        if (Processor.Socket == null)
        {
            softAssert += "ProcessorSize ";
        }

        if (Processor.ThreadCount == 0)
        {
            softAssert += "ProcessorRamSlotCount ";
        }

        if (Processor.CoreFrequency == 0)
        {
            softAssert += "ProcessorRamSlotCount ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}