using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    /// <summary>
    /// This class is an empty class for it to be taken over by other classes, for the state machine
    /// </summary>
    public abstract class BossState
    {
        
        public abstract BossState Update(BossStateMachine boss);

        public virtual void OnStart(BossStateMachine boss) { }
        public virtual void OnEnd(BossStateMachine boss) { }

    }
}