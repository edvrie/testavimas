using System;

namespace ObjektinisProgramuProjektavimas.Patterns.Prototype
{
    [Serializable()]
    public abstract class IPrototype<T>
    {
        public T Clone()
        {
            return (T)this.MemberwiseClone();
        }
    }
}
