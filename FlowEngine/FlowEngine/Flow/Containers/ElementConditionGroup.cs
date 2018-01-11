﻿using FlowEngineV1;
using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow;
using FlowEngineV1.Flow.Containers;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Containers
{
    public class ElementConditionGroup : IOCElementExecute<ActivityConditionGroupType, ParamsConditionGroup>
    {
        #region Constructor
        public ElementConditionGroup(ActivityConditionGroupType element) : base(element)
        {
        }
        #endregion
        #region Method
        public override string GetUID(ActivityConditionGroupType element)
        {
            return element.ToString();
        }
        #endregion
    }
}