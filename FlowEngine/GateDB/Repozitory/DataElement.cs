using FessooFramework.Objects.ALM;
using FessooFramework.Tools.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Repozitory
{
    public class DataElement<TModelType, TStateType> : _IOCElement
        where TStateType : struct, IConvertible
    {
        internal DataElementALM<TModelType, TStateType> ALMPart = new DataElementALM<TModelType, TStateType>();
        //internal DataElementALM<TModelType, TStateType> DbSetPart = new DataElementALM<TModelType, TStateType>();
        //internal DataElementALM<TModelType, TStateType> CreatorPart = new DataElementALM<TModelType, TStateType>();
    }
}
