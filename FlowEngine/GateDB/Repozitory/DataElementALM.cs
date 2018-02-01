using FessooFramework.Objects.ALM;
using GateDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Repozitory
{
    internal class DataElementALM<TModelType,TStateType> : ALMObject<TStateType>
        where TStateType : struct, IConvertible
    {

    }
}
