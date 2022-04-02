using Computer.Components.Container;

namespace Computer.Components.Builders;

public class VideoCardBuilder
{
    private VideoCard VideoCard;
    
    public VideoCardBuilder()
    {
        VideoCard = new VideoCard();
    }

    public VideoCardBuilder SetVideocardName(string name)
    {
        VideoCard.Name = name;
        return this;
    }

    public VideoCardBuilder SetProcessorType(string processor)
    {
        VideoCard.Processor = processor;
        return this;
    }

    public VideoCardBuilder SetMemorySize(int memorySize)
    {
        if (memorySize <= 0 | memorySize > 16000)
        {
            throw new ArgumentException(memorySize + " - argument is not valid");
        }

        VideoCard.MemorySize = memorySize;
        return this;
    }

    public VideoCardBuilder SetTdp(int tdp)
    {
        if (tdp <= 0 | tdp > 300)
        {
            throw new ArgumentException(tdp + " - argument is not valid");
        }

        VideoCard.TDP = tdp;
        return this;
    }

    public VideoCard Build()
    {
        CheckReadyToBuild();
        return VideoCard;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (VideoCard.Name == null)
        {
            softAssert += "SUName ";
        }

        if (VideoCard.Processor == null)
        {
            softAssert += "SUColor ";
        }

        if (VideoCard.MemorySize == 0)
        {
            softAssert += "SUSize ";
        }

        if (VideoCard.TDP == 0)
        {
            softAssert += "SUWeight ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}