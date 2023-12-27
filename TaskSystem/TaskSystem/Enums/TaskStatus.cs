using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To be done")]
        ToDo =1,
        [Description("On Going")]
        OnGoing = 2,
        [Description("Concluded")]
        Finish = 3
    }
}
