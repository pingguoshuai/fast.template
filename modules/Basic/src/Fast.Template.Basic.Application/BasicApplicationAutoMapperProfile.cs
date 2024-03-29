using Fast.Template.Basic.Dics;
using Fast.Template.Basic.Dics.Dtos;
using AutoMapper;

namespace Fast.Template.Basic;

public class BasicApplicationAutoMapperProfile : Profile
{
    public BasicApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<DicType, DicTypeDto>();
        CreateMap<CreateUpdateDicTypeDto, DicType>(MemberList.Source);
        CreateMap<Dicinfo, DicinfoDto>();
        CreateMap<CreateUpdateDicinfoDto, Dicinfo>(MemberList.Source);
    }
}
