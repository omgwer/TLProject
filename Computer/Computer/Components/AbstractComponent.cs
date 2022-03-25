using Computer.Components.Container;

namespace Computer.Components;

public class AbstractComponent
{
    private Component NewComponent = new Component();
    
    protected void clearComponent()
    {
        NewComponent.clear();
    }

    protected void setParameter(String name, String value)
    {
        NewComponent.Add(name, value);        
    }

    protected Component getComponent()
    {
        return NewComponent;
    }
}