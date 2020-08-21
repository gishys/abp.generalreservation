using AutoMapper;

namespace Nm.Reservation
{
    public class ReservationMapperProfile : Profile
    {
        public ReservationMapperProfile()
        {
            CreateMap<ReservationCondition, ReservationConditionDto>();
            CreateMap<ReservationManagerInfo, ReservationManagerInfoDto>();
        }
    }
}
