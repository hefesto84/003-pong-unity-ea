using Pong.Core.Factories;

namespace Pong.Core.Systems.Base
{
    public abstract class System
    {
        public StateFactory StateFactory;
        
        public virtual void Init(){}
        public virtual void Update(){}
        public virtual void Reset(){}
    }
}