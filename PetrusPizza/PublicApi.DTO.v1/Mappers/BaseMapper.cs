using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public  class BaseMapper<TLeftObject, TRightObject> : ee.itcollege.mrajam.DAL.Base.Mappers.BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
    }
}