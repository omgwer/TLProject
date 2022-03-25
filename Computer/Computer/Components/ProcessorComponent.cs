using Computer.Components.Container;

namespace Computer.Components;

public class ProcessorComponent : AbstractComponent
{
    ProcessorComponent()
    {
        getDefaultProcessor();
    }

    private Component getDefaultProcessor()
    {
        setParameter("Type", "Celeron");
        setParameter("Frequency", "1100");
        return getComponent();
    }
}