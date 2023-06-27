using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Pipeline -> Stage -> Job -> Action
 */

namespace ToyStudio.Editor.BuildCore
{
    public class CBuildPipeline
    {
        public List<CBuildStage> Stages { get; set; }

        public CBuildPipeline()
        {
            Stages = new List<CBuildStage>(4);
        }

        public void AddStage(CBuildStage stage)
        {
            if (stage != null)
            {
                Stages.Add(stage);
            }
        }

        public void RemoveStage(CBuildStage stage)
        {
            
        }
        
        public void AddStages(List<CBuildStage> stages)
        {
            if (stages != null && stages.Count > 0)
            {
                Stages.AddRange(stages);
            }
        }

        public void Run()
        {
            
        }
        
    }
}
